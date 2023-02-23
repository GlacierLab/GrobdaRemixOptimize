using System;

// Token: 0x0200006D RID: 109
public class LoadScriptConfig
{
	// Token: 0x060001E2 RID: 482 RVA: 0x00007111 File Offset: 0x00005511
	public static void SetConfig(string l, int i = 0)
	{
		LoadScriptConfig.loadFromSaveData = false;
		LoadScriptConfig.LoadPath = l;
		LoadScriptConfig.index = i;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00007125 File Offset: 0x00005525
	public static void SetSaveData(SaveData data)
	{
		LoadScriptConfig.loadFromSaveData = true;
		LoadScriptConfig.saveDate = data;
	}

	// Token: 0x04000167 RID: 359
	public static string LoadPath;

	// Token: 0x04000168 RID: 360
	public static int index;

	// Token: 0x04000169 RID: 361
	public static bool loadFromSaveData;

	// Token: 0x0400016A RID: 362
	public static SaveData saveDate;
}
