using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class GalleryPanelControlScript : MonoBehaviour
{
	// Token: 0x0600046C RID: 1132 RVA: 0x0000EC09 File Offset: 0x0000D009
	private void Start()
	{
		this.InitAllItemGroup();
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0000EC14 File Offset: 0x0000D014
	public void InitAllItemGroup()
	{
		this.generateImageItems();
		this.itemGroups = base.GetComponentsInChildren<GalleryItemGroup>();
		for (int i = 0; i < this.itemGroups.Count<GalleryItemGroup>(); i++)
		{
			int num = i + 12 * this.nowSelect;
			this.itemGroups[i].index = num;
			this.itemGroups[i].SetImage(null);
			this.itemGroups[i].scriptStr = null;
			Debug.Log("is show:" + this.imageItems[num].isShow);
			if (this.imageItems.Count<GalleryPanelControlScript.imageItem>() > num && this.imageItems[num].isShow)
			{
				this.itemGroups[i].SetImage(this.imageItems[num].imageSprite);
				this.itemGroups[i].scriptStr = this.imageItems[num].scptName;
			}
		}
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0000ED14 File Offset: 0x0000D114
	public void DeleteUnUseful()
	{
		for (int i = 0; i < this.itemGroups.Count<GalleryItemGroup>(); i++)
		{
			this.itemGroups[i].ClearImage();
		}
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0000ED50 File Offset: 0x0000D150
	public void SetNowSelect(int i)
	{
		if (this.nowSelect == i)
		{
			return;
		}
		this.nowSelect = i;
		this.InitAllItemGroup();
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0000ED6C File Offset: 0x0000D16C
	private Sprite loadImage(string path)
	{
		return Resources.Load<Sprite>("icon/extra/Gallery/" + path);
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0000ED8C File Offset: 0x0000D18C
	private void generateImageItems()
	{
		string[] array = new string[]
		{
			"common/K1", "common/K2", "common/K3", "common/K4", "common/K5", "common/K6", "common/K7", "common/K8", "common/K9", "common/K10",
			"common/K11", "common/K12", "LY/R1", "LY/R2", "LY/R3", "LY/R4", "LY/R5", "LY/R6", "YK/Y1", "YK/Y2",
			"YK/Y3", "YK/Y4", "YK/Y5", "YK/Y6"
		};
		this.imageItems = new GalleryPanelControlScript.imageItem[array.Length];
		Dictionary<string, bool> groupFlag = CGSaveDataManager.GetInstance().GetGroupFlag();
		int num = 0;
		foreach (string text in array)
		{
			this.imageItems[num] = this.setImageGroup(text, groupFlag, this.imageItems[num]);
			num++;
		}
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x0000EEDC File Offset: 0x0000D2DC
	private GalleryPanelControlScript.imageItem setImageGroup(string path, Dictionary<string, bool> cgGroupIndexs, GalleryPanelControlScript.imageItem imageItem)
	{
		imageItem.imageSprite = this.loadImage(path);
		Debug.Log("image:" + imageItem.imageSprite);
		string text = path.Substring(0, path.IndexOf("/"));
		string text2 = path.Substring(path.IndexOf("/") + 1);
		if (cgGroupIndexs.ContainsKey(text))
		{
			imageItem.isShow = cgGroupIndexs[text];
			imageItem.scptName = text2;
		}
		return imageItem;
	}

	// Token: 0x0400029F RID: 671
	[SerializeField]
	private GalleryItemGroup[] itemGroups;

	// Token: 0x040002A0 RID: 672
	[SerializeField]
	private GalleryPanelControlScript.imageItem[] imageItems;

	// Token: 0x040002A1 RID: 673
	[SerializeField]
	private int nowSelect;

	// Token: 0x020000CA RID: 202
	public struct imageItem
	{
		// Token: 0x040002A2 RID: 674
		public string scptName;

		// Token: 0x040002A3 RID: 675
		public Sprite imageSprite;

		// Token: 0x040002A4 RID: 676
		public int groupID;

		// Token: 0x040002A5 RID: 677
		public bool isShow;
	}
}
