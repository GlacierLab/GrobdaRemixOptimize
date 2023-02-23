using System;

// Token: 0x0200000E RID: 14
public class DeleteLayoutAction : BaseAction
{
	// Token: 0x06000042 RID: 66 RVA: 0x00002B0C File Offset: 0x00000F0C
	public DeleteLayoutAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002B28 File Offset: 0x00000F28
	public static DeleteLayoutAction Create(DeleteLayoutScript p)
	{
		DeleteLayoutAction deleteLayoutAction = new DeleteLayoutAction(p.name);
		deleteLayoutAction.InitScript(p);
		return deleteLayoutAction;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002B49 File Offset: 0x00000F49
	public override void FinishAction()
	{
		ImageLayoutsManager.GetInstance().RemoveLayout(this.name);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002B5B File Offset: 0x00000F5B
	public override void Action()
	{
	}

	// Token: 0x04000021 RID: 33
	public string name;
}
