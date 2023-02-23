using System;

// Token: 0x0200001C RID: 28
public class PlayBgmAction : BaseAction
{
	// Token: 0x06000089 RID: 137 RVA: 0x000037A9 File Offset: 0x00001BA9
	public PlayBgmAction(PlayBgmScript n)
		: base(n)
	{
		this.name = n.name;
		this.script = n;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000037C8 File Offset: 0x00001BC8
	public static PlayBgmAction Create(PlayBgmScript n)
	{
		return new PlayBgmAction(n);
	}

	// Token: 0x0600008B RID: 139 RVA: 0x000037DD File Offset: 0x00001BDD
	public override void FinishAction()
	{
		Singleton<BGMManager>.Instance.PlayBGM(this.name, false);
		Singleton<BGMManager>.Instance.CheckBGM();
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000037FA File Offset: 0x00001BFA
	public override void Action()
	{
	}

	// Token: 0x0400003E RID: 62
	public string name;

	// Token: 0x0400003F RID: 63
	public PlayBgmScript script;
}
