using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Specify_and_Extract_Document_Segments
{
    internal class XML_Table
    {
        public static String URL;
        public static int begin;
        public static int end;
        public static String t;
        public static int begin_row;
        public static int begin_col;
        public static int begin_p;
        public static int begin_text;
        public static int end_row;
        public static int end_col;
        public static int end_p;
        public static int end_text;
        public static string Table(String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Table_In_WP.xsd";
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.") 
            {
                begin = 0;
                end = 0;
                t = " ";
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlString);
                    //Console.WriteLine("Node Name: " + xmlDoc.DocumentElement.Name);
                    //Console.WriteLine("Node Value: " + xmlDoc.DocumentElement.InnerText);
                    if (xmlDoc.DocumentElement.Attributes["URL"] != null)
                    {
                        URL = xmlDoc.DocumentElement.Attributes["URL"].Value;
                        URL = new Uri(URL).LocalPath;
                        //Console.WriteLine(URL);
                    }
                    if (xmlDoc.DocumentElement.Attributes["begin"] != null)
                    {
                        begin = int.Parse(xmlDoc.DocumentElement.Attributes["begin"].Value);
                        //Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = int.Parse(xmlDoc.DocumentElement.Attributes["end"].Value);
                        //Console.WriteLine(end);
                    }

                    Ext_Table.Table(URL);
                    if (begin != 0 && end != 0)
                    {
                        for (int i = begin; i <= end; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }

                    }
                    else if (begin == 0 && end != 0)
                    {
                        for (int i = 1; i <= end; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }
                    }
                    else if (begin != 0 && end == 0)
                    {
                        for (int i = begin; i < Ext_Table.n_tbl; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }
                    }


                }
                catch (Exception ex)
                {
                    t = "XML parsing failed: " + ex.Message;
                    Console.WriteLine("XML parsing failed: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));
            }
            return t;
        }
        public static string Table_Text(String xmlString)
        {
            String schemapath = "..\\XSD\\Table_Text_In_WP.xsd"; 
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.") 
            {
                begin = 0;
                end = 0;
                t = " ";
                begin_row = 0;
                begin_col = 0;
                begin_p = 0;
                begin_text = 0;
                end_row = 0;
                end_col = 0;
                end_p = 0;
                end_text = 0;
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlString);
                    
                    if (xmlDoc.DocumentElement.Attributes["URL"] != null)
                    {
                        URL = xmlDoc.DocumentElement.Attributes["URL"].Value;
                        URL = new Uri(URL).LocalPath;
                        //Console.WriteLine(URL);
                    }
                    foreach (XmlNode node in xmlDoc.DocumentElement)
                    {
                        Console.WriteLine(node.Name); //ir:Begin
                        if (node.Name == "ir:Begin")
                        {
                           
                            begin = int.Parse(node.Attributes["table_number"].Value);
                            if (node.Attributes["row_number"] != null)
                            {
                                begin_row = int.Parse(node.Attributes["row_number"].Value);
                            }
                            if (node.Attributes["column_number"] != null)
                            {
                                begin_col = int.Parse(node.Attributes["column_number"].Value);
                            }

                            if (node.Attributes["p_number"] != null)
                            {
                                begin_p = int.Parse(node.Attributes["p_number"].Value);
                            }
                            if (node.Attributes["text_pos"] != null)
                            {
                                begin_text = int.Parse(node.Attributes["text_pos"].Value);
                            }
                            Console.WriteLine(begin);
                            Console.WriteLine(begin_row);
                            Console.WriteLine(begin_col);
                            Console.WriteLine(begin_p);
                            Console.WriteLine(begin_text);

                        }
                        else if (node.Name == "ir:End")
                        {
                            end = int.Parse(node.Attributes["table_number"].Value);
                            if (node.Attributes["row_number"] != null)
                            {
                                end_row = int.Parse(node.Attributes["row_number"].Value);
                            }
                            if (node.Attributes["column_number"] != null)
                            {
                                end_col = int.Parse(node.Attributes["column_number"].Value);
                            }

                            if (node.Attributes["p_number"] != null)
                            {
                                end_p = int.Parse(node.Attributes["p_number"].Value);
                            }
                            if (node.Attributes["text_pos"] != null)
                            {
                                end_text = int.Parse(node.Attributes["text_pos"].Value);
                            }
                            Console.WriteLine(end);
                            Console.WriteLine(end_row);
                            Console.WriteLine(end_col);
                            Console.WriteLine(end_p);
                            Console.WriteLine(end_text);
                        }
                    }
                    Ext_Table.Table(URL);
                    if (begin_col == 0 && begin_p == 0 && begin_text == 0 && end_col == 0 && end_p == 0 && end_text == 0) //T[1]TR[1-2] 
                    {
                        if (begin_row == 0 && begin_col == 0 && begin_p == 0 && begin_text == 0) //T[1]TR[-4]
                        {
                            if (begin < Ext_Table.n_tbl && end_row <= Ext_Table.table_tr[begin])
                            {
                                for (int i = 1; i <= end_row; i++)
                                {
                                    t += Ext_Table.tr[begin, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else if (end_row == 0) //T[1]TR[1-]
                        {
                            if (begin < Ext_Table.n_tbl && begin_row <= Ext_Table.table_tr[begin])
                            {
                                for (int i = begin_row; i <= Ext_Table.table_tr[begin]; i++)
                                {
                                    t += Ext_Table.tr[begin, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else //T[1]TR[1-2]
                        {
                            if (begin < Ext_Table.n_tbl && begin_row < end_row && end_row <= Ext_Table.table_tr[begin])
                            {
                                for (int i = begin_row; i <= end_row; i++)
                                {
                                    t += Ext_Table.tr[begin, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                    }
                    else if (begin_p == 0 && begin_text == 0 && end_p == 0 && end_text == 0) //T[1]TR[1]TC[1-2], T[1]TR[1]TC[-3], T[1]TR[1]TC[1-]
                    {
                        if (begin_col == 0) //T[1]TR[1]TC[-2]
                        {
                            if (begin < Ext_Table.n_tbl && end_col <= Ext_Table.table_tc[begin, end_col] && end_col <= Ext_Table.table_tr[begin])
                            {
                                for (int i = 1; i <= end_col; i++)
                                {
                                    t += Ext_Table.table_con[begin, end_col, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else if (end_col == 0) //T[1]TR[1]TC[1-]
                        {
                            if (begin < Ext_Table.n_tbl && begin_col <= Ext_Table.table_tc[begin, begin_col] && begin_col <= Ext_Table.table_tr[begin])
                            {
                                for (int i = begin_col; i <= Ext_Table.table_tc[begin, begin_col]; i++)
                                {
                                    t += Ext_Table.table_con[begin, begin_col, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                        else //T[1]TR[1]TC[1-2]
                        {
                            if (begin < Ext_Table.n_tbl && begin_col < end_col && end_col <= Ext_Table.table_tc[begin, begin_row] && begin_row <= Ext_Table.table_tr[begin])
                            {
                                for (int i = begin_col; i <= end_col; i++)
                                {
                                    t += Ext_Table.table_con[begin, begin_row, i];
                                }
                                Console.WriteLine(t);

                            }
                            else
                            {
                                Console.WriteLine("error!");
                            }
                        }
                    }
                    else //T[1]TR[1]TC[2]P[1]C[2]-P[2]C[3]
                    {
                        
                            t += Ext_Table.table_p[begin, begin_row, begin_col, begin_p].Substring(begin_text);

                            for (int i = begin_p + 1; i < end_p; i++)
                            {
                                t += Ext_Table.table_p[begin, begin_row, begin_col, i];
                            }
                            t += Ext_Table.table_p[begin, begin_row, begin_col, begin_p].Substring(0, end_p);
                            Console.WriteLine(t);
                        
                    }

                }
                catch (Exception ex)
                {
                    t = "XML parsing failed: " + ex.Message;
                    Console.WriteLine("XML parsing failed: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));
            }
            return t;
        }
        public static string Table(String URL, String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Table_In_WP.xsd";
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.")
            {
                begin = 0;
                end = 0;
                t = " ";
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlString);
                    //Console.WriteLine("Node Name: " + xmlDoc.DocumentElement.Name);
                    //Console.WriteLine("Node Value: " + xmlDoc.DocumentElement.InnerText);

                    if (xmlDoc.DocumentElement.Attributes["begin"] != null)
                    {
                        begin = int.Parse(xmlDoc.DocumentElement.Attributes["begin"].Value);
                        //Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = int.Parse(xmlDoc.DocumentElement.Attributes["end"].Value);
                        //Console.WriteLine(end);
                    }

                    Ext_Table.Table(URL);
                    if (begin != 0 && end != 0)
                    {
                        t = "";
                        for (int i = begin; i <= end; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }

                    }
                    else if (begin == 0 && end != 0)
                    {
                        t = "";
                        for (int i = 1; i <= end; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }
                    }
                    else if (begin != 0 && end == 0)
                    {
                        t = "";
                        for (int i = begin; i <= Ext_Para.i; i++)
                        {
                            t += Ext_Table.table_c[i] + "\n";
                        }
                    }


                }
                catch (Exception ex)
                {
                    t = "XML parsing failed: " + ex.Message;
                    Console.WriteLine("XML parsing failed: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(Vali_XML.XmlValidateByXsd(xmlString, schemapath));
            }
            return t;
        }
    }
}
