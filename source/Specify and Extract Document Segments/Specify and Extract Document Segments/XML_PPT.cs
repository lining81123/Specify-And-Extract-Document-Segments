using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Specify_and_Extract_Document_Segments
{
    internal class XML_PPT
    {
        public static String URL;
        public static int begin;
        public static int end;
        public static String t;
        public static string PPT(String xmlString)
        {
            String schemapath = @"E:\VS\Ext_loc_Inf\Ext_loc_Inf\XSD\Slide_In_Presentation.xsd";
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.")
            {
                begin = 1;
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
                        //Console.WriteLine(URL);
                    }
                    if (xmlDoc.DocumentElement.Attributes["begin"] != null)
                    {
                        begin = int.Parse(xmlDoc.DocumentElement.Attributes["begin"].Value);
                        Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = int.Parse(xmlDoc.DocumentElement.Attributes["end"].Value);
                        Console.WriteLine(end);
                    }


                    if (end != 0)
                    {
                        for (int i = begin; i <= end; i++)
                        {
                            //Console.WriteLine(i);
                            Ext_PPT.text(URL, i);
                            t += Ext_PPT.t;
                            Console.WriteLine(t);
                        }
                    }
                    else if (end == 0)
                    {
                        for (int i = 1; i <= Ext_PPT.Slide_Count(URL); i++)
                        {
                            Ext_PPT.text(URL, i);
                            t += Ext_PPT.t;
                            //Console.WriteLine(t);
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
        public static string PPT(String URL, String xmlString)
        {
            String schemapath = "..\\XSD\\Slide_In_Presentation.xsd";
            if (Vali_XML.XmlValidateByXsd(xmlString, schemapath) == "XML validation succeeded.") 
            {
                begin = 1;
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
                        Console.WriteLine(begin);

                    }
                    if (xmlDoc.DocumentElement.Attributes["end"] != null)
                    {
                        end = int.Parse(xmlDoc.DocumentElement.Attributes["end"].Value);
                        Console.WriteLine(end);
                    }


                    if (end != 0)
                    {
                        for (int i = begin; i <= end; i++)
                        {
                            //Console.WriteLine(i);
                            Ext_PPT.text(URL, i);
                            t += Ext_PPT.t;
                            Console.WriteLine(t);
                        }
                    }
                    else if (end == 0)
                    {
                        for (int i = 1; i <= Ext_PPT.Slide_Count(URL); i++)
                        {
                            Ext_PPT.text(URL, i);
                            t += Ext_PPT.t;
                            //Console.WriteLine(t);
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
