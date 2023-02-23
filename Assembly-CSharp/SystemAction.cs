using System;

// Token: 0x0200002E RID: 46
public class SystemAction : BaseAction
{
	// Token: 0x060000D7 RID: 215 RVA: 0x00004169 File Offset: 0x00002569
	public SystemAction(string p, string v)
	{
		this.name = p;
		this.value = v;
		this.LastTime = 0f;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000418C File Offset: 0x0000258C
	public static SystemAction Create(SystemScript p)
	{
		SystemAction systemAction = new SystemAction(p.name, p.value);
		systemAction.InitScript(p);
		return systemAction;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x000041B4 File Offset: 0x000025B4
	public override void FinishAction()
	{
		string text = this.name;
		if (text != null)
		{
			if (!(text == "control"))
			{
				if (text == "auto")
				{
					Singleton<AVGManager>.Instance.IsAuto = bool.Parse(this.value);
				}
			}
			else
			{
				Singleton<AVGManager>.Instance.CanControl = bool.Parse(this.value);
			}
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000422C File Offset: 0x0000262C
	public override void Action()
	{
	}

	// Token: 0x0400005D RID: 93
	public string name;

	// Token: 0x0400005E RID: 94
	public string value;
}
