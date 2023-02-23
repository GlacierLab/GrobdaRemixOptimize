using System;

// Token: 0x0200001D RID: 29
public class PlaySeAction : BaseAction
{
	// Token: 0x0600008D RID: 141 RVA: 0x000037FC File Offset: 0x00001BFC
	public PlaySeAction(PlaySeScript n)
	{
		this.script = n;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x0000380C File Offset: 0x00001C0C
	public static PlaySeAction Create(PlaySeScript n)
	{
		PlaySeAction playSeAction = new PlaySeAction(n);
		playSeAction.InitScript(n);
		return playSeAction;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00003828 File Offset: 0x00001C28
	public override void FinishAction()
	{
		Singleton<SEManager>.Instance.PlaySe(this.script.name, this.script.isLoop);
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0000384A File Offset: 0x00001C4A
	public override void Action()
	{
	}

	// Token: 0x04000040 RID: 64
	private PlaySeScript script;
}
