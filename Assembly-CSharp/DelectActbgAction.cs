using System;

// Token: 0x0200000D RID: 13
public class DelectActbgAction : BaseAction
{
	// Token: 0x0600003E RID: 62 RVA: 0x00002AB1 File Offset: 0x00000EB1
	public DelectActbgAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002ACC File Offset: 0x00000ECC
	public static DelectActbgAction Create(DelectActbgScript p)
	{
		DelectActbgAction delectActbgAction = new DelectActbgAction(p.name);
		delectActbgAction.InitScript(p);
		return delectActbgAction;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00002AED File Offset: 0x00000EED
	public override void FinishAction()
	{
		ImageLayoutsManager.GetInstance().getLayoutByName(this.name, "default").SetActBgAction(null);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002B0A File Offset: 0x00000F0A
	public override void Action()
	{
	}

	// Token: 0x04000020 RID: 32
	public string name;
}
