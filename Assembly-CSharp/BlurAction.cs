using System;
using UnityStandardAssets.ImageEffects;

// Token: 0x02000007 RID: 7
public class BlurAction : BaseAction
{
	// Token: 0x06000024 RID: 36 RVA: 0x0000280D File Offset: 0x00000C0D
	public override void Action()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002814 File Offset: 0x00000C14
	public override void FinishAction()
	{
		BlurOptimized blur = Singleton<AVGManager>.Instance.GetBlur();
		if (this.script.action == "start")
		{
			blur.enabled = true;
			blur.blurSize = 0f;
			blur.blurIterations = 1;
			blur.downsample = 0;
		}
		else
		{
			blur.enabled = false;
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002874 File Offset: 0x00000C74
	public static BaseAction Create(BlurScript blurScript)
	{
		BlurAction blurAction = new BlurAction();
		blurAction.init(blurScript);
		blurAction.InitScript(blurScript);
		return blurAction;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002896 File Offset: 0x00000C96
	private void init(BlurScript blurScript)
	{
		this.script = blurScript;
	}

	// Token: 0x04000019 RID: 25
	private BlurScript script;
}
