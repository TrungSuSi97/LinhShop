using LinhNguyen.Resources.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhNguyen.Resources.Entities;
using System.IO;
using System.Xml.Linq;

namespace LinhNguyen.Resources.Concrete
{
    public class XmlResourceProvider : BaseResourceProvider
    {
        // File Path
        private static string filePath = null;

        public XmlResourceProvider() { }

        public XmlResourceProvider(string filePath)
        {
            XmlResourceProvider.filePath = filePath;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format($"XML Resource file {filePath} was not found"));
            }
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            // Parse XML to file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Where(e => e.Attribute(nameof(name)).Value == name && e.Attribute(nameof(culture)).Value == culture)
                .Select(e => new ResourceEntry
                {
                    Name = e.Attribute(nameof(name)).Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute(nameof(culture)).Value
                }).FirstOrDefault();
        }

        protected override IList<ResourceEntry> ReadResources()
        {
            // Parse XML to file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Select(e => new ResourceEntry
                {
                    Name = e.Attribute("name").Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).ToList();
        }
    }
}
