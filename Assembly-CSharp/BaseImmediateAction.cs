using System;

// Token: 0x02000006 RID: 6
public abstract class BaseImmediateAction : BaseAction
{
	// Token: 0x06000022 RID: 34 RVA: 0x000027F8 File Offset: 0x00000BF8
	public override void Init()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.WAIT);
	}
}
