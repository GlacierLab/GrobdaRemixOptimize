using System;

// Token: 0x02000029 RID: 41
public class ShowUIAction : BaseAction
{
	// Token: 0x060000C3 RID: 195 RVA: 0x00004035 File Offset: 0x00002435
	public ShowUIAction(ShowUIScript p)
	{
		this.name = p.name;
		this.LastTime = 0f;
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00004054 File Offset: 0x00002454
	public static ShowUIAction Create(ShowUIScript p)
	{
		ShowUIAction showUIAction = new ShowUIAction(p);
		showUIAction.InitScript(p);
		return showUIAction;
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00004070 File Offset: 0x00002470
	public override void FinishAction()
	{
		Singleton<UIManager>.Instance.ShowUi(this.name);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00004082 File Offset: 0x00002482
	public override void Action()
	{
	}

	// Token: 0x04000059 RID: 89
	public string name;
}
