using System;

// Token: 0x0200001F RID: 31
public class ReturnToUIAction : BaseAction
{
	// Token: 0x06000094 RID: 148 RVA: 0x000039C0 File Offset: 0x00001DC0
	public ReturnToUIAction(string vValue)
	{
		this.UIName = vValue;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000039D0 File Offset: 0x00001DD0
	public static ReturnToUIAction Create(ReturnToUIScript rtuis)
	{
		ReturnToUIAction returnToUIAction = new ReturnToUIAction(rtuis.UIName);
		returnToUIAction.InitScript(rtuis);
		return returnToUIAction;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000039F1 File Offset: 0x00001DF1
	public override void Action()
	{
	}

	// Token: 0x06000097 RID: 151 RVA: 0x000039F3 File Offset: 0x00001DF3
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.CleanAllInExtra();
		Singleton<UIManager>.Instance.RestoreUi();
	}

	// Token: 0x04000048 RID: 72
	private string UIName;
}
