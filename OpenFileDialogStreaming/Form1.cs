using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenFileDialogStreaming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Clear();

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            OpenFileDialog Open = new OpenFileDialog();
            Open.ShowDialog();
            StreamReader read = new StreamReader(Open.FileName);
            string line = read.ReadLine();
            while (line != null)
            {
                richTextBox1.AppendText(line + "\n");
                line = read.ReadLine();
            }

            read.Close();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            int K = 0;
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter write = new StreamWriter(save.FileName);
            write.WriteLine(DateTime.Now.ToString());
            string line;
            while(K < richTextBox1.Lines.Count())
            {
                line = richTextBox1.Lines[K];
                write.WriteLine(line);
                K++;
            }
            write.Close();
            

            

        }
    }
}
