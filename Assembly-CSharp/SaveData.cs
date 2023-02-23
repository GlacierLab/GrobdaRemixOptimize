using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// Token: 0x0200009C RID: 156
[Serializable]
public class SaveData
{
	// Token: 0x0600032D RID: 813 RVA: 0x0000B536 File Offset: 0x00009936
	public SaveData UpdateVersion(SaveData data)
	{
		return null;
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0000B53C File Offset: 0x0000993C
	public static SaveData Deserialize(StreamReader sr)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
		return (SaveData)xmlSerializer.Deserialize(sr);
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0000B568 File Offset: 0x00009968
	public static string Serializer(SaveData data)
	{
		XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
		xmlSerializerNamespaces.Add(string.Empty, string.Empty);
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.OmitXmlDeclaration = true;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveData));
		string text;
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, data, xmlSerializerNamespaces);
				text = stringWriter.ToString();
			}
		}
		return text;
	}

	// Token: 0x04000210 RID: 528
	public int version;

	// Token: 0x04000211 RID: 529
	public long time;

	// Token: 0x04000212 RID: 530
	public string name;

	// Token: 0x04000213 RID: 531
	public string text;

	// Token: 0x04000214 RID: 532
	public string script_path;

	// Token: 0x04000215 RID: 533
	public int index;

	// Token: 0x04000216 RID: 534
	public string bgm;

	// Token: 0x04000217 RID: 535
	public List<SaveLayoutItem> items = new List<SaveLayoutItem>();

	// Token: 0x04000218 RID: 536
	public List<SaveLightItem> lights = new List<SaveLightItem>();

	// Token: 0x04000219 RID: 537
	public SaveLayoutItem MaskLayoutItem = new SaveLayoutItem();

	// Token: 0x0400021A RID: 538
	public List<string> Addin = new List<string>();
}
