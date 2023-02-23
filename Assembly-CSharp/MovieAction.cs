using System;

// Token: 0x0200001B RID: 27
public class MovieAction : BaseAction
{
	// Token: 0x06000085 RID: 133 RVA: 0x0000375E File Offset: 0x00001B5E
	public MovieAction(MovieScript script)
		: base(script)
	{
		this.moveScript = script;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000376E File Offset: 0x00001B6E
	public override void Action()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00003775 File Offset: 0x00001B75
	public override void FinishAction()
	{
		GameConfigManager.ChangeSkipMode(false);
		Singleton<MovieManager>.Instance.PlayMovie(this.moveScript.name, false);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00003794 File Offset: 0x00001B94
	public static BaseAction Create(MovieScript script)
	{
		return new MovieAction(script);
	}

	// Token: 0x0400003D RID: 61
	public MovieScript moveScript;
}
