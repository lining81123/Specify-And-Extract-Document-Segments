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
    public partial class XML : Form
    {
        public static String text = "";
        public XML()
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
            if (text.Contains("///") == true) //XML have path
            {

                if (text.Contains("Paragraphs_In_WP"))
                {
                    XML_Para.Para(text);
                    label2.Text = "Open file: " + XML_Para.URL;
                    richTextBox1.Text = XML_Para.t;

                }
                else if (text.Contains("Table_Text_In_WP"))
                {
                    XML_Table.Table_Text(text);
                    label2.Text = "Open file: " + XML_Table.URL;
                    richTextBox1.Text = XML_Table.t;
                }
                else if (text.Contains("Text_In_WP"))
                {
                    XML_Para.Text_In_WP(text);
                    label2.Text = "Open file: " + XML_Para.URL;
                    richTextBox1.Text = XML_Para.t;
                }
                else if (text.Contains("Table_In_WP"))
                {
                    XML_Table.Table(text);
                    label2.Text = "Open file: " + XML_Table.URL;
                    richTextBox1.Text = XML_Table.t;
                }

                else if (text.Contains("Cell_In_SS"))
                {
                    XML_Excel.Excel(text);
                    label2.Text = "Open file: " + XML_Excel.URL;
                    richTextBox1.Text = XML_Excel.t;
                }
                else if (text.Contains("Slide_In_Presentation"))
                {
                    XML_PPT.PPT(text);
                    label2.Text = "Open file: " + XML_PPT.URL;
                    richTextBox1.Text = XML_PPT.t;
                }
                else if (text.Contains("Pages_In_FLD"))
                {
                    XML_OFD.OFD_Page(text);
                    label2.Text = "Open file: " + XML_OFD.URL;
                    richTextBox1.Text = XML_OFD.t;
                }
                else if (text.Contains("Object_In_FLD"))
                {
                    XML_OFD.OFD_Object(text);
                    label2.Text = "Open file: " + XML_OFD.URL;
                    richTextBox1.Text = XML_OFD.t;
                }
            }
            else
            {
                Main f1 = new Main();
                String s = f1.file_path;
                label2.Text = "Open file: " + s;
                if (text.Contains("Paragraphs_In_WP"))
                {
                    XML_Para.Para(s, text);
                    richTextBox1.Text = XML_Para.t;
                }
                else if (text.Contains("Text_In_WP"))
                {
                    XML_Para.Text_In_WP(s, text);
                    richTextBox1.Text = XML_Para.t;
                }
                else if (text.Contains("Table_In_WP"))
                {
                    XML_Table.Table(s, text);
                    richTextBox1.Text = XML_Table.t;
                }
                else if (text.Contains("Table_Text_In_WP"))
                {
                    XML_Table.Table_Text(text);
                    richTextBox1.Text = XML_Table.t;
                }
                else if (text.Contains("Cell_In_SS"))
                {
                    XML_Excel.Excel(s, text);
                    richTextBox1.Text = XML_Excel.t;
                }
                else if (text.Contains("Slide_In_Presentation"))
                {
                    XML_PPT.PPT(s, text);
                    richTextBox1.Text = XML_PPT.t;
                }
                else if (text.Contains("Pages_In_FLD"))
                {
                    XML_OFD.OFD_Page(s, text);
                    richTextBox1.Text = XML_OFD.t;
                }
                else if (text.Contains("Object_In_FLD"))
                {
                    XML_OFD.OFD_Object(s, text);
                    richTextBox1.Text = XML_OFD.t;

                }
            }
        }
    }
}
