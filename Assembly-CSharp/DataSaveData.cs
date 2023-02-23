using System;
using System.Collections.Generic;

// Token: 0x02000096 RID: 150
public class DataSaveData
{
	// Token: 0x06000318 RID: 792 RVA: 0x0000B128 File Offset: 0x00009528
	public Dictionary<string, DataSaveItem> GetDict()
	{
		Dictionary<string, DataSaveItem> dictionary = new Dictionary<string, DataSaveItem>();
		foreach (DataSaveItem dataSaveItem in this.items)
		{
			dictionary.Add(dataSaveItem.name, dataSaveItem);
		}
		return dictionary;
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0000B194 File Offset: 0x00009594
	public void SaveItems(Dictionary<string, DataSaveItem> dicts)
	{
		this.items.Clear();
		foreach (KeyValuePair<string, DataSaveItem> keyValuePair in dicts)
		{
			this.items.Add(keyValuePair.Value);
		}
	}

	// Token: 0x040001F5 RID: 501
	public int version;

	// Token: 0x040001F6 RID: 502
	public List<DataSaveItem> items = new List<DataSaveItem>();
}
