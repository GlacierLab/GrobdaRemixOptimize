using System;

// Token: 0x02000031 RID: 49
public class VoiceAction : BaseAction
{
	// Token: 0x060000E5 RID: 229 RVA: 0x0000448F File Offset: 0x0000288F
	private VoiceAction(VoiceScript voiceScript)
	{
		this.script = voiceScript;
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x000044A0 File Offset: 0x000028A0
	public static VoiceAction Create(VoiceScript n)
	{
		return new VoiceAction(n);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x000044B5 File Offset: 0x000028B5
	public override void Action()
	{
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x000044B7 File Offset: 0x000028B7
	public override void FinishAction()
	{
		Singleton<VoiceManager>.Instance.PlaySe(this.script.voice, false, this.script.vkind);
	}

	// Token: 0x04000065 RID: 101
	public VoiceScript script;
}
