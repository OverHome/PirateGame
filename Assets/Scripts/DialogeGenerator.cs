using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class DialogueGenerator : MonoBehaviour {
	
    public string fileName = "Example"; // имя генерируемого файла (без разрешения)
    public string folder = "Dialogs"; // подпапка в Resources, для записи
    public DialogueNode[] node;

    public void Start()
    {
        string path = Application.dataPath + "/Assets/" + folder + "/" + fileName + ".xml";
        Debug.Log(Application.dataPath);
        XmlNode userNode;
        XmlElement element;

        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("dialogue");
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = fileName;
        rootNode.Attributes.Append(attribute);
        xmlDoc.AppendChild(rootNode);

        for(int j = 0; j < node.Length; j++)
        {
            userNode = xmlDoc.CreateElement("node");
            attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = j.ToString();
            userNode.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("npcText");
            attribute.Value = node[j].npcText;
            userNode.Attributes.Append(attribute);

            for(int i = 0; i < node[j].playerAnswer.Length; i++)
            {
                element = xmlDoc.CreateElement("answer");
                element.SetAttribute("text", node[j].playerAnswer[i].text);
                if(node[j].playerAnswer[i].toNode > 0) element.SetAttribute("toNode", node[j].playerAnswer[i].toNode.ToString());
                if(node[j].playerAnswer[i].exit) element.SetAttribute("exit", node[j].playerAnswer[i].exit.ToString());
                userNode.AppendChild(element);
            }

            rootNode.AppendChild(userNode);
        }

        xmlDoc.Save(path);
        Debug.Log(this + " Создан XML файл диалога [ " + fileName + " ] по адресу: " + path);
    }
}

[System.Serializable]
public class DialogueNode
{
    public string npcText;
    public PlayerAnswer[] playerAnswer;
}


[System.Serializable]
public class PlayerAnswer
{
    public string text;
    public int toNode;
    public bool exit;
}