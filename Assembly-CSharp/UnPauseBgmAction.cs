using System;

// Token: 0x0200002C RID: 44
public class UnPauseBgmAction : BaseAction
{
	// Token: 0x060000CF RID: 207 RVA: 0x000040FA File Offset: 0x000024FA
	public UnPauseBgmAction(UnPauseBgmScript s)
	{
		this.script = s;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0000410C File Offset: 0x0000250C
	public static UnPauseBgmAction Create(UnPauseBgmScript s)
	{
		UnPauseBgmAction unPauseBgmAction = new UnPauseBgmAction(s);
		unPauseBgmAction.InitScript(s);
		return unPauseBgmAction;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00004128 File Offset: 0x00002528
	public override void Action()
	{
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x0000412A File Offset: 0x0000252A
	public override void FinishAction()
	{
		Singleton<BGMManager>.Instance.UnPauseBgm();
	}

	// Token: 0x0400005C RID: 92
	private UnPauseBgmScript script;
}
