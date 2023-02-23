using System;
using System.Linq;
using UnityEngine;

// Token: 0x020000CD RID: 205
public class MusicPanelControlScript : MonoBehaviour
{
	// Token: 0x06000480 RID: 1152 RVA: 0x0000F0BA File Offset: 0x0000D4BA
	private void Start()
	{
		this.InitAllItemGroup();
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0000F0C4 File Offset: 0x0000D4C4
	public void InitAllItemGroup()
	{
		this.generateMusicItems();
		this.itemGroups = base.GetComponentsInChildren<MusicItem>(true);
		for (int i = 0; i < this.itemGroups.Count<MusicItem>(); i++)
		{
			int num = i + 20 * this.nowSelect;
			if (num > 25)
			{
				this.itemGroups[i].index = num;
				this.itemGroups[i].SetTitle(string.Empty);
				this.itemGroups[i].musicName = null;
				this.itemGroups[i].gameObject.SetActive(false);
			}
			else
			{
				this.itemGroups[i].index = num;
				this.itemGroups[i].SetTitle(this.musicItems[num].title);
				this.itemGroups[i].musicName = this.musicItems[num].musicName;
				this.itemGroups[i].gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0000F1C0 File Offset: 0x0000D5C0
	public void DeleteUnUseful()
	{
		for (int i = 0; i < this.itemGroups.Count<MusicItem>(); i++)
		{
			this.itemGroups[i].ClearImage();
		}
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0000F1FC File Offset: 0x0000D5FC
	public void SetNowSelect(int i)
	{
		if (this.nowSelect == i)
		{
			return;
		}
		this.nowSelect = i;
		this.InitAllItemGroup();
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0000F218 File Offset: 0x0000D618
	private Sprite loadImage(string path)
	{
		return Resources.Load<Sprite>("icon/extra/Music/" + path);
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0000F238 File Offset: 0x0000D638
	private void generateMusicItems()
	{
		string[] array = new string[]
		{
			"Luna Rhapsody", "Luna Rhapsody(Piano Only)", "As summer wind", "Fairy's Melody", "Lunardance", "Shadow waltz", "Relaxing Time", "Halfmoon!", "Daily life", "On my way",
			"Into the memories", "Sea", "Picnic", "Fear", "Happy Dance", "In the rain", "High _L_ Up", "Empty", "Dispute", "Sadness",
			"Felicity", "WTF!", "If", "Nervous", "Lost", "Final Stage"
		};
		string[] array2 = new string[]
		{
			"Luna Rhapsody", "Luna Rhapsody(Piano Only)", "As summer wind", "Fairy's Melody", "Lunardance", "Shadow waltz", "Relaxing Time", "Halfmoon!", "Daily life", "On my way",
			"Into the memories", "Sea", "Picnic", "Fear", "Happy Dance", "In the rain", "High _L_ Up", "Empty", "Dispute", "Sadness",
			"Felicity", "WTF!", "If", "Nervous", "Lost", "Final Stage"
		};
		this.musicItems = new MusicPanelControlScript.musicItem[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.musicItems[i].title = array[i];
			this.musicItems[i].musicName = array[i];
		}
	}

	// Token: 0x040002AD RID: 685
	[SerializeField]
	private MusicItem[] itemGroups;

	// Token: 0x040002AE RID: 686
	[SerializeField]
	private MusicPanelControlScript.musicItem[] musicItems;

	// Token: 0x040002AF RID: 687
	[SerializeField]
	private int nowSelect;

	// Token: 0x020000CE RID: 206
	public struct musicItem
	{
		// Token: 0x040002B0 RID: 688
		public string title;

		// Token: 0x040002B1 RID: 689
		public string musicName;

		// Token: 0x040002B2 RID: 690
		public Sprite imageSprite;

		// Token: 0x040002B3 RID: 691
		public bool isShow;
	}
}
