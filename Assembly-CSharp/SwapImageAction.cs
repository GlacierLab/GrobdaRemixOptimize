using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class SwapImageAction : BaseAction
{
	// Token: 0x06000057 RID: 87 RVA: 0x00002EB0 File Offset: 0x000012B0
	public static SwapImageAction Create(SwapImageScript s)
	{
		SwapImageAction swapImageAction = new SwapImageAction();
		swapImageAction.init(s);
		swapImageAction.InitScript(s);
		return swapImageAction;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002ED4 File Offset: 0x000012D4
	private void init(SwapImageScript swapImageScript)
	{
		this.script = swapImageScript;
		this.fadein = (FadeInAction)this.script.fadein.CreateAction();
		this.fadeOut = (FadeOutAction)this.script.fadeout.CreateAction();
		this.setImage = (SetImageAction)this.script.setImage.CreateAction();
		this.delete = (DeleteLayoutAction)this.script.delete.CreateAction();
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00002F54 File Offset: 0x00001354
	public override void Init()
	{
		this.setImage.Init();
		this.test = ImageLayoutsManager.GetInstance().getLayoutByName("test", "default");
		this.test.FinishAction();
		this.id = ImageLayoutsManager.GetInstance().getLayoutByName(this.script.id, "default");
		if (this.script.copy)
		{
			this.test.SetAplha(0.8f);
		}
		else
		{
			this.test.SetAplha(0f);
		}
		this.fadein.SetLayout(this.test);
		this.fadeOut.SetLayout(this.id);
		if (this.script.copy)
		{
			this.test.transform.position = this.id.transform.position;
			this.test.transform.localScale = this.id.transform.localScale;
			this.test.transform.eulerAngles = this.id.transform.eulerAngles;
		}
		Vector3 position = this.test.transform.position;
		position.z = this.id.transform.position.z;
		this.test.transform.position = position;
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.ANIMATION);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x000030C4 File Offset: 0x000014C4
	public override void Action()
	{
	}

	// Token: 0x0600005B RID: 91 RVA: 0x000030C6 File Offset: 0x000014C6
	public override void FinishAction()
	{
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000030C8 File Offset: 0x000014C8
	public override void Dispose()
	{
		this.fadein.FinishAction();
		this.fadeOut.FinishAction();
		this.delete.SetLayout(this.id);
		this.delete.FinishAction();
		ImageLayoutsManager.GetInstance().ChangeName("test", this.script.id);
	}

	// Token: 0x04000027 RID: 39
	private FadeInAction fadein;

	// Token: 0x04000028 RID: 40
	private FadeOutAction fadeOut;

	// Token: 0x04000029 RID: 41
	private SetImageAction setImage;

	// Token: 0x0400002A RID: 42
	private DeleteLayoutAction delete;

	// Token: 0x0400002B RID: 43
	private SwapImageScript script;

	// Token: 0x0400002C RID: 44
	private BaseLayout test;

	// Token: 0x0400002D RID: 45
	private BaseLayout id;
}
