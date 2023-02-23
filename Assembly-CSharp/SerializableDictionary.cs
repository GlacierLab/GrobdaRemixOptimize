using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Token: 0x020000D5 RID: 213
[XmlRoot("dictionary")]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
	// Token: 0x060004AC RID: 1196 RVA: 0x0000FC74 File Offset: 0x0000E074
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0000FC78 File Offset: 0x0000E078
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(TValue));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("item");
			reader.ReadStartElement("key");
			TKey tkey = (TKey)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			reader.ReadStartElement("value");
			TValue tvalue = (TValue)((object)xmlSerializer2.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(tkey, tvalue);
			reader.ReadEndElement();
			reader.MoveToContent();
		}
		reader.ReadEndElement();
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0000FD30 File Offset: 0x0000E130
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(TValue));
		foreach (TKey tkey in base.Keys)
		{
			writer.WriteStartElement("item");
			writer.WriteStartElement("key");
			xmlSerializer.Serialize(writer, tkey);
			writer.WriteEndElement();
			writer.WriteStartElement("value");
			TValue tvalue = base[tkey];
			xmlSerializer2.Serialize(writer, tvalue);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}
}
