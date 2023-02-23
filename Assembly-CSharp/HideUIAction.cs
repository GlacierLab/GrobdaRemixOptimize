using System;

// Token: 0x02000015 RID: 21
public class HideUIAction : BaseAction
{
	// Token: 0x06000068 RID: 104 RVA: 0x000032B9 File Offset: 0x000016B9
	public HideUIAction(HideUIScript p)
	{
		this.name = p.name;
		this.LastTime = 0f;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x000032D8 File Offset: 0x000016D8
	public static HideUIAction Create(HideUIScript p)
	{
		HideUIAction hideUIAction = new HideUIAction(p);
		hideUIAction.InitScript(p);
		return hideUIAction;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000032F4 File Offset: 0x000016F4
	public override void FinishAction()
	{
		Singleton<UIManager>.Instance.HideUi(this.name);
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00003306 File Offset: 0x00001706
	public override void Action()
	{
	}

	// Token: 0x04000032 RID: 50
	public string name;
}
