using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000094 RID: 148
public class CGSaveDataManager : BaseSaveDataManager<CGSaveData>
{
	// Token: 0x0600030D RID: 781 RVA: 0x0000AF4C File Offset: 0x0000934C
	protected CGSaveDataManager()
	{
		this.filename = Application.dataPath + "/save/cg";
		base.Init();
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0000AF70 File Offset: 0x00009370
	public void SetReadCG(string name)
	{
		if (!this.saveData.savedata.ContainsKey(name))
		{
			this.saveData.savedata[name] = true;
			base.Serializer();
			return;
		}
		if (!this.saveData.savedata[name])
		{
			this.saveData.savedata[name] = true;
			base.Serializer();
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0000AFDC File Offset: 0x000093DC
	public void SetGroupFlag(string groupName)
	{
		if (!this.saveData.groupFlag.ContainsKey(groupName))
		{
			this.saveData.groupFlag[groupName] = true;
			base.Serializer();
			return;
		}
		if (!this.saveData.groupFlag[groupName])
		{
			this.saveData.groupFlag[groupName] = true;
			base.Serializer();
		}
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0000B046 File Offset: 0x00009446
	public Dictionary<string, bool> GetAllSaveData()
	{
		return this.saveData.savedata;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0000B053 File Offset: 0x00009453
	public Dictionary<string, bool> GetGroupFlag()
	{
		return this.saveData.groupFlag;
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0000B060 File Offset: 0x00009460
	public static CGSaveDataManager GetInstance()
	{
		if (CGSaveDataManager.instance == null)
		{
			CGSaveDataManager.instance = new CGSaveDataManager();
		}
		return CGSaveDataManager.instance;
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0000B07C File Offset: 0x0000947C
	public override void InitDict()
	{
		Dictionary<string, Sprite>.KeyCollection keys = Singleton<CGManager>.Instance.GetAllKey().Keys;
		foreach (string text in keys)
		{
			this.saveData.savedata.Add(text, false);
		}
		base.Serializer();
	}

	// Token: 0x040001F2 RID: 498
	private static CGSaveDataManager instance;
}
