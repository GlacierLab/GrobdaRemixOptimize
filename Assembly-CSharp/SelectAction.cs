using System;

// Token: 0x02000022 RID: 34
public class SelectAction : BaseAction
{
	// Token: 0x060000A4 RID: 164 RVA: 0x00003BC1 File Offset: 0x00001FC1
	public SelectScript GetSelectScript()
	{
		return this.selectScript;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00003BCC File Offset: 0x00001FCC
	public static SelectAction Create(SelectScript script)
	{
		SelectAction selectAction = new SelectAction();
		selectAction.init(script);
		selectAction.InitScript(script);
		return selectAction;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00003BEE File Offset: 0x00001FEE
	private void init(SelectScript script)
	{
		this.selectScript = script;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00003BF7 File Offset: 0x00001FF7
	public override void Action()
	{
		throw new NotImplementedException();
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00003C00 File Offset: 0x00002000
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.SELECTPAUSE);
		SelectLayout selectLayout = SelectLayoutManager.GetInstance().GetSelectLayout();
		selectLayout.SetAction(this);
	}

	// Token: 0x0400004E RID: 78
	private SelectScript selectScript;
}
