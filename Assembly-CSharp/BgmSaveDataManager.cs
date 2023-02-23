using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000092 RID: 146
public class BgmSaveDataManager : BaseSaveDataManager<BgmSaveData>
{
	// Token: 0x06000306 RID: 774 RVA: 0x0000AE37 File Offset: 0x00009237
	protected BgmSaveDataManager()
	{
		this.filename = Application.dataPath + "/save/bgm";
		base.Init();
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0000AE5A File Offset: 0x0000925A
	public static BgmSaveDataManager GetInstance()
	{
		if (BgmSaveDataManager.instance == null)
		{
			BgmSaveDataManager.instance = new BgmSaveDataManager();
		}
		return BgmSaveDataManager.instance;
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0000AE75 File Offset: 0x00009275
	public void SetListenerBgm(string name)
	{
		if (!this.saveData.savedata[name])
		{
			this.saveData.savedata[name] = true;
			base.Serializer();
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0000AEA5 File Offset: 0x000092A5
	public Dictionary<string, bool> GetAllSaveData()
	{
		return this.saveData.savedata;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0000AEB4 File Offset: 0x000092B4
	public override void InitDict()
	{
		Dictionary<string, AudioClip>.KeyCollection keys = Singleton<BGMManager>.Instance.GetAllBgm().Keys;
		foreach (string text in keys)
		{
			this.saveData.savedata.Add(text, false);
		}
		base.Serializer();
	}

	// Token: 0x040001EE RID: 494
	private static BgmSaveDataManager instance;
}
