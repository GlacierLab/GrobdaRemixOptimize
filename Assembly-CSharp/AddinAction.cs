using System;

// Token: 0x02000004 RID: 4
public class AddinAction : BaseAction
{
	// Token: 0x06000011 RID: 17 RVA: 0x0000273F File Offset: 0x00000B3F
	public AddinAction(string n, string a)
	{
		this.name = n;
		this.action = a;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002758 File Offset: 0x00000B58
	public static AddinAction Create(AddinScript n)
	{
		AddinAction addinAction = new AddinAction(n.name, n.action);
		addinAction.InitScript(n);
		return addinAction;
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002780 File Offset: 0x00000B80
	public override void FinishAction()
	{
		string text = this.action;
		if (text != null)
		{
			if (!(text == "show"))
			{
				if (text == "hide")
				{
					Singleton<AddinManager>.Instance.HideAddIn(this.name);
				}
			}
			else
			{
				Singleton<AddinManager>.Instance.ShowAddIn(this.name);
			}
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000027EE File Offset: 0x00000BEE
	public override void Action()
	{
	}

	// Token: 0x0400000E RID: 14
	public string name;

	// Token: 0x0400000F RID: 15
	public string action;
}
