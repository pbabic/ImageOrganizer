using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = Text + "  " + Application.ProductVersion;

            LoadConfiguration();

            this.cmbFirstLevelFolder.SelectedValueChanged += new System.EventHandler(this.DestinationFolderExample);
            this.cmbSecondLevelFolder.SelectedValueChanged += new System.EventHandler(this.DestinationFolderExample);
            this.cmbThirdLevelFolder.SelectedValueChanged += new System.EventHandler(this.DestinationFolderExample);

            this.cmbFirstLevelFolder.SelectedValueChanged += new System.EventHandler(this.FilterUsedValue);
            this.cmbSecondLevelFolder.SelectedValueChanged += new System.EventHandler(this.FilterUsedValue);
            this.cmbThirdLevelFolder.SelectedValueChanged += new System.EventHandler(this.FilterUsedValue);

            this.cmbRename.SelectedValueChanged += new System.EventHandler(this.DestinationFolderExample);
            this.cmbNameExists.SelectedValueChanged += new System.EventHandler(this.DestinationFolderExample);
            this.txtDestination.TextChanged += new System.EventHandler(this.DestinationFolderExample);

            this.txtCustom1.TextChanged += new System.EventHandler(this.DestinationFolderExample);
            this.txtCustom2.TextChanged += new System.EventHandler(this.DestinationFolderExample);
            this.txtCustom3.TextChanged += new System.EventHandler(this.DestinationFolderExample);

            GuiHelper.help(txtSource, button1, "Choose folder or disk drive where your files can be found.");


        }

    private void FilterUsedValue(object sender, EventArgs e)
        {

            var combo = (ComboBox)sender;

            List<ComboBox> combos = new List<ComboBox>()
            {
                this.cmbFirstLevelFolder,
                this.cmbSecondLevelFolder,
                this.cmbThirdLevelFolder
            };

            combos.Remove(combo);

            foreach(ComboBox c in combos) {
                if (c.SelectedItem.Equals(combo.SelectedItem)) c.SelectedIndex = 0;
            }

        }

        private void LoadConfiguration()
        {
            txtSource.Text = (string)Properties.Settings.Default["sourceFolder"];
            txtDestination.Text = (string)Properties.Settings.Default["destinationFolder"];
            string extensions = (string)Properties.Settings.Default["exstensions"];

            txtExtensions.Text = string.IsNullOrEmpty(extensions) ? string.Join(",", FileData.EXTENSIONS) : extensions;

            cmbRename.DataSource = new BindingSource(new Dictionary<FileData.FileRenameOptions, string>()
            {
                {FileData.FileRenameOptions.NO, "No"},
                {FileData.FileRenameOptions.TIMESTAMP, "Timestamp (yyyyMMddHHmmss format; example: " + DateTime.Now.ToString("yyyyMMddHHmmss") +" )"},
                {FileData.FileRenameOptions.PARENT_FOLDER_PREFIX, @"Parent folder as prefix from source folder (xxx in c:\aaa\bbb\xxx\image.jpg)"},
                {FileData.FileRenameOptions.PARENT_FOLDER_IF_TEXT_EXISTS, "Parent folder as prefix from source folder if contains alphabetic charachters"},
            }, null);
            cmbRename.DisplayMember = "Value";
            cmbRename.ValueMember = "Key";
            Enum.TryParse((string)Properties.Settings.Default["renameOption"], out FileData.FileRenameOptions value);
            cmbRename.SelectedValue = value;

            cmbNameExists.DataSource = new BindingSource(new Dictionary<FileData.FileNameExistsAction, string>()
            {
                {FileData.FileNameExistsAction.ADD_SUFFIX, "Add suffix: <some_image>_001, <some_image>_002..."},
                { FileData.FileNameExistsAction.TERMINATE, "Stop"},
            }, null);
            cmbNameExists.DisplayMember = "Value";
            cmbNameExists.ValueMember = "Key";
            Enum.TryParse((string)Properties.Settings.Default["fileNameExistsAction"], out FileData.FileNameExistsAction value2);
            cmbNameExists.SelectedValue = value2;

            cmbFirstLevelFolder.DataSource = new BindingSource(new Dictionary<FileData.FolderCreation, string>()
            {
                {FileData.FolderCreation.NOTHING, "Nothing"},
                {FileData.FolderCreation.CURRENT_IMAGE_FOLDER, "Current parent folder"},
                {FileData.FolderCreation.CAMERA, "Camera producer-model"},
                {FileData.FolderCreation.YEAR_MONTH, "Year-month (yyyy.mm)"},
                {FileData.FolderCreation.YEAR_MONTH_DAY, "Year-month-days (yyyy.mm.DD)"},
                {FileData.FolderCreation.ENTER, "Enter folder name"},
            }, null);
            cmbFirstLevelFolder.DisplayMember = "Value";
            cmbFirstLevelFolder.ValueMember = "Key";
            Enum.TryParse((string)Properties.Settings.Default["firstLevelFolder"], out FileData.FolderCreation value3);
            cmbFirstLevelFolder.SelectedValue = value3;

            cmbSecondLevelFolder.DataSource = new BindingSource(new Dictionary<FileData.FolderCreation, string>()
            {
                {FileData.FolderCreation.NOTHING, "Nothing"},
                {FileData.FolderCreation.CURRENT_IMAGE_FOLDER, "Current parent folder"},
                {FileData.FolderCreation.CAMERA, "Camera producer-model"},
                {FileData.FolderCreation.YEAR_MONTH, "Year-month (yyyy.mm)"},
                {FileData.FolderCreation.YEAR_MONTH_DAY, "Year-month-days (yyyy.mm.DD)"},
                {FileData.FolderCreation.ENTER, "Enter folder name"},
            }, null);
            cmbSecondLevelFolder.DisplayMember = "Value";
            cmbSecondLevelFolder.ValueMember = "Key";
            Enum.TryParse((string)Properties.Settings.Default["secondLevelFolder"], out FileData.FolderCreation value4);
            cmbSecondLevelFolder.SelectedValue = value4;

            cmbThirdLevelFolder.DataSource = new BindingSource(new Dictionary<FileData.FolderCreation, string>()
            {
                {FileData.FolderCreation.NOTHING, "Nothing"},
                {FileData.FolderCreation.CURRENT_IMAGE_FOLDER, "Current parent folder"},
                {FileData.FolderCreation.CAMERA, "Camera producer-model"},
                {FileData.FolderCreation.YEAR_MONTH, "Year-month (yyyy.mm)"},
                {FileData.FolderCreation.YEAR_MONTH_DAY, "Year-month-days (yyyy.mm.DD)"},
                {FileData.FolderCreation.ENTER, "Enter folder name"},
            }, null);
            cmbThirdLevelFolder.DisplayMember = "Value";
            cmbThirdLevelFolder.ValueMember = "Key";
            Enum.TryParse((string)Properties.Settings.Default["thirdLevelFolder"], out FileData.FolderCreation value5);
            cmbThirdLevelFolder.SelectedValue = value5;

            chkMove.Checked = (bool)Properties.Settings.Default["move"];
            chkIncludeSubfolders.Checked = (bool)Properties.Settings.Default["includeSubfolders"];
            chkFindCameraData.Checked = (bool)Properties.Settings.Default["findCameraData"];

            txtCustom1.Text = (string)Properties.Settings.Default["firstLevelFolderCustom"];
            txtCustom2.Text = (string)Properties.Settings.Default["secondLevelFolderCustom"];
            txtCustom3.Text = (string)Properties.Settings.Default["thirdLevelFolderCustom"];

            DestinationFolderExample(null, null);
        }

        private void BtnSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtSource.Text = fbd.SelectedPath;
            }
        }

        private void BtnDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtDestination.Text = fbd.SelectedPath;
            }
        }

        private void DestinationFolderExample(object sender, EventArgs e)
        {

            string destionationFolder = txtDestination.Text;

            if (string.IsNullOrEmpty(destionationFolder)) return;

            destionationFolder = CreateFolder(destionationFolder, (FileData.FolderCreation)cmbFirstLevelFolder.SelectedValue);
            destionationFolder = CreateFolder(destionationFolder, (FileData.FolderCreation)cmbSecondLevelFolder.SelectedValue);
            destionationFolder = CreateFolder(destionationFolder, (FileData.FolderCreation)cmbThirdLevelFolder.SelectedValue);

            string fileName = "IMAGE.jpg";

            switch ((FileData.FileRenameOptions)cmbRename.SelectedValue)
            {
                case FileData.FileRenameOptions.NO:
                    break;
                case FileData.FileRenameOptions.PARENT_FOLDER_PREFIX:
                    fileName = "current_folder-" + fileName;
                    break;
                case FileData.FileRenameOptions.TIMESTAMP:
                    fileName = "20141102235421.jpg";
                    break;
                default:
                    break;
            }

            textBox1.Text = destionationFolder + Path.DirectorySeparatorChar + fileName;

        }

        private string CreateFolder(string destionationFolder, FileData.FolderCreation folderCreation)
        {
            if (!folderCreation.Equals(FileData.FolderCreation.NOTHING))
            {

                String folder = "C:";
                switch (folderCreation)
                {
                    case FileData.FolderCreation.CAMERA:
                        folder = "PRODUCER-model";
                        break;
                    case FileData.FolderCreation.CURRENT_IMAGE_FOLDER:
                        folder = "current_folder";
                        break;
                    case FileData.FolderCreation.YEAR_MONTH:
                        folder = String.Format("{0:yyyy.MM}", DateTime.Now);
                        break;
                    case FileData.FolderCreation.YEAR_MONTH_DAY:
                        folder = String.Format("{0:yyyy.MM.dd}", DateTime.Now);
                        break;
                    case FileData.FolderCreation.ENTER:
                        folder = string.IsNullOrWhiteSpace(txtCustom1.Text) ? string.IsNullOrWhiteSpace(txtCustom2.Text) ? txtCustom3.Text : txtCustom2.Text : txtCustom1.Text;
                        break;
                    default:
                        break;
                }

                destionationFolder = destionationFolder + Path.DirectorySeparatorChar + folder.Trim();//.Replace("[^a-zA-Z0-9 \\.\\-]", "_");
            }

            return destionationFolder;
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {

            object o = SaveConfiguration();

            if (o != null)
            {
                //MessageBox.Show("Populate fields marked by *", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (o is TextBox)
                {
                    TextBox textBox = (TextBox)o;
                    Color color = textBox.BackColor;
                    Timer timer = new Timer();
                    timer.Interval = 100;
                    int count = 5;
                    
                    timer.Enabled = false;

                    timer.Start();
                    
                    timer.Tick += (x, y) =>
                    {
                        textBox.BackColor = textBox.BackColor == color ? Color.Red : color;
                        if (count-- == 0) timer.Stop();
                    };
                    return;
                }
                                
            }

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            FileProcessor fileProcessor = new FileProcessor();

            ProgressDialog dialog = new ProgressDialog(worker);

            worker.DoWork += fileProcessor.FindFiles;
            worker.RunWorkerCompleted += (x, y) => {                
                dialog.Close();
            };
            worker.RunWorkerAsync();

            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult == DialogResult.Abort) return;

            if (fileProcessor.Files != null || fileProcessor.Files.Count == 0)
            {

                worker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true,
                    WorkerReportsProgress = true
                };

                if(MessageBox.Show(fileProcessor.Files.Count + " files found. Do you want to continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;                

                dialog = new ProgressDialog(worker, fileProcessor.Files.Count);

                worker.DoWork += fileProcessor.ProcessFiles;
                worker.RunWorkerCompleted += (x, y) => {                    
                    dialog.Close();
                };
                worker.ProgressChanged += (x, y) => {
                    dialog.progressBar.Value = y.ProgressPercentage;
                };                    
                worker.RunWorkerAsync();

                
                dialogResult = dialog.ShowDialog(this);
                if (dialogResult == DialogResult.Abort) return;
                else if (MessageBox.Show("Open destination folder?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", txtDestination.Text);
                }
            }
            else
            {
                MessageBox.Show("No files found", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private object SaveConfiguration()
        {

            if (string.IsNullOrEmpty(txtSource.Text)) return txtSource;
            
            if (!new DirectoryInfo(txtSource.Text).Exists)
            {
                txtSource.Text = null;
                return txtSource;
            }

            Properties.Settings.Default["sourceFolder"] = txtSource.Text;

            if (string.IsNullOrEmpty(txtDestination.Text)) return txtDestination;

            if (!new DirectoryInfo(txtDestination.Text).Exists)
            {
                txtDestination.Text = null;
                return txtDestination;
            }

            if (cmbFirstLevelFolder.SelectedValue.Equals(FileData.FolderCreation.ENTER) && string.IsNullOrEmpty(txtCustom1.Text))
            {                
                return txtCustom1;
            }

            if (cmbSecondLevelFolder.SelectedValue.Equals(FileData.FolderCreation.ENTER) && string.IsNullOrEmpty(txtCustom2.Text))
            {
                return txtCustom2;
            }

            if (cmbThirdLevelFolder.SelectedValue.Equals(FileData.FolderCreation.ENTER) && string.IsNullOrEmpty(txtCustom3.Text))
            {
                return txtCustom3;
            }

            Properties.Settings.Default["destinationFolder"] = txtDestination.Text;
                        
            Properties.Settings.Default["exstensions"] = txtExtensions.Text;
            Properties.Settings.Default["renameOption"] = Enum.GetName(typeof(FileData.FileRenameOptions), cmbRename.SelectedValue);
            Properties.Settings.Default["fileNameExistsAction"] = Enum.GetName(typeof(FileData.FileNameExistsAction), cmbNameExists.SelectedValue);

            Properties.Settings.Default["firstLevelFolder"] = Enum.GetName(typeof(FileData.FolderCreation), cmbFirstLevelFolder.SelectedValue);
            Properties.Settings.Default["secondLevelFolder"] = Enum.GetName(typeof(FileData.FolderCreation), cmbSecondLevelFolder.SelectedValue);
            Properties.Settings.Default["thirdLevelFolder"] = Enum.GetName(typeof(FileData.FolderCreation), cmbThirdLevelFolder.SelectedValue);

            Properties.Settings.Default["firstLevelFolderCustom"] = txtCustom1.Text;
            Properties.Settings.Default["secondLevelFolderCustom"] = txtCustom2.Text;
            Properties.Settings.Default["thirdLevelFolderCustom"] = txtCustom3.Text;

            Properties.Settings.Default["move"] = chkMove.Checked;
            Properties.Settings.Default["includeSubfolders"] = chkIncludeSubfolders.Checked;
            Properties.Settings.Default["findCameraData"] = chkFindCameraData.Checked;

            Properties.Settings.Default.Save(); // Saves settings in application configuration file

            return null;
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            txtExtensions.Text = string.Join(",", FileData.EXTENSIONS);
        }

        private void TxtExtension_Validate(object sender, EventArgs e)
        {
            string[] extensions = txtExtensions.Text.Split(',');
            HashSet<string> uniqeValidExtensions = new HashSet<string>();
            foreach (string s in extensions)
            {
                if (IsFileExtensionValid(s)) uniqeValidExtensions.Add(s.Trim());
            }
            txtExtensions.Text = string.Join(",", uniqeValidExtensions);
        }

        private bool IsFileExtensionValid(string fExt)
        {

            fExt = fExt.Trim();

            if (!string.IsNullOrWhiteSpace(fExt))
            {
                char[] invalidFileChars = Path.GetInvalidFileNameChars();
                foreach (char c in invalidFileChars)
                {
                    if (fExt.Contains(c))
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void payPayDonationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/PavaoBabic");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/PavaoBabic");
        }

        private void btnCustom1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtCustom1.Text = fbd.SelectedPath;
            }
        }

        private void btnCustom2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtCustom2.Text = fbd.SelectedPath;
            }
        }

        private void btnCustom3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtCustom3.Text = fbd.SelectedPath;
            }
        }

        private void cmbFirstLevelFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue.Equals(FileData.FolderCreation.ENTER))
            {
                txtCustom1.Enabled = true;
            }
            else
            {
                txtCustom1.Enabled = false;
                txtCustom1.Text = null;
            }
                
        }

        private void cmbSecondLevelFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue.Equals(FileData.FolderCreation.ENTER))
            {
                txtCustom2.Enabled = true;
            }
            else
            {
                txtCustom2.Enabled = false;
                txtCustom2.Text = null;
            }
        }

        private void cmbThirdLevelFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue.Equals(FileData.FolderCreation.ENTER))
            {
                txtCustom3.Enabled = true;
            }
            else
            {
                txtCustom3.Enabled = false;
                txtCustom3.Text = null;
            }
        }

        private void txtCustom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s$_-]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void chkMove_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkbox = (CheckBox)sender;

            if ((checkbox).Checked)
            {
                if (MessageBox.Show("Choosing this option will move files from source folder to destination.\r\n\r\nAre you shure?", "Moving files", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    checkbox.Checked = false;
                }
            }
        }

    }

}
