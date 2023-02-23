using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000CC RID: 204
public class MusicItem : MonoBehaviour
{
	// Token: 0x0600047A RID: 1146 RVA: 0x0000F04F File Offset: 0x0000D44F
	private void Awake()
	{
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x0000F051 File Offset: 0x0000D451
	public void ClearImage()
	{
		if (this.StatusImage != null)
		{
			this.StatusImage.sprite = null;
		}
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0000F070 File Offset: 0x0000D470
	public void SetImage(Sprite image)
	{
		if (image == null)
		{
			this.ClearImage();
			return;
		}
		this.StatusImage.sprite = image;
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0000F091 File Offset: 0x0000D491
	public void SetTitle(string title)
	{
		this.Title.text = title;
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0000F09F File Offset: 0x0000D49F
	public void ClickPlayMusic()
	{
		Singleton<BGMManager>.Instance.PlayBGM(this.musicName, false);
	}

	// Token: 0x040002A9 RID: 681
	public Image StatusImage;

	// Token: 0x040002AA RID: 682
	public Text Title;

	// Token: 0x040002AB RID: 683
	public int index;

	// Token: 0x040002AC RID: 684
	public string musicName;
}
