using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace RevPacker
{
  public partial class FormMain : Form
  {
    public Dictionary<string, List<ZipEntry>> listGroEntries = new Dictionary<string, List<ZipEntry>>();
    static Dictionary<string, string> ReplaceHistory = new Dictionary<string, string>();

    public FormMain()
    {
      InitializeComponent();
    }

    static string FileReplaceHistory(string filename)
    {
      foreach (KeyValuePair<string, string> pair in ReplaceHistory) {
        if (filename.ToLower().StartsWith(pair.Key.ToLower())) {
          filename = pair.Value + filename.Substring(pair.Key.Length);
        }
      }
      return filename;
    }

    static string FixFilename(string filename)
    {
      return FileReplaceHistory(filename
        .Replace('\\', '/')
        .Trim('/', ' ', '"', ';', '\r', '\n')
        .Replace(' ', '_')
        );
    }

    int GetImageIndexForFilename(string strFilename)
    {
      string strExt = Path.GetExtension(strFilename).ToLower();
      switch (strExt) {
        case ".wld": return 0;
        case ".tex": return 1;
        case ".wav": return 2;
        case ".ogg":
        case ".mp3": return 3;
        case ".mdl": return 4;
        case ".vis": return 6;
      }
      return 5;
    }

    void IndexGroFiles()
    {
      listGroEntries.Clear();
      if (textGamePath.Text != "" && Directory.Exists(textGamePath.Text)) {
        string[] astrGroFiles = Directory.GetFiles(textGamePath.Text, "*.gro");
        foreach (string strGroFile in astrGroFiles) {
          listGroEntries.Add(strGroFile, new List<ZipEntry>());
          try {
            using (ZipFile file = new ZipFile(strGroFile)) {
              for (int i = 0; i < file.Count; i++) {
                listGroEntries[strGroFile].Add(file[i]);
              }
            }
          } catch { Console.WriteLine("Reading " + strGroFile + " failed!"); }
        }
      } else {
        MessageBox.Show(
          "You messed up the game path! This causes the application to not be able to" +
          " find and index gro files. Please set the game path on the \"General\" tab.", "Warning",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    void LoadReplaceHistory()
    {
      string replaceFilename = textGamePath.Text + "\\Data\\ReplaceHistory.txt";
      ReplaceHistory.Clear();
      if (File.Exists(replaceFilename)) {
        using (StreamReader reader = new StreamReader(File.OpenRead(replaceFilename))) {
          while (!reader.EndOfStream) {
            string line = reader.ReadLine().Trim();
            if (line == "" || line.StartsWith("//")) {
              continue;
            }
            string[] parse = line.Split('=');
            ReplaceHistory.Add(parse[0].Trim(), parse[1].Trim());
          }
        }
        //Console.WriteLine("Replace history has " + ReplaceHistory.Count + " entries");
      } else {
        //Console.WriteLine("Replace history not found!");
      }
    }

    string GetCRC32(string strFilename)
    {
      using (FileStream fs = File.OpenRead(strFilename)) {
        Crc32 c = new Crc32();
        string ret = "";
        foreach (byte b in c.ComputeHash(fs)) {
          ret += b.ToString("x2").ToLower();
        }
        return ret;
      }
    }

    string strOutput;
    void FindDependenciesForNode(TreeNode node)
    {
      node.Nodes.Clear();

      string strFileName = node.Text;
      if (strFileName.Length > 2 && strFileName[1] != ':') {
        strFileName = textGamePath.Text + "\\" + strFileName;
      }

      if (strFileName.ToLower().EndsWith(".ogg") || strFileName.ToLower().EndsWith(".mp3")) {
        return;
      }

      string strFindMe = "DFNM";
      int iFindString = 0;

      List<string> listDependencies = new List<string>();

      using (BinaryReader reader = new BinaryReader(File.OpenRead(strFileName), Encoding.ASCII)) {
        int c = 0;
        while (true) {
          try {
            c = reader.ReadByte();
          } catch {
            break;
          }

          if (iFindString == 3) {
            int iLen = reader.ReadInt32();
            if (iLen > 500 || iLen < 0) {
              // happens sometimes in models for some reason, not sure why
              // also happens in textures sometimes when bytes in pixel color collide with 0x45464E4D (EFNM)
            } else {
              string strDependency = FixFilename(Encoding.ASCII.GetString(reader.ReadBytes(iLen)));

              if (strDependency != "") {
                listDependencies.Add(strDependency);
              }
            }

            iFindString = 0;
          } else if (iFindString < strFindMe.Length - 1) {
            if ((char)c == strFindMe[iFindString]) {
              iFindString++;
            } else {
              iFindString = 0;
            }
          }
        }
      }

      foreach (string strGroFile in listGroEntries.Keys) {
        foreach (ZipEntry entry in listGroEntries[strGroFile]) {
          string strGroEntry = entry.Name.Replace('\\', '/');
          for (int j = 0; j < listDependencies.Count; j++) {
            if (!listDependencies[j].ToLower().Replace('\\', '/').EndsWith(strGroEntry.ToLower())) {
              continue;
            }

            if (checkVerbose.Checked) {
              string strLine = "--  " + strGroEntry + " (from " + strGroFile + ")";

              Console.WriteLine(strLine);
              strOutput += strLine + "\r\n";
            }

            string strDiskFilename = textGamePath.Text + "\\" + strGroEntry;
            if (File.Exists(strDiskFilename)) {
              if (GetCRC32(strDiskFilename) != entry.Crc.ToString("x8")) {
                continue;
              }
            }

            listDependencies.RemoveAt(j);
          }
        }
      }

      if (node.Text.EndsWith(".wld")) {
        string strDepVis = node.Text.Replace(".wld", ".vis");
        if (strDepVis.StartsWith(textGamePath.Text.Replace('\\', '/'))) {
          strDepVis = strDepVis.Substring(textGamePath.Text.Length + 1);
        }
        if (File.Exists(textGamePath.Text + "\\" + strDepVis)) {
          TreeNode nodeChild = node.Nodes.Add(strDepVis);
          nodeChild.ImageIndex = nodeChild.SelectedImageIndex = GetImageIndexForFilename(strDepVis);
        }
      }

      int iCount = 0;
      foreach (string strDependency in listDependencies) {
        if (strDependency.EndsWith(".ecl")) {
          continue;
        }

        string strDep = strDependency.Trim('\\').Replace('\\', '/');
        TreeNode nodeChild = node.Nodes.Add(strDep);
        nodeChild.ImageIndex = nodeChild.SelectedImageIndex = GetImageIndexForFilename(strDep);

        if (textGamePath.Text != "" && Directory.Exists(textGamePath.Text)) {
          bool bFound = false;
          if (File.Exists(textGamePath.Text + "\\" + strDep.Replace('/', '\\'))) {
            bFound = true;
            FindDependenciesForNode(nodeChild);
          } else {
            // in case it's an mp3/ogg switch
            if (strDep.EndsWith(".mp3") || strDep.EndsWith(".ogg")) {
              if (strDep.EndsWith(".mp3")) {
                strDep = strDep.Replace(".mp3", ".ogg");
              } else if (strDep.EndsWith(".ogg")) {
                strDep = strDep.Replace(".ogg", ".mp3");
              }
              if (File.Exists(textGamePath.Text + "\\" + strDep.Replace('/', '\\'))) {
                bFound = true;
                nodeChild.Text = strDep;
              }
            }
          }
          if (!bFound) {
            nodeChild.Text = "(Missing on disk) " + nodeChild.Text;
            nodeChild.ForeColor = Color.Red;
          }
        }

        string strLine = (++iCount) + ".  " + strDep;

        Console.WriteLine(strLine);
        strOutput += strLine + "\r\n";
      }
    }

    void ReloadDependencies()
    {
      strOutput = "";

      LoadReplaceHistory();
      IndexGroFiles();

      foreach (TreeNode node in listFiles.Nodes) {
        FindDependenciesForNode(node);
      }

      textDependencies.Text = strOutput;
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
#if DEBUG
      textGamePath.Text = @"D:\AP\Rev";
      tabControl1.SelectTab(1);
#endif
    }

    private void button1_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dialog = new FolderBrowserDialog();
      if (dialog.ShowDialog() == DialogResult.OK) {
        textGamePath.Text = dialog.SelectedPath;
      }
    }

    private void buttonAddFile_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      if (textGamePath.Text != "" && Directory.Exists(textGamePath.Text + "\\Levels")) {
        dialog.InitialDirectory = textGamePath.Text + "\\Levels";
      }
      if (dialog.ShowDialog() == DialogResult.OK) {
        TreeNode node = listFiles.Nodes.Add(dialog.FileName.Replace('\\', '/'));
        node.ImageIndex = node.SelectedImageIndex = GetImageIndexForFilename(dialog.FileName);

        ReloadDependencies();
      }
    }

    private void buttonRemoveFile_Click(object sender, EventArgs e)
    {
      if (listFiles.SelectedNode != null) {
        listFiles.Nodes.Remove(listFiles.SelectedNode);
        ReloadDependencies();
      }
    }

    private void buttonRefreshDependencies_Click(object sender, EventArgs e)
    {
      ReloadDependencies();
    }

    private void checkVerbose_CheckedChanged(object sender, EventArgs e)
    {
      ReloadDependencies();
    }

    void AddNodeToGro(string strPath, ZipFile newZip, TreeNode nodeRoot)
    {
      foreach (TreeNode nodeChild in nodeRoot.Nodes) {
        if (!File.Exists(strPath + nodeChild.Text)) {
          MessageBox.Show("The file \"" + (strPath + nodeChild.Text).Replace('\\', '/') + "\" can't be found, and has not been added to the gro file!", "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          continue;
        }

        if (nodeChild.ImageIndex == 2 || nodeChild.ImageIndex == 3) { // music and sounds
          // don't compress music and sounds!!!
          newZip.Add(new StaticDiskDataSource(strPath + nodeChild.Text), nodeChild.Text, CompressionMethod.Stored);
        } else {
          newZip.Add(strPath + nodeChild.Text, nodeChild.Text);
        }

        // recurse
        AddNodeToGro(strPath, newZip, nodeChild);
      }
    }

    private void buttonCreateGro_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.InitialDirectory = textGamePath.Text;
      dialog.Filter = "Gro files (*.gro)|*.gro|All files (*.*)|*.*";

      if (dialog.ShowDialog() == DialogResult.OK) {
        ZipFile newZip = ZipFile.Create(dialog.FileName);
        newZip.BeginUpdate();

        string strPath = textGamePath.Text.Replace('\\', '/') + "/";

        foreach (TreeNode nodeRoot in listFiles.Nodes) {
          newZip.Add(nodeRoot.Text, nodeRoot.Text.Replace(strPath, ""));
          AddNodeToGro(strPath, newZip, nodeRoot);
        }

        newZip.CommitUpdate();
        newZip.Close();
        MessageBox.Show("Gro file saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
  }
}
