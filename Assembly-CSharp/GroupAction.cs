using System;
using System.Collections.Generic;

// Token: 0x02000011 RID: 17
public class GroupAction : BaseAction
{
	// Token: 0x0600004F RID: 79 RVA: 0x00002D18 File Offset: 0x00001118
	public static GroupAction Create(GroupScript script)
	{
		GroupAction groupAction = new GroupAction();
		groupAction.init(script);
		groupAction.InitScript(script);
		return groupAction;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002D3C File Offset: 0x0000113C
	public void init(GroupScript script)
	{
		List<ScriptStruct> allList = script.GetAllList();
		this.LastTime = 100000f;
		foreach (ScriptStruct scriptStruct in allList)
		{
			BaseAction baseAction = scriptStruct.CreateAction();
			baseAction.SetLayout(Singleton<AVGManager>.Instance, scriptStruct.layout_id);
			this.baseActions.Add(baseAction);
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002DC4 File Offset: 0x000011C4
	public override void Init()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.ANIMATION);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002DD1 File Offset: 0x000011D1
	public override void SetLayout(BaseLayout l)
	{
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002DD3 File Offset: 0x000011D3
	public override void animation()
	{
		if (this.baseActions.Count != 0)
		{
			this.Action();
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002DEC File Offset: 0x000011EC
	public override void Action()
	{
		int i = 0;
		while (i < this.baseActions.Count)
		{
			BaseAction baseAction = this.baseActions[i];
			if (baseAction.IsFinish())
			{
				baseAction.FinishAction();
				this.baseActions.RemoveAt(i);
			}
			else
			{
				baseAction.Action();
				i++;
			}
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00002E4C File Offset: 0x0000124C
	public override void FinishAction()
	{
		foreach (BaseAction baseAction in this.baseActions)
		{
			baseAction.FinishAction();
		}
	}

	// Token: 0x04000026 RID: 38
	private List<BaseAction> baseActions = new List<BaseAction>();
}
