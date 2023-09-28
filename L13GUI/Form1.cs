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

namespace L13GUI
{
    public partial class Form1 : Form
    {
        string strSourceFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {

        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Files | *.txt";
                ofd.ShowDialog();

                strSourceFile = ofd.FileName;
                string strFileContents = File.ReadAllText(strSourceFile);
                tbxBody.Text = strFileContents;
            }
            catch (ArgumentException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message.ToString()), "Error");
            }
            
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(strSourceFile != null)
                {
                    string strTextToWrite = tbxBody.Text;
                    File.WriteAllText(@strSourceFile, strTextToWrite);
                }
                else
                {
                    mnuFileSaveAs.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message.ToString()), "Error");
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files | *.txt";
                sfd.ShowDialog();

                string strFileLocation = sfd.FileName;
                string strTextToWrite = tbxBody.Text;
                File.WriteAllText(@strFileLocation, strTextToWrite);
                strSourceFile = strFileLocation;
            }
            catch (ArgumentException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message.ToString()), "Error");
            }

        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my first Program\n\tSumanth", "About");
        }
    }
}
