using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Specify_and_Extract_Document_Segments
{
    internal class Vali_XML
    {
        public static string XmlValidateByXsd(string xmlText, string schemaFile)
        {
            try
            {
                // create XmlReaderSettings
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                settings.Schemas.Add(null, schemaFile);

                settings.ValidationEventHandler += ValidationCallback;

              
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlText), settings))
                {
                    
                    while (reader.Read())
                    {
                       
                    }
                }
                return "XML validation succeeded.";
                Console.WriteLine("XML validation succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("XML validation failed: " + ex.Message);
                return "XML validation failed: " + ex.Message;
            }
        }
        public static void ValidationCallback(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine("Warning: " + e.Message);
            else if (e.Severity == XmlSeverityType.Error)
                throw new Exception("Validation error: " + e.Message);
        }
    }
}
