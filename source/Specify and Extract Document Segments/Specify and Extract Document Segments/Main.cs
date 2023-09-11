using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Specify_and_Extract_Document_Segments
{
    public partial class Main : Form
    {
        public static String text = "";
        public static String filepath = "";
        public static String filename = "";
        XML xml = new XML();
        Regular reg = new Regular();
        Help help = new Help();

        public Main()
        {
            InitializeComponent();
        }

        //Select file
        private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                filepath = f.FileName;
                filename = f.SafeFileName;
                label1.Text = "Open File: " + filepath;
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xml.ShowDialog();
        }

        public string file_path
        {
            get { return filepath; }
            set { filepath = value; }

        }

        private void regularExpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reg.ShowDialog();
        }

        private void othersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ownership: Wang Yongxuan" + "\n" + "Version: 1.0.0");
        }

        private void hlepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help.ShowDialog();
        }
    }
}
