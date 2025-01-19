using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using UnityEngine;

public class XmlToHtmlConverter : MonoBehaviour
{
    public string xmlFilePath = "Assets/CharacterData.xml";
    public string xsltFilePath = "Assets/CharacterTemplate.xslt";
    public string outputHtmlFilePath = "Assets/CharacterList.html";

    void Start()
    {
        try
        {
            if (!File.Exists(xmlFilePath) || !File.Exists(xsltFilePath))
            {
                Debug.LogError("XML or XSLT file not found!");
                return;
            }
            
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);
            
            using (XmlReader xmlReader = XmlReader.Create(xmlFilePath))
            using (StreamWriter writer = new StreamWriter(outputHtmlFilePath))
            {
                xslt.Transform(xmlReader, null, writer);
            }

            Debug.Log($"HTML file generated successfully at: {outputHtmlFilePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error converting XML to HTML: {ex.Message}");
        }
    }
}