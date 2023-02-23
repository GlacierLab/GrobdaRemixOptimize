using System;

// Token: 0x02000018 RID: 24
public class LoadAction : BaseAction
{
	// Token: 0x06000078 RID: 120 RVA: 0x00003493 File Offset: 0x00001893
	public LoadAction(string p)
	{
		this.path = p;
		this.LastTime = 0f;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000034B0 File Offset: 0x000018B0
	public static LoadAction Create(LoadScript p)
	{
		LoadAction loadAction = new LoadAction(p.path);
		loadAction.InitScript(p);
		return loadAction;
	}

	// Token: 0x0600007A RID: 122 RVA: 0x000034D1 File Offset: 0x000018D1
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.LoadScript(this.path, true);
	}

	// Token: 0x0600007B RID: 123 RVA: 0x000034E4 File Offset: 0x000018E4
	public override void Action()
	{
	}

	// Token: 0x04000037 RID: 55
	public string path;
}
