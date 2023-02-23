using System;

// Token: 0x02000095 RID: 149
public class DataSaveItem
{
	// Token: 0x06000315 RID: 789 RVA: 0x0000B0F6 File Offset: 0x000094F6
	public DataSaveItem()
	{
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0000B0FE File Offset: 0x000094FE
	public DataSaveItem(string n, int l)
	{
		this.name = n;
		this.line = l;
	}

	// Token: 0x040001F3 RID: 499
	public string name;

	// Token: 0x040001F4 RID: 500
	public int line;
}
