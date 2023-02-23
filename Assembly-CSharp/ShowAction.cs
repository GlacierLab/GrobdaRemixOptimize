using System;

// Token: 0x02000028 RID: 40
public class ShowAction : BaseAction
{
	// Token: 0x060000BF RID: 191 RVA: 0x00003FE4 File Offset: 0x000023E4
	public ShowAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00004000 File Offset: 0x00002400
	public static ShowAction Create(ShowScript p)
	{
		ShowAction showAction = new ShowAction(p.name);
		showAction.InitScript(p);
		return showAction;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00004021 File Offset: 0x00002421
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.ShowObject(this.name);
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00004033 File Offset: 0x00002433
	public override void Action()
	{
	}

	// Token: 0x04000058 RID: 88
	public string name;
}
