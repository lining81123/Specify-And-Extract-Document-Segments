using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Specify_and_Extract_Document_Segments
{
    internal class Ext_Table
    {
        public static int n_tbl;
        public static int n_tr;
        public static int n_tc;
        public static int n;
        public static String[] table_c = new String[1000]; //table
        public static int[] table_tr = new int[1000]; //row
        public static int[,] table_tc = new int[1000, 1000]; //column
        public static String[,,] table_con = new String[100, 100, 100]; //table, row, column
        public static String[,,,] table_p = new String[100, 100, 100, 100]; //table, row, column，paragraph
        public static String[,] tr = new String[1000, 1000]; //table, row

        public static void Table(String filepath)
        {
            //.docx - .zip
            String fileName = Path.ChangeExtension(filepath, ".zip"); //@"C:\Users\HP\Desktop\1.zip"
            File.Move(filepath, fileName);

            //path = @"C:\Users\HP\Desktop\1"
            String path = filepath.Substring(0, filepath.IndexOf(".docx"));

            Decompress(fileName, path);
            File.Move(path + @".zip", Path.ChangeExtension(fileName, ".docx"));

            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(path + @"\word\document.xml");


            XmlElement root2 = xml_doc.DocumentElement;
            string nameSpace2 = root2.NamespaceURI;
            XmlNamespaceManager nsmgr2 = new XmlNamespaceManager(xml_doc.NameTable);
            nsmgr2.AddNamespace("w", nameSpace2);

            XmlNode root_doc = xml_doc.SelectSingleNode("w:document/w:body", nsmgr2);
            n_tbl = 1;
            foreach (XmlNode node in root_doc)
            {

                if (node.Name == "w:tbl")
                {
                    //Console.WriteLine("w:tbl:" + n_tbl);
                    n_tr = 1;
                    table_c[n_tbl] = node.InnerText;
                    foreach (XmlNode node1 in node.ChildNodes)
                    {

                        if (node1.Name == "w:tr")
                        {
                            //Console.WriteLine("w:tr:" + n_tr);
                            n_tc = 1;
                            tr[n_tbl, n_tr] = node1.InnerText;
                            table_tr[n_tbl] = n_tr;

                            //Console.WriteLine("[" + n_tbl + "," + n_tr + "]" + node1.InnerText);
                            foreach (XmlNode node2 in node1.ChildNodes)
                            {
                                if (node2.Name == "w:tc")
                                {
                                    //Console.WriteLine("w:tc:" + n_tc);
                                    table_con[n_tbl, n_tr, n_tc] = node2.InnerText;
                                    //Console.WriteLine(n_tbl + ":" + n_tr + ":" + n_tc + ":" + table_con[n_tbl, n_tr, n_tc]);
                                    table_tc[n_tbl, n_tr] = n_tc;
                                    n = 1;
                                    foreach (XmlNode node3 in node2.ChildNodes)
                                    {
                                        if (node3.Name == "w:p")
                                        {
                                            //Console.WriteLine("w:p : " + n);
                                            table_p[n_tbl, n_tr, n_tc, n] = node3.InnerText;
                                            //Console.WriteLine(n_tbl + ":" + n_tr + ":" + n_tc + ":" + n + ":" + table_p[n_tbl, n_tr, n_tc, n]);
                                            n++;
                                        }
                                    }
                                    //Console.WriteLine("[" + "," + n_tr + "," + n_tc + "]" + node2.InnerText);

                                    n_tc++;
                                }

                            }
                            n_tr++;
                        }
                    }
                    n_tbl++;
                }

            }

        }
        public static void Decompress(string sourceFile, string targetPath)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException(string.Format("未能找到文件 '{0}' ", sourceFile));
            }
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directorName = System.IO.Path.Combine(targetPath, System.IO.Path.GetDirectoryName(theEntry.Name));
                    string fileName = System.IO.Path.Combine(directorName, System.IO.Path.GetFileName(theEntry.Name));
                   
                    if (directorName.Length > 0)
                    {
                        System.IO.Directory.CreateDirectory(directorName);
                    }
                    if (fileName != string.Empty)
                    {
                        using (FileStream streamWriter = File.Create(fileName))
                        {
                            int size = 4096;
                            byte[] data = new byte[4 * 1024];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else break;
                            }
                        }
                    }
                }
            }
        }

    }
}
