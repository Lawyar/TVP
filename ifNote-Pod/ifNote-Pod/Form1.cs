using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ifNote_Pod
{
    public partial class Form1 : Form
    {
        string currentFile;

        public Form1()
        {
            InitializeComponent();
            currentFile = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)//open
        {
            openfile();
        }

        private void openfile()
        {
            OpenFileDialog openfilee = new OpenFileDialog();

            openfilee.InitialDirectory = "c:\\";
            openfilee.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openfilee.FilterIndex = 2;
            openfilee.RestoreDirectory = true;

            if(openfilee.ShowDialog() == DialogResult.OK)
            {
                currentFile = openfilee.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(currentFile);

                richTextBox1.Text = sr.ReadToEnd();
                this.Text = currentFile + " Notepad";
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            if (currentFile == null)
                return;
            
            System.IO.StreamWriter wr = new System.IO.StreamWriter(currentFile);

            

            wr.Write(richTextBox1.Text);
            wr.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void saveAs()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveFileDialog1.FileName;
                this.Text = currentFile + " Notepad";
                saveFile();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void newFile()
        {
            if (currentFile != null)
                saveFile();
            else
                saveAs();

            richTextBox1.Text = "";
            currentFile = null;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            int linesnum = richTextBox1.Lines.Length;

            
            toolStripStatusLabel3.Text = linesnum.ToString();
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel5.Text = richTextBox1.Text.Length.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powered by NotAMicroSoft.co\nemail:tychinin554@gmail.com");
        }
    }
}
