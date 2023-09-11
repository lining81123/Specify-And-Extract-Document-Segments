using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specify_and_Extract_Document_Segments
{
    internal class Ext_Para
    {
        public static int i;
        public static String[] text = new string[10000];
        public static String t;

        public static String single_paragraph(String path, int p)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(path);

            t = doc.Paragraphs[p].Range.Text.Trim();
            //Console.WriteLine(t);
           
            doc.Close();
            app.Quit();
            return t;
        }
        public static String paragraph(String path)
        {
            i = 1;
            Application app = new Application();
            Document doc = app.Documents.Open(path);
            
            foreach (Paragraph paragraph in doc.Paragraphs)
            {
                text[i] = paragraph.Range.Text;
                i++;
            }

            doc.Close();
            app.Quit();
            return text[i];
        }

        public static String text_in_paragraph(String path, int p, int startCharPos, int endCharPos)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(path);

            String p_text = doc.Paragraphs[p].Range.Text.Trim();
            t = p_text.Substring(startCharPos, endCharPos - startCharPos + 1);

            doc.Close();
            app.Quit();
            return t;
        }
        public static void text_in_paragraph(String path, int p_start, int p_end, int startCharPos, int endCharPos)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(path);

            String p_text_start = doc.Paragraphs[p_start].Range.Text.Trim();
            t += p_text_start.Substring(startCharPos);

            for (int i = p_start + 1; i < p_end; i++)
            {
                t += doc.Paragraphs[i].Range.Text.Trim();
            }

            String p_text_end = doc.Paragraphs[p_end].Range.Text.Trim();
            t += p_text_end.Substring(0, endCharPos);

            //Console.WriteLine(t);

            doc.Close();
            app.Quit();
        }
    }
}
