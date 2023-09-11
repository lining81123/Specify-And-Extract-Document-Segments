using System;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace Specify_and_Extract_Document_Segments
{
    internal class Ext_Excel
    {
        public static String t = "";
        public static void excel(String path, String text)
        {
            String sheetName = text.Substring(text.IndexOf("\"") + 1, text.IndexOf("\"!") - text.IndexOf("\"") - 1);
            String startCell = "";
            String endCell = "";
            String cell = "";
            

            if (Regular_Exp.Spreadsheet(text) == true)
            {
                Application excel = new Application();
                Workbook wb = excel.Application.Workbooks.Open(path);
                Worksheet worksheet = (Worksheet)wb.Worksheets[sheetName];
                text = RemoveBetweenSymbols(text, '<', '>');

                if (text.Contains(":") == true)
                {
                    t = "";
                    startCell = text.Substring(text.IndexOf("!") + 1, text.IndexOf(":") - text.IndexOf("!") - 1);
                    Console.WriteLine("startCell:" + startCell);
                    endCell = text.Substring(text.IndexOf(":") + 1);
                    Console.WriteLine("endCell:" + endCell);

                    Range range = worksheet.Range[startCell, endCell];

                    foreach (Range r in range)
                    {
                        t += r.Value2.ToString();
                        Console.WriteLine(t);
                    }

                }
                else
                {
                    t = "";
                    cell = text.Substring(text.IndexOf("!") + 1);
                    Range range = worksheet.Range[cell];
                    t = range.Value2.ToString();
                    Console.WriteLine(t);
                }

                wb.Close();
                excel.Quit();
            }
            else
            {
                t = "error！！！";
                Console.WriteLine("error！！！");
            }
        }
        public static void excel(string path, string sheetname, string begin, string end)
        {

            Application excel = new Application();
            Workbook wb = excel.Application.Workbooks.Open(path);
            Worksheet worksheet = (Worksheet)wb.Worksheets[sheetname];



            Range range = worksheet.Range[begin, end];

            foreach (Range r in range)
            {
                t += r.Value2.ToString();
                //Console.WriteLine(t);
            }

            wb.Close();
            excel.Quit();
        }
        public static string RemoveBetweenSymbols(string originalString, char startSymbol, char endSymbol)
        {
            string pattern = string.Format("{0}.*?{1}", Regex.Escape(startSymbol.ToString()), Regex.Escape(endSymbol.ToString()));
            string removedString = Regex.Replace(originalString, pattern, string.Empty);
            return removedString;
        }
    }
}
