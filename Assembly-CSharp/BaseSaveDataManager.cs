using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// Token: 0x0200008F RID: 143
public abstract class BaseSaveDataManager<T> : ISaveDataManager where T : new()
{
	// Token: 0x060002FE RID: 766 RVA: 0x0000ACDD File Offset: 0x000090DD
	protected void Init()
	{
		if (File.Exists(this.filename))
		{
			this.Deserialize();
		}
		else
		{
			this.InitDict();
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0000AD00 File Offset: 0x00009100
	public void Deserialize()
	{
		using (StringReader stringReader = new StringReader(AesUtil.DecryptTextFromFile(this.filename)))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			this.saveData = (T)((object)xmlSerializer.Deserialize(stringReader));
		}
	}

	// Token: 0x06000300 RID: 768
	public abstract void InitDict();

	// Token: 0x06000301 RID: 769 RVA: 0x0000AD64 File Offset: 0x00009164
	public void Serializer()
	{
		XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
		xmlSerializerNamespaces.Add(string.Empty, string.Empty);
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.OmitXmlDeclaration = true;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, this.saveData, xmlSerializerNamespaces);
				AesUtil.EncryptTextToFile(stringWriter.ToString(), this.filename);
			}
		}
	}

	// Token: 0x040001EA RID: 490
	protected T saveData = new T();

	// Token: 0x040001EB RID: 491
	protected string filename;
}
