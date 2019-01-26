using Newtonsoft.Json;
using ReadFile.Iotlink.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ReadFile
{
    class Program
    {
        public static GocToaDo GetDiem(Node node, GocToaDo goc)
        {
            if (node.Lat < goc.LatNho)
            {
                goc.LatNho = node.Lat;
            }
            if (node.Lat > goc.LatLon)
            {
                goc.LatLon = node.Lat;
            }

            if (node.Lon < goc.LonNho)
            {
                goc.LonNho = node.Lon;
            }
            if (node.Lon > goc.LonLon)
            {
                goc.LonLon = node.Lon;
            }
            return goc;
        }

        public static GocToaDo GetGocToaDo(IList<Node> list, GocToaDo goc)
        {
            if (list != null)
            {
                foreach (var node in list)
                {
                    goc = GetDiem(node, goc);
                }

            }
            return goc;
        }
        static void Main(string[] args)
        {
            for (int i = 42; i < 50; i++)
            {
                var goc = new GocToaDo();
                var path = @"D:\IotLink\OSM\0"+ i + ".osc";
                var osc = ReadFileOSC(path);
                if (osc.OsmChange.Creates != null)
                {
                    foreach (var item in osc.OsmChange.Creates)
                    {
                        goc = GetGocToaDo(item.Nodes, goc);
                    }
                }
                if (osc.OsmChange.Modifies != null)
                {
                    foreach (var item in osc.OsmChange.Modifies)
                    {
                        goc = GetGocToaDo(item.Nodes, goc);
                    }
                }
                if (osc.OsmChange.Deletes != null)
                {
                    foreach (var item in osc.OsmChange.Deletes)
                    {
                        goc = GetGocToaDo(item.Nodes, goc);
                    }
                }
                
                Console.WriteLine(goc.LatNho + " : " + goc.LatLon + " : " + goc.LonNho + " : " + goc.LonLon);
            }
            Console.ReadKey();
        }

        public static OSC ReadFileOSC(string path)
        {
            string content = File.ReadAllText(path);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            var osc = JsonConvert.DeserializeObject<OSC>(jsonText);
            return osc;
        }
    }
}
