using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000097 RID: 151
public class DataSaveManager
{
	// Token: 0x0600031A RID: 794 RVA: 0x0000B204 File Offset: 0x00009604
	protected DataSaveManager()
	{
		this.Init();
	}

	// Token: 0x0600031B RID: 795 RVA: 0x0000B23D File Offset: 0x0000963D
	public static DataSaveManager GetInstance()
	{
		if (DataSaveManager.instance == null)
		{
			DataSaveManager.instance = new DataSaveManager();
		}
		return DataSaveManager.instance;
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0000B258 File Offset: 0x00009658
	public DataSaveItem GetDataSaveItem(string name)
	{
		if (this.dicts.ContainsKey(name))
		{
			return this.dicts[name];
		}
		DataSaveItem dataSaveItem = new DataSaveItem(name, 0);
		this.dicts.Add(name, dataSaveItem);
		return dataSaveItem;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0000B299 File Offset: 0x00009699
	public void UpdateDataSaveItem(string name, int line)
	{
		this.GetDataSaveItem(name).line = line;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0000B2A8 File Offset: 0x000096A8
	private void Init()
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

	// Token: 0x0600031F RID: 799 RVA: 0x0000B2CB File Offset: 0x000096CB
	private void InitDict()
	{
		this.Serializer();
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0000B2D4 File Offset: 0x000096D4
	private void Deserialize()
	{
		using (StringReader stringReader = new StringReader(AesUtil.DecryptTextFromFile(this.filename)))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSaveData));
			this.data = (DataSaveData)xmlSerializer.Deserialize(stringReader);
			this.dicts = this.data.GetDict();
		}
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0000B348 File Offset: 0x00009748
	public void SaveAllDataToFile()
	{
		this.Serializer();
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0000B350 File Offset: 0x00009750
	private void Serializer()
	{
		this.data.SaveItems(this.dicts);
		XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
		xmlSerializerNamespaces.Add(string.Empty, string.Empty);
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.OmitXmlDeclaration = true;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSaveData));
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, this.data, xmlSerializerNamespaces);
				AesUtil.EncryptTextToFile(stringWriter.ToString(), this.filename);
			}
		}
		this.dicts = this.data.GetDict();
	}

	// Token: 0x040001F7 RID: 503
	private static DataSaveManager instance;

	// Token: 0x040001F8 RID: 504
	private string filename = Application.dataPath + "/save/data";

	// Token: 0x040001F9 RID: 505
	private DataSaveData data = new DataSaveData();

	// Token: 0x040001FA RID: 506
	private Dictionary<string, DataSaveItem> dicts = new Dictionary<string, DataSaveItem>();
}
