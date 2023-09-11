using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Office.Interop.Excel;

namespace Specify_and_Extract_Document_Segments
{
    internal class XML_Excel
    {
        public static String URL;
        public static String sheet;
        public static string begin;
        public static string end;
        public static String t;
        public static string Excel(String xmlString)
        {
            String schemapath = "..\\XSD\\Cell_In_SS.xsd";
            
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
                    if (xmlDoc.DocumentElement.Attributes["sheet"] != null)
                    {
                        sheet = xmlDoc.DocumentElement.Attributes["sheet"].Value;
                        //Console.WriteLine(sheet);

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


                    Ext_Excel.excel(URL, sheet, begin, end);
                    t = Ext_Excel.t;
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

        public static string Excel(String URL, String xmlString)
        {
            String schemapath = @"E:\VS\Reg_Exp\Reg_Exp\XSD\Cell_In_SS.xsd";
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


                    if (xmlDoc.DocumentElement.Attributes["sheet"] != null)
                    {
                        sheet = xmlDoc.DocumentElement.Attributes["sheet"].Value;
                        //Console.WriteLine(sheet);

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


                    Ext_Excel.excel(URL, sheet, begin, end);
                    t = Ext_Excel.t;
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
