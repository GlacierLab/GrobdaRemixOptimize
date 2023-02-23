using System;

// Token: 0x02000030 RID: 48
public class TextVisibleAction : BaseAction
{
	// Token: 0x060000E1 RID: 225 RVA: 0x0000442B File Offset: 0x0000282B
	public TextVisibleAction(bool vValue)
	{
		this.visibleValue = vValue;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0000443C File Offset: 0x0000283C
	public static TextVisibleAction Create(TextVisibleScript tvs)
	{
		TextVisibleAction textVisibleAction = new TextVisibleAction(tvs.visibleValue);
		textVisibleAction.InitScript(tvs);
		return textVisibleAction;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000445D File Offset: 0x0000285D
	public override void Action()
	{
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000445F File Offset: 0x0000285F
	public override void FinishAction()
	{
		if (this.visibleValue)
		{
			Singleton<UIManager>.Instance.ShowUi("text");
		}
		else
		{
			Singleton<UIManager>.Instance.HideUi("text");
		}
	}

	// Token: 0x04000064 RID: 100
	private bool visibleValue;
}
