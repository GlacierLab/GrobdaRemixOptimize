using System;

// Token: 0x02000024 RID: 36
public class SetGroupFlagAction : BaseAction
{
	// Token: 0x060000AD RID: 173 RVA: 0x00003C86 File Offset: 0x00002086
	public SetGroupFlagAction(string fName, bool fValue)
	{
		this.flagName = fName;
		this.flagValue = fValue;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00003C9C File Offset: 0x0000209C
	public static SetGroupFlagAction Create(SetGroupFlagScript sgfs)
	{
		SetGroupFlagAction setGroupFlagAction = new SetGroupFlagAction(sgfs.flagName, sgfs.flagValue);
		setGroupFlagAction.InitScript(sgfs);
		return setGroupFlagAction;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00003CC3 File Offset: 0x000020C3
	public override void Action()
	{
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00003CC5 File Offset: 0x000020C5
	public override void FinishAction()
	{
		CGSaveDataManager.GetInstance().SetGroupFlag(this.flagName);
	}

	// Token: 0x04000051 RID: 81
	private string flagName;

	// Token: 0x04000052 RID: 82
	private bool flagValue;
}
