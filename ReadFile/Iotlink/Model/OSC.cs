using Newtonsoft.Json;
using ReadFile.Iotlink.Converts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Iotlink.Model
{
    public class Tag
    {

        [JsonProperty("@k")]
        public string K { get; set; }

        [JsonProperty("@v")]
        public string V { get; set; }
    }

    public class Node
    {

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("@lat")]
        [JsonConverter(typeof(StringToDouble))]
        public double Lat { get; set; }

        [JsonProperty("@lon")]
        [JsonConverter(typeof(StringToDouble))]
        public double Lon { get; set; }

        [JsonProperty("tag")]
        [JsonConverter(typeof(JsonConverterObjectToList<Tag>))]
        public IList<Tag> Tags { get; set; }
    }

    public class Nd
    {

        [JsonProperty("@ref")]
        public string Ref { get; set; }
    }

    public class Way
    {

        [JsonProperty("nd")]
        public IList<Nd> Nd { get; set; }

        [JsonProperty("tag")]
        [JsonConverter(typeof(JsonConverterObjectToList<Tag>))]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class Member
    {

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("@ref")]
        public string Ref { get; set; }

        [JsonProperty("@role")]
        public string Role { get; set; }
    }

    public class Relation
    {

        [JsonProperty("member")]
        public IList<Member> Members { get; set; }

        [JsonProperty("tag")]
        [JsonConverter(typeof(JsonConverterObjectToList<Tag>))]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class Modify
    {

        [JsonProperty("node")]
        [JsonConverter(typeof(JsonConverterObjectToList<Node>))]
        public IList<Node> Nodes { get; set; }

        [JsonProperty("way")]
        [JsonConverter(typeof(JsonConverterObjectToList<Way>))]
        public IList<Way> Ways { get; set; }

        [JsonProperty("relation")]
        [JsonConverter(typeof(JsonConverterObjectToList<Relation>))]
        public IList<Relation> Relations { get; set; }
    }
    
    public class Create
    {

        [JsonProperty("node")]
        [JsonConverter(typeof(JsonConverterObjectToList<Node>))]
        public IList<Node> Nodes { get; set; }

        [JsonProperty("way")]
        [JsonConverter(typeof(JsonConverterObjectToList<Way>))]
        public IList<Way> Ways { get; set; }

        [JsonProperty("relation")]
        [JsonConverter(typeof(JsonConverterObjectToList<Relation>))]
        public IList<Relation> Relations { get; set; }
    }

    public class Delete
    {
        [JsonProperty("node")]
        [JsonConverter(typeof(JsonConverterObjectToList<Node>))]
        public IList<Node> Nodes { get; set; }
    }

    public class OsmChange
    {

        [JsonProperty("modify")]
        [JsonConverter(typeof(JsonConverterObjectToList<Modify>))]
        public IList<Modify> Modifies { get; set; }

        [JsonProperty("delete")]
        [JsonConverter(typeof(JsonConverterObjectToList<Delete>))]
        public IList<Delete> Deletes { get; set; }

        [JsonProperty("create")]
        [JsonConverter(typeof(JsonConverterObjectToList<Create>))]
        public IList<Create> Creates { get; set; }

        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@generator")]
        public string Generator { get; set; }
    }

    public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@encoding")]
        public string Encoding { get; set; }

    }

    public class OSC
    {

        [JsonProperty("osmChange")]
        public OsmChange OsmChange { get; set; }

        [JsonProperty("?xml")]
        public Xml Xml { get; set; }
    }
}
