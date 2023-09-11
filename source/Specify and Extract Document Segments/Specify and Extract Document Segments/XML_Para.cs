using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Specify_and_Extract_Document_Segments
{
    internal class XML_Para
    {
        public static String URL;
        public static int begin;
        public static int end;
        public static String t;
        public static int begin_text_pos;
        public static int end_text_pos;
        public static string Para(String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Paragraphs_In_WP.xsd";
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

                    if (xmlDoc.DocumentElement.Attributes["URL"] != null)
                    {
                        URL = xmlDoc.DocumentElement.Attributes["URL"].Value;
                        //Console.WriteLine(URL);
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

                    Ext_Para.paragraph(URL);
                    Console.WriteLine(begin);
                    Console.WriteLine(end);
                    if (begin != 0 && end != 0)
                    {
                        for (int i = begin; i <= end; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
                        }

                    }
                    else if (begin == 0 && end != 0)
                    {
                        for (int i = 1; i <= end; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
                        }
                    }
                    else if (begin != 0 && end == 0)
                    {
                        for (int i = begin; i <= Ext_Para.i; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
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
            //Console.WriteLine(t);
            return t;
        }
        public static string Para(String URL,String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Paragraphs_In_WP.xsd";
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

                    Ext_Para.paragraph(URL);
                    Console.WriteLine(begin);
                    Console.WriteLine(end);
                    if (begin != 0 && end != 0)
                    {
                        for (int i = begin; i <= end; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
                        }

                    }
                    else if (begin == 0 && end != 0)
                    {
                        for (int i = 1; i <= end; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
                        }
                    }
                    else if (begin != 0 && end == 0)
                    {
                        for (int i = begin; i <= Ext_Para.i; i++)
                        {
                            t += Ext_Para.text[i];
                            //Console.WriteLine(Ext_Para.text[i]);
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
            //Console.WriteLine(t);
            return t;
        }

        public static string Text_In_WP(String xmlString)
        {
            String schemapath = "..\\XSD\\Text_In_WP.xsd";
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

                    if (xmlDoc.DocumentElement.Attributes["URL"] != null)
                    {
                        URL = xmlDoc.DocumentElement.Attributes["URL"].Value;
                        URL = new Uri(URL).LocalPath;
                    }
                    foreach (XmlNode node in xmlDoc.DocumentElement)
                    {
                        Console.WriteLine(node.Name); //ir:Begin
                        if (node.Name == "ir:Begin")
                        {
                            begin = int.Parse(node.Attributes["paragraph_number"].Value);
                            begin_text_pos = int.Parse(node.Attributes["text_pos"].Value);
                            Console.WriteLine(begin);
                            Console.WriteLine(begin_text_pos);

                        }
                        else if (node.Name == "ir:End")
                        {
                            end = int.Parse(node.Attributes["paragraph_number"].Value);
                            end_text_pos = int.Parse(node.Attributes["text_pos"].Value);
                            Console.WriteLine(end);
                            Console.WriteLine(end_text_pos);
                        }
                    }


                    Ext_Para.text_in_paragraph(URL, begin, end, begin_text_pos, end_text_pos);
                    t = Ext_Para.t;


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
        public static string Text_In_WP(String URL,String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Text_In_WP.xsd";
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
                    
                    foreach (XmlNode node in xmlDoc.DocumentElement)
                    {
                        Console.WriteLine(node.Name); //ir:Begin
                        if (node.Name == "ir:Begin")
                        {
                            begin = int.Parse(node.Attributes["paragraph_number"].Value);
                            begin_text_pos = int.Parse(node.Attributes["text_pos"].Value);
                            Console.WriteLine(begin);
                            Console.WriteLine(begin_text_pos);

                        }
                        else if (node.Name == "ir:End")
                        {
                            end = int.Parse(node.Attributes["paragraph_number"].Value);
                            end_text_pos = int.Parse(node.Attributes["text_pos"].Value);
                            Console.WriteLine(end);
                            Console.WriteLine(end_text_pos);
                        }
                    }


                    Ext_Para.text_in_paragraph(URL, begin, end, begin_text_pos, end_text_pos);
                    t = Ext_Para.t;


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
