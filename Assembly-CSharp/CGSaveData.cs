using System;

// Token: 0x02000093 RID: 147
public class CGSaveData
{
	// Token: 0x040001EF RID: 495
	public SerializableDictionary<string, bool> savedata = new SerializableDictionary<string, bool>();

	// Token: 0x040001F0 RID: 496
	public SerializableDictionary<string, bool> groupFlag = new SerializableDictionary<string, bool>();

	// Token: 0x040001F1 RID: 497
	public int version;
}
