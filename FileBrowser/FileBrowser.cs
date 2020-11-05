using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class FileBrowser : Form
    {
        List<string> ListFiles = new List<string>();
        public FileBrowser()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ListFiles.Clear();
            listView.Items.Clear();

            using (FolderBrowserDialog fdb = new FolderBrowserDialog() { Description = "please select your folder" })
            {
                if (fdb.ShowDialog() == DialogResult.OK)

                {
                    txtPath.Text = fdb.SelectedPath;
                    foreach (string item in Directory.GetFiles(fdb.SelectedPath))
                    {
                        imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        FileInfo fi = new FileInfo(item);
                        ListFiles.Add(fi.FullName);
                        listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                    }
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
