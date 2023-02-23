using System;
using System.Linq;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class SavePanelControlScript : MonoBehaviour
{
	// Token: 0x06000407 RID: 1031 RVA: 0x0000DD3A File Offset: 0x0000C13A
	private void Start()
	{
		this.InitAllItemGroup();
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0000DD44 File Offset: 0x0000C144
	public void InitAllItemGroup()
	{
		this.itemGroups = base.GetComponentsInChildren<SaveItemGroup>();
		SaveData[] allSaveData = SaveDataManager.GetInstance().GetAllSaveData();
		for (int i = 0; i < this.itemGroups.Count<SaveItemGroup>(); i++)
		{
			int num = i + 9 * this.nowSelect;
			this.itemGroups[i].SetSaveData(allSaveData[num], num);
		}
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0000DDA8 File Offset: 0x0000C1A8
	public void DeleteUnUseful()
	{
		for (int i = 0; i < this.itemGroups.Count<SaveItemGroup>(); i++)
		{
			this.itemGroups[i].ClearImage();
		}
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0000DDE4 File Offset: 0x0000C1E4
	public void SetNowSelect(int i)
	{
		if (this.nowSelect == i)
		{
			return;
		}
		this.nowSelect = i;
		this.InitAllItemGroup();
	}

	// Token: 0x04000270 RID: 624
	[SerializeField]
	private SaveItemGroup[] itemGroups;

	// Token: 0x04000271 RID: 625
	[SerializeField]
	private int nowSelect;
}
