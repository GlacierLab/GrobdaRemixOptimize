using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

// Token: 0x02000008 RID: 8
public class BlurChangeAction : BaseAction
{
	// Token: 0x06000029 RID: 41 RVA: 0x000028A8 File Offset: 0x00000CA8
	public override void Init()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.ANIMATION);
		this.SetLayout(ImageLayoutsManager.GetInstance().GetCameraLayout());
		this.blur = Singleton<AVGManager>.Instance.GetBlur();
		this.speed = (this.script.size - this.blur.blurSize) / this.script.time;
		this.LastTime = this.script.time;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000291A File Offset: 0x00000D1A
	public override void Action()
	{
		this.blur.blurSize += this.speed * Time.deltaTime;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x0000293A File Offset: 0x00000D3A
	public override void FinishAction()
	{
		this.blur.blurSize = this.script.size;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002954 File Offset: 0x00000D54
	public static BaseAction Create(BlurChangeScript blurChangeScript)
	{
		BlurChangeAction blurChangeAction = new BlurChangeAction();
		blurChangeAction.init(blurChangeScript);
		blurChangeAction.InitScript(blurChangeScript);
		return blurChangeAction;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002976 File Offset: 0x00000D76
	private void init(BlurChangeScript blurChangeScript)
	{
		this.script = blurChangeScript;
	}

	// Token: 0x0400001A RID: 26
	private BlurChangeScript script;

	// Token: 0x0400001B RID: 27
	private BlurOptimized blur;

	// Token: 0x0400001C RID: 28
	private float speed;
}
