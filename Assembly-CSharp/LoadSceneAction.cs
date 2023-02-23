using System;

// Token: 0x02000019 RID: 25
public class LoadSceneAction : BaseAction
{
	// Token: 0x0600007C RID: 124 RVA: 0x000034E6 File Offset: 0x000018E6
	public LoadSceneAction(string p)
	{
		this.path = p;
		this.LastTime = 0f;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00003500 File Offset: 0x00001900
	public static LoadSceneAction Create(LoadSceneScript p)
	{
		LoadSceneAction loadSceneAction = new LoadSceneAction(p.path);
		loadSceneAction.InitScript(p);
		return loadSceneAction;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00003521 File Offset: 0x00001921
	public override void FinishAction()
	{
		ScriptExecute.GetInstance().LoadScriptFromResource(this.path);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00003533 File Offset: 0x00001933
	public override void Action()
	{
	}

	// Token: 0x04000038 RID: 56
	public string path;
}
