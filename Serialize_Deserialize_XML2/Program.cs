using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        Console.WriteLine("Masukkan path folder kumpulan file XML:");
        string folderPath = Console.ReadLine();

        if (Directory.Exists(folderPath))
        {
            string outputFolder = Path.Combine(folderPath, "Output"); // Membuat folder output di dalam folder sumber

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

            foreach (string xmlFile in xmlFiles)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);

                // Ganti semua tag yang mengandung FT400, Ft400, atau ft400 menjadi RI360, Ri360, atau ri360
                XmlNodeList nodes = doc.SelectNodes("//node()[contains(translate(name(),'ft','FT'),'RI360')]");

                foreach (XmlNode node in nodes)
                {
                    // Mengganti nama tag
                    XmlNode newNode = doc.CreateElement("RI360");
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        // Menyalin atribut dari tag lama ke tag baru (opsional)
                        XmlNode newAttr = doc.CreateAttribute(attr.Name);
                        newAttr.Value = attr.Value;
                        newNode.Attributes.Append(newAttr);
                    }
                    newNode.InnerXml = node.InnerXml;
                    node.ParentNode.ReplaceChild(newNode, node);
                }

                // Simpan file yang telah dimodifikasi ke dalam folder output
                string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(xmlFile));
                doc.Save(outputFilePath);
            }

            Console.WriteLine("Proses selesai. File-file yang telah dimodifikasi tersimpan di folder 'Output'.");
        }
        else
        {
            Console.WriteLine("Folder tidak ditemukan.");
        }
    }
}
