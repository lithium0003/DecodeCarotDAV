using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecodeCarotDAV
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Config.CarotDAV_crypt_names);
            comboBox1.Text = Config.CarotDAV_CryptNameHeader;
            CryptCarotDAV.Password = "";
        }

        private void Log(string str)
        {
            textBox_log.Text += (str + "\r\n");
        }

        private void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }

        private async Task DecodeFile(IEnumerable<string> encfiles, string rootpath = null)
        {
            foreach(var file in encfiles)
            {
                if (!File.Exists(file))
                {
                    Log("file not found : {0}", file);
                    continue;
                }
                var decfilepath = rootpath;
                if (decfilepath == null)
                    decfilepath = Path.GetDirectoryName(file);

                var encfilename = Path.GetFileName(file);
                var decfilename = CryptCarotDAV.DecryptFilename(encfilename);
                if(decfilename == null)
                {
                    Log("filename decode error : {0}", file);
                    continue;
                }

                var decfile = Path.Combine(decfilepath, decfilename);
                if (File.Exists(decfile))
                {
                    Log("Exists : {0}", decfile);
                    continue;
                }

                using (var efile = File.OpenRead(file))
                using (var dfile = File.OpenWrite(decfile))
                using (var cfile = new CryptCarotDAV.CryptCarotDAV_DecryptStream(efile))
                {
                    try
                    {
                        await cfile.CopyToAsync(dfile, 81920, cts.Token);
                    }
                    catch(Exception ex)
                    {
                        Log("Decode Error : {0}->{1} {2}", file, decfile, ex.Message);
                        continue;
                    }
                }
                Log("OK : {0}->{1}", file, decfile);
            }
        }

        private async Task DecodeFolder(IEnumerable<string> encfolder, string rootpath = null)
        {
            foreach (var folder in encfolder)
            {
                if (!Directory.Exists(folder))
                {
                    Log("folder not found : {0}", folder);
                    continue;
                }
                var decparent = rootpath;
                if (decparent == null)
                    decparent = Directory.GetParent(folder).FullName;

                var encfoldername = (folder.EndsWith("\\")) ? Path.GetDirectoryName(folder) : folder;
                var i = encfoldername.LastIndexOf('\\');
                if (i >= 0)
                    encfoldername = encfoldername.Substring(i + 1);

                var decfoldername = CryptCarotDAV.DecryptFilename(encfoldername);
                if (decfoldername == null)
                {
                    Log("foldername decode error : {0}", folder);
                    continue;
                }

                var decfolder = Path.Combine(decparent, decfoldername);
                if (Directory.Exists(decfolder))
                {
                    Log("Exists : {0}", decfolder);
                    continue;
                }

                try
                {
                    Directory.CreateDirectory(decfolder);
                }
                catch(Exception ex)
                {
                    Log("CreateDirectory failed : {0} {1}", decfolder, ex.Message);
                    continue;
                }

                Log("OK : {0}->{1}", folder, decfolder);

                // subitems
                var subfiles = Directory.GetFiles(folder);
                var subdirs = Directory.GetDirectories(folder);

                await DecodeFile(subfiles, decfolder);
                await DecodeFolder(subdirs, decfolder);
            }
        }

        private async Task EncodeFile(IEnumerable<string> plainfiles, string rootpath = null)
        {
            foreach (var file in plainfiles)
            {
                if (!File.Exists(file))
                {
                    Log("file not found : {0}", file);
                    continue;
                }
                var encfilepath = rootpath;
                if (encfilepath == null)
                    encfilepath = Path.GetDirectoryName(file);

                var plainfilename = Path.GetFileName(file);
                var encfilename = CryptCarotDAV.EncryptFilename(plainfilename);

                var encfile = Path.Combine(encfilepath, encfilename);
                if (File.Exists(encfile))
                {
                    Log("Exists : {0}", encfile);
                    continue;
                }

                using (var pfile = File.OpenRead(file))
                using (var efile = File.OpenWrite(encfile))
                using (var cfile = new CryptCarotDAV.CryptCarotDAV_CryptStream(pfile))
                {
                    try
                    {
                        await cfile.CopyToAsync(efile, 81920, cts.Token);
                    }
                    catch (Exception ex)
                    {
                        Log("Encode Error : {0}->{1} {2}", file, encfile, ex.Message);
                        continue;
                    }
                }
                Log("OK : {0}->{1}", file, encfile);
            }
        }

        private async Task EncodeFolder(IEnumerable<string> plainfolder, string rootpath = null)
        {
            foreach (var folder in plainfolder)
            {
                if (!Directory.Exists(folder))
                {
                    Log("folder not found : {0}", folder);
                    continue;
                }
                var encparent = rootpath;
                if (encparent == null)
                    encparent = Directory.GetParent(folder).FullName;

                var plainfoldername = (folder.EndsWith("\\")) ? Path.GetDirectoryName(folder) : folder;
                var i = plainfoldername.LastIndexOf('\\');
                if (i >= 0)
                    plainfoldername = plainfoldername.Substring(i + 1);

                var encfoldername = CryptCarotDAV.EncryptFilename(plainfoldername);

                var encfolder = Path.Combine(encparent, encfoldername);
                if (Directory.Exists(encfolder))
                {
                    Log("Exists : {0}", encfolder);
                    continue;
                }

                try
                {
                    Directory.CreateDirectory(encfolder);
                }
                catch (Exception ex)
                {
                    Log("CreateDirectory failed : {0} {1}", encfolder, ex.Message);
                    continue;
                }

                Log("OK : {0}->{1}", folder, encfolder);

                // subitems
                var subfiles = Directory.GetFiles(folder);
                var subdirs = Directory.GetDirectories(folder);

                await EncodeFile(subfiles, encfolder);
                await EncodeFolder(subdirs, encfolder);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = (checkBox1.Checked) ? '*' : '\0';
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            CryptCarotDAV.Password = textBox1.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.CarotDAV_CryptNameHeader = comboBox1.Text;
        }

        private async void button_DecFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "select to decrypt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            await DecodeFile(openFileDialog1.FileNames);
            Log("Done.");
        }

        private async void button_DecFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "select to decrypt";
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            await DecodeFolder(new string[] { folderBrowserDialog1.SelectedPath });
            Log("Done.");
        }

        private async void button_EncFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "select to encrypt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            await EncodeFile(openFileDialog1.FileNames);
            Log("Done.");
        }

        private async void button_EncFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "select to encrypt";
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            await EncodeFolder(new string[] { folderBrowserDialog1.SelectedPath });
            Log("Done.");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private async void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            var decodes = fileNames.Where(item => Path.GetFileName(item).StartsWith(Config.CarotDAV_CryptNameHeader));
            var encodes = fileNames.Except(decodes);

            await DecodeFile(decodes.Where(item => File.Exists(item)));
            await DecodeFolder(decodes.Where(item => Directory.Exists(item)));
            await EncodeFile(encodes.Where(item => File.Exists(item)));
            await EncodeFolder(encodes.Where(item => Directory.Exists(item)));
            Log("Done.");
        }
    }
}
