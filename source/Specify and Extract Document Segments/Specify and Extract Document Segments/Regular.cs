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
    public partial class Regular : Form
    {
        public static String text = "";
        public static String filepath = "";
        public Regular()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
            Console.WriteLine(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text.Contains("//") == true) //path in regular expression
            {
                filepath = text.Substring(text.IndexOf("//") + 2, text.IndexOf(">") - text.IndexOf("//") - 2);
                filepath = filepath.Replace("/", "\\");
                label2.Text = "Open file: " + filepath;

                if (text.Substring(0, 2) == "PG") //OFD
                {
                    Ofd_Object.ofd(filepath, text);
                    richTextBox1.Text = Ofd_Object.t;


                }
                else if (text.Substring(0, 1) == "P") //paragraph
                {
                    Ext_Text.P_Text(filepath, text);
                    richTextBox1.Text = Ext_Text.t;

                }
                else if (text.Substring(0, 2) == "SL") //PPT
                {
                    PPT_Text.PPT_T(filepath, text);
                    richTextBox1.Text = PPT_Text.t;
                }
                else if (text.Substring(0, 1) == "S") //excel
                {
                    Ext_Excel.excel(filepath, text);
                    richTextBox1.Text = Ext_Excel.t;
                }
                else if (text.Substring(0, 1) == "T") //table
                {

                    Table_Text.Table_T(filepath, text);
                    richTextBox1.Text = Table_Text.t;
                }
            }
            else //没有路径
            {
                Main f1 = new Main();
                String s = f1.file_path;
                label2.Text = "Open file: " + s;

                if (text.Substring(0, 2) == "PG") //OFD
                {
                    Ofd_Object.ofd(s, text);
                    richTextBox1.Text = Ofd_Object.t;

                }
                else if (text.Substring(0, 1) == "P") //paragraph
                {
                    Ext_Text.P_Text(s, text);
                    richTextBox1.Text = Ext_Text.t;

                }
                else if (text.Substring(0, 2) == "SL") //PPT
                {
                    PPT_Text.PPT_T(s, text);
                    richTextBox1.Text = PPT_Text.t;
                }
                else if (text.Substring(0, 1) == "S") //excel
                {
                    Ext_Excel.excel(s, text);
                    richTextBox1.Text = Ext_Excel.t;
                }
                else if (text.Substring(0, 1) == "T") //table
                {

                    Table_Text.Table_T(s, text);
                    richTextBox1.Text = Table_Text.t;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Regular_Load(object sender, EventArgs e)
        {

        }
    }
}
