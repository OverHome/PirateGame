using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; 
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue
{

    [XmlElement("text")]
    public string text;

    [XmlElement("node")]
    public Node[]  nodes;

    public static Dialogue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dial = serializer.Deserialize(reader) as Dialogue;
        return dial;
    }
}

[System.Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string Npctext;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}

public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlAttribute("personalCount")]
    public int personalCount;
    [XmlElement("text")]
    public string text;
    [XmlElement("dialend")]
    public string end;

}