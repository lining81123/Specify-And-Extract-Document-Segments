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
    internal class Ext_Ofd
    {
        public static string t;
        public static string[] o = new string[1000];
        public static int n;
        public static int page;
        public static int page_num(string filepath)
        {
            //.ofd - .zip
            String fileName = Path.ChangeExtension(filepath, ".zip"); //@"C:\Users\HP\Desktop\1.zip"
            File.Move(filepath, fileName);

            //path = @"C:\Users\HP\Desktop\1"
            String path = filepath.Substring(0, filepath.IndexOf(".ofd"));

           
            Decompress(fileName, path);
            File.Move(path + @".zip", Path.ChangeExtension(fileName, ".ofd"));

            
            for (page = 0; ;page++)
            {
                bool exist = File.Exists(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");
                if (exist)
                {
                    
                }
                else
                {
                    break;
                }
            }
            
            return page;
        }
        public static string parse(string filepath, int page, int start_object, int end_object)
        {
            //.ofd - .zip
            String fileName = Path.ChangeExtension(filepath, ".zip"); //@"C:\Users\HP\Desktop\1.zip"
            File.Move(filepath, fileName);

            //path = @"C:\Users\HP\Desktop\1"
            String path = filepath.Substring(0, filepath.IndexOf(".ofd"));

            
            Decompress(fileName, path);
            File.Move(path + @".zip", Path.ChangeExtension(fileName, ".ofd"));

            bool exist = File.Exists(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");
            if (exist)
            {
                XmlDocument xml_ofd = new XmlDocument();
                xml_ofd.Load(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");

                XmlElement root = xml_ofd.DocumentElement;
                string nameSpace = root.NamespaceURI;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml_ofd.NameTable);
                nsmgr.AddNamespace("ofd", nameSpace);

                //根节点
                XmlNode root_doc = xml_ofd.SelectSingleNode("ofd:Page/ofd:Content/ofd:Layer", nsmgr);

                n = 0;
                foreach (XmlNode node in root_doc)
                {
                    if (node.Name == "ofd:TextObject")
                    {
                        o[n] = node.InnerText;
                        //Console.WriteLine(node.InnerText);
                    }else
                    {
                        o[n] = " ";
                    }
                    n++;
                }
                
            }
            t = "";
            for (int i = start_object; i <= end_object; i++)
            {
                t += o[i] + ", ";
            }
            return t;



        }
        public static string parse(string filepath, int page, int start_object)
        {
            
            String fileName = Path.ChangeExtension(filepath, ".zip"); //@"C:\Users\HP\Desktop\1.zip"
            File.Move(filepath, fileName);

            //path = @"C:\Users\HP\Desktop\1"
            String path = filepath.Substring(0, filepath.IndexOf(".ofd"));

            
            Decompress(fileName, path);
            File.Move(path + @".zip", Path.ChangeExtension(fileName, ".ofd"));

            bool exist = File.Exists(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");
            if (exist)
            {
                XmlDocument xml_ofd = new XmlDocument();
                xml_ofd.Load(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");

                XmlElement root = xml_ofd.DocumentElement;
                string nameSpace = root.NamespaceURI;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml_ofd.NameTable);
                nsmgr.AddNamespace("ofd", nameSpace);

                
                XmlNode root_doc = xml_ofd.SelectSingleNode("ofd:Page/ofd:Content/ofd:Layer", nsmgr);

                n = 0;
                foreach (XmlNode node in root_doc)
                {
                    if (node.Name == "ofd:TextObject")
                    {
                        o[n] = node.InnerText;
                        Console.WriteLine(o[n]);
                    }
                    else
                    {
                        o[n] = " ";
                        Console.WriteLine(o[n]);
                    }
                    n++;
                }

            }
            t = "";
            for (int i = start_object; i < n; i++)
            {
                t += o[i] + ", ";
                
            }
            Console.WriteLine(t);
            return t;



        }

        public static string parse(string filepath, int page)
        {
            //.ofd - .zip
            String fileName = Path.ChangeExtension(filepath, ".zip"); //@"C:\Users\HP\Desktop\1.zip"
            File.Move(filepath, fileName);

            //path = @"C:\Users\HP\Desktop\1"
            String path = filepath.Substring(0, filepath.IndexOf(".ofd"));

           
            Decompress(fileName, path);
            File.Move(path + @".zip", Path.ChangeExtension(fileName, ".ofd"));

            bool exist = File.Exists(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");
            if (exist)
            {
                XmlDocument xml_ofd = new XmlDocument();
                xml_ofd.Load(path + @"\Doc_0\Pages\Page_" + page + @"\Content.xml");

                XmlElement root = xml_ofd.DocumentElement;
                string nameSpace = root.NamespaceURI;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml_ofd.NameTable);
                nsmgr.AddNamespace("ofd", nameSpace);

                
                XmlNode root_doc = xml_ofd.SelectSingleNode("ofd:Page/ofd:Content/ofd:Layer", nsmgr);

                n = 0;
                t = "";
                foreach (XmlNode node in root_doc)
                {

                    if (node.Name == "ofd:TextObject")
                    {
                        t += node.InnerText + ", ";
                    }
                    
                    n++;
                }

            }
            
            return t;



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
