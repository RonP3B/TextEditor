using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class TextEditorForm : Form
    {
        public TextEditorForm()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ofd.FileName);
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (.txt)|*.txt";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter newFile = new System.IO.StreamWriter(sfd.FileName);
                newFile.Write(richTextBox1.Text);
                newFile.Close();
            }
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void seleccionartodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            resetSelectionBackground();
        }

        private void changeFontSize(string font, int size)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = new Font(font, size);
        }

        private void resetSelectionBackground()
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
        }

        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 9);
        }

        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 12);
        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 15);
        }

        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 18);
        }

        private void pxToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 21);
        }

        private void pxToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            changeFontSize(richTextBox1.Font.Name, 24);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            resetSelectionBackground();
            string[] words = filtrarTxt.Text.Split(' ');

            foreach (string word in words)
            {
                int startIdx = 0;

                while (startIdx < richTextBox1.TextLength)
                {
                    int wordStartIdx = richTextBox1.Find(word, startIdx, RichTextBoxFinds.None);

                    if (wordStartIdx != -1)
                    {
                        richTextBox1.SelectionStart = wordStartIdx;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = Color.GreenYellow;
                    } else
                    {
                        break;
                    }

                    startIdx = wordStartIdx + word.Length;
                }
            }
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AcercaDe ad = new AcercaDe())
            {
                ad.ShowDialog();
            }
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = SystemColors.ActiveCaption;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
        }

        private void grisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = SystemColors.ControlDark;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
        }

        private void blancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = SystemColors.ButtonHighlight;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
        }
    }
}
