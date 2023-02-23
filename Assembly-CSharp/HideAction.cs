using System;

// Token: 0x02000014 RID: 20
public class HideAction : BaseAction
{
	// Token: 0x06000064 RID: 100 RVA: 0x00003269 File Offset: 0x00001669
	public HideAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00003284 File Offset: 0x00001684
	public static HideAction Create(HideScript p)
	{
		HideAction hideAction = new HideAction(p.name);
		hideAction.InitScript(p);
		return hideAction;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000032A5 File Offset: 0x000016A5
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.HideObject(this.name);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x000032B7 File Offset: 0x000016B7
	public override void Action()
	{
	}

	// Token: 0x04000031 RID: 49
	public string name;
}
