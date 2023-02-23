using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C8 RID: 200
public class GalleryItemGroup : MonoBehaviour
{
	// Token: 0x06000467 RID: 1127 RVA: 0x0000EB6F File Offset: 0x0000CF6F
	private void Awake()
	{
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x0000EB71 File Offset: 0x0000CF71
	public void ClearImage()
	{
		if (this.CGImage != null)
		{
			this.CGImage.sprite = null;
		}
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0000EB90 File Offset: 0x0000CF90
	public void SetImage(Sprite image)
	{
		if (image == null)
		{
			this.ClearImage();
			return;
		}
		this.CGImage.sprite = image;
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0000EBB4 File Offset: 0x0000CFB4
	public void ClickLoadCGScript()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		if (this.scriptStr.Length > 0)
		{
			Singleton<AVGManager>.Instance.SetStartStatus();
			Singleton<AVGManager>.Instance.LoadScriptInExtra("xml/" + this.scriptStr, true);
		}
	}

	// Token: 0x0400029C RID: 668
	public Image CGImage;

	// Token: 0x0400029D RID: 669
	public int index;

	// Token: 0x0400029E RID: 670
	public string scriptStr;
}
