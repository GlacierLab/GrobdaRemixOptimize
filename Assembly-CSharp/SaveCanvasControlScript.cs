using System.IO;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class SaveCanvasControlScript : UIGameObject
{
	// Token: 0x060003F0 RID: 1008 RVA: 0x0000D670 File Offset: 0x0000BA70
	public override void Show()
	{
		base.Show();
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
		this.Dialog.SetActive(false);
		this.savePanelControlScript.InitAllItemGroup();
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0000D6CB File Offset: 0x0000BACB
	public override void Hide()
	{
		this.savePanelControlScript.DeleteUnUseful();
        this.Back();
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0000D6DE File Offset: 0x0000BADE
	public void Back()
	{
		this.canvasGroup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0000D707 File Offset: 0x0000BB07
	private void dismiss()
	{
		base.gameObject.SetActive(false);
		Singleton<AVGManager>.Instance.LoadStatus();
        if (File.Exists(this.filepath + "/test.png"))
        {
            File.Delete(this.filepath + "/test.png");
        }
        Resources.UnloadUnusedAssets();
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0000D725 File Offset: 0x0000BB25
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			if (this.Dialog.activeSelf)
			{
				this.Dialog.SetActive(false);
			}
			else
			{
				this.Hide();
			}
		}
	}
    private string filepath = Application.dataPath + "/save";
    // Token: 0x04000263 RID: 611
    public CanvasGroup canvasGroup;

	// Token: 0x04000264 RID: 612
	public GameObject Dialog;

	// Token: 0x04000265 RID: 613
	public SavePanelControlScript savePanelControlScript;
}
