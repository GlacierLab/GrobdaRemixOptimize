using System;

// Token: 0x02000013 RID: 19
internal class TextGroupAction : BaseAction
{
	// Token: 0x0600005E RID: 94 RVA: 0x0000312C File Offset: 0x0000152C
	public static TextGroupAction Create(TextGroupScript script)
	{
		TextGroupAction textGroupAction = new TextGroupAction();
		textGroupAction.init(script);
		textGroupAction.InitScript(script);
		return textGroupAction;
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003150 File Offset: 0x00001550
	private void init(TextGroupScript script)
	{
		if (Singleton<GameConfigManager>.Instance.config.TextVoiceStop)
		{
			Singleton<VoiceManager>.Instance.StopSE();
		}
		this.nameAction = (TextAction)script.nameScript.CreateAction();
		this.contentAction = (TextAction)script.conTextScript.CreateAction();
		this.voiceAction = (VoiceAction)script.voiceScript.CreateAction();
		this.nameAction.SetLayout(TextLayoutManager.GetInstance().GetLayout("name"));
		this.contentAction.SetLayout(TextLayoutManager.GetInstance().GetLayout("text"));
		this.contentAction.NeedPause = true;
		this.nameAction.IsNeedClear = true;
		this.nameAction.Init();
		this.contentAction.Init();
		this.nameAction.FinishAction();
		this.voiceAction.FinishAction();
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00003235 File Offset: 0x00001635
	public override void Init()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.ANIMATION);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003242 File Offset: 0x00001642
	public override void Action()
	{
		this.contentAction.Action();
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000324F File Offset: 0x0000164F
	public override void FinishAction()
	{
		this.contentAction.FinishAction();
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000325C File Offset: 0x0000165C
	public void ReplaySound()
	{
		this.voiceAction.FinishAction();
	}

	// Token: 0x0400002E RID: 46
	private TextAction nameAction;

	// Token: 0x0400002F RID: 47
	private TextAction contentAction;

	// Token: 0x04000030 RID: 48
	private VoiceAction voiceAction;
}
