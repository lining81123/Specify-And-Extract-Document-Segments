using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Specify_and_Extract_Document_Segments
{
    internal class XML_OFD
    {
        public static String URL;
        public static String sheet;
        public static string begin;
        public static string begin_object;
        public static string end_object;
        public static string end;
        public static String t;

        public static string OFD_Page(String xmlString)
        {
            String schemapath = "..\\XSD\\Pages_In_FLD.xsd";

            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.") 
            {
                begin = " ";
                end = " ";
                sheet = " ";
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
                        //Console.WriteLine(URL);
                    }
                    if (xmlDoc.DocumentElement.Attributes["begin"] != null)
                    {
                        begin = xmlDoc.DocumentElement.Attributes["begin"].Value;
                        //Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = xmlDoc.DocumentElement.Attributes["end"].Value;
                        //Console.WriteLine(end);
                    }
                    for (int page = int.Parse(begin); page <= int.Parse(end);page++)
                    {
                        Ext_Ofd.parse(URL,page);
                        t += Ext_Ofd.t;
                    }
                    
                    Console.WriteLine(t);


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

        public static string OFD_Object(String xmlString)
        {
            String schemapath = "..\\XSD\\Object_In_FLD.xsd";

            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.")
            {
                begin = " ";
                end = " ";
                sheet = " ";
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
                        //Console.WriteLine(URL);
                    }
                    foreach (XmlNode node in xmlDoc.DocumentElement)
                    {
                        Console.WriteLine(node.Name); //ir:Begin
                        if (node.Name == "ir:Begin")
                        {
                            begin = node.Attributes["page_number"].Value;
                            begin_object = node.Attributes["object_pos"].Value;
                            Console.WriteLine(begin);
                            Console.WriteLine(begin_object);

                        }
                        else if (node.Name == "ir:End")
                        {
                            end = node.Attributes["page_number"].Value;
                            end_object = node.Attributes["object_pos"].Value;
                            Console.WriteLine(end);
                            Console.WriteLine(end_object);
                        }
                    }

                    if (begin == end)
                    {
                        if (begin_object == end_object)
                        {
                            Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object), int.Parse(end_object));
                            t += Ext_Ofd.t;
                        }
                        else
                        {
                            Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object), int.Parse(end_object));
                            t += Ext_Ofd.t;
                        }
                        
                    }
                    else
                    {
                        Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object));
                        t += Ext_Ofd.t;
                        for (int page = int.Parse(begin) + 1; page < int.Parse(end); page++)
                        {
                            Ext_Ofd.parse(URL, page);
                            t += Ext_Ofd.t;
                        }
                        Ext_Ofd.parse(URL,0,int.Parse(end_object));
                        t += Ext_Ofd.t;
                    }

                    

                    Console.WriteLine(t);


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

        public static string OFD_Object(String URL, String xmlString)
        {
            String schemapath = "..\\XSD\\Object_In_FLD.xsd";

            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.") 
            {
                begin = " ";
                end = " ";
                sheet = " ";
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
                            begin = node.Attributes["page_number"].Value;
                            begin_object = node.Attributes["object_pos"].Value;
                            Console.WriteLine(begin);
                            Console.WriteLine(begin_object);

                        }
                        else if (node.Name == "ir:End")
                        {
                            end = node.Attributes["page_number"].Value;
                            end_object = node.Attributes["object_pos"].Value;
                            Console.WriteLine(end);
                            Console.WriteLine(end_object);
                        }
                    }

                    if (begin == end)
                    {
                        if (begin_object == end_object)
                        {
                            Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object), int.Parse(end_object));
                            t += Ext_Ofd.t;
                        }
                        else
                        {
                            Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object), int.Parse(end_object));
                            t += Ext_Ofd.t;
                        }

                    }
                    else
                    {
                        Ext_Ofd.parse(URL, int.Parse(begin), int.Parse(begin_object));
                        t += Ext_Ofd.t;
                        for (int page = int.Parse(begin) + 1; page < int.Parse(end); page++)
                        {
                            Ext_Ofd.parse(URL, page);
                            t += Ext_Ofd.t;
                        }
                        Ext_Ofd.parse(URL, 0, int.Parse(end_object));
                        t += Ext_Ofd.t;
                    }



                    Console.WriteLine(t);


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
        public static string OFD_Page(String URL, String xmlString)
        {
            String schemapath = @"E:\VS\Reg_Exp\Reg_Exp\XSD\Cell_In_SS.xsd";
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.")
            {
                begin = " ";
                end = " ";
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
                        //Console.WriteLine(URL);
                    }
                    if (xmlDoc.DocumentElement.Attributes["begin"] != null)
                    {
                        begin = xmlDoc.DocumentElement.Attributes["begin"].Value;
                        //Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = xmlDoc.DocumentElement.Attributes["end"].Value;
                        //Console.WriteLine(end);
                    }
                    for (int page = int.Parse(begin); page <= int.Parse(end); page++)
                    {
                        Ext_Ofd.parse(URL, page);
                        t += Ext_Ofd.t;
                    }
                    Console.WriteLine(t);



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
