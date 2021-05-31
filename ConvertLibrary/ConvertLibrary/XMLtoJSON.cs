using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace ConvertLibrary
{
    public class XMLtoJSON
    {
        public static string sourceFileType { get; set; } = ".xml";
        public static string outputFileType { get; set; } = ".json";
        public static void Transform(string sourceFile, string outputFile)
        {
            XmlToJson(sourceFile, outputFile);
        }
        public static void Retransform(string sourceFile, string outputFile)
        {
            JsonToXml(sourceFile, outputFile);
        }
        private static void XmlToJson(string sourceFile, string outputFile)
        {
            using (FileStream fstreamread = File.OpenRead(sourceFile))
            {
                using (FileStream fstreamwrite = new FileStream(outputFile, FileMode.Create))
                {
                    byte[] array = new byte[fstreamread.Length];
                    fstreamread.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.GetEncoding("windows-1251").GetString(array);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(textFromFile);
                    string jsonText = JsonConvert.SerializeXmlNode(doc);
                    array = System.Text.Encoding.Default.GetBytes(jsonText);
                    fstreamwrite.Write(array, 0, array.Length);
                }
            }    
        }
        private static void JsonToXml(string sourceFile, string outputFile)
        {
            using (FileStream fstreamread = File.OpenRead(sourceFile))
            {
                using (FileStream fstreamwrite = new FileStream(outputFile, FileMode.Create))
                {
                    byte[] array = new byte[fstreamread.Length];
                    fstreamread.Read(array, 0, array.Length);
                    string textFromFile = System.Text.Encoding.UTF8.GetString(array);
                    XmlDocument doc = JsonConvert.DeserializeXmlNode(textFromFile);
                    doc.Save(fstreamwrite);
                }
            }
        }
       
    }
}
