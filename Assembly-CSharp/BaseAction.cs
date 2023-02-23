using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
[Serializable]
public abstract class BaseAction
{
	// Token: 0x06000015 RID: 21 RVA: 0x000022A3 File Offset: 0x000006A3
	public BaseAction()
	{
		long num = BaseAction.index;
		BaseAction.index = num + 1L;
		this.uid = num;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000022BF File Offset: 0x000006BF
	public BaseAction(ScriptStruct script)
	{
		long num = BaseAction.index;
		BaseAction.index = num + 1L;
		this.uid = num;
		this.InitScript(script);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000022E2 File Offset: 0x000006E2
	public bool IsFinish()
	{
		return this.LiveTime >= this.LastTime;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000022F5 File Offset: 0x000006F5
	public void InitScript(ScriptStruct script)
	{
		this.baseScriptStruct = script;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002300 File Offset: 0x00000700
	public virtual void Init()
	{
		if (this.baseScriptStruct.layout_id == null && this.baseScriptStruct.kind != ScriptKind.Group)
		{
			Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.WAIT);
			this.FinishAction();
			return;
		}
		this.SetLayout(ImageLayoutsManager.GetInstance().getLayoutByName(this.baseScriptStruct.layout_id, this.shader));
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.ANIMATION);
	}

	// Token: 0x0600001A RID: 26
	public abstract void Action();

	// Token: 0x0600001B RID: 27
	public abstract void FinishAction();

	// Token: 0x0600001C RID: 28 RVA: 0x0000236D File Offset: 0x0000076D
	public virtual void Dispose()
	{
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000236F File Offset: 0x0000076F
	public virtual void SetLayout(AVGManager m, string id)
	{
		if (id == null)
		{
			return;
		}
		this.layout = ImageLayoutsManager.GetInstance().getLayoutByName(id, this.shader);
		if (this.layout != null)
		{
			this.layout.SetAction(this);
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000023AC File Offset: 0x000007AC
	public virtual void SetLayout(BaseLayout l)
	{
		this.layout = l;
		if (this.layout != null)
		{
			this.layout.SetAction(this);
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000023D2 File Offset: 0x000007D2
	public virtual void animation()
	{
		this.LiveTime += Time.deltaTime;
		if (this.LiveTime < this.LastTime)
		{
			this.Action();
		}
		else
		{
			this.FinishAction();
		}
	}

	// Token: 0x04000010 RID: 16
	public BaseLayout layout;

	// Token: 0x04000011 RID: 17
	public ScriptStruct baseScriptStruct;

	// Token: 0x04000012 RID: 18
	public float LastTime;

	// Token: 0x04000013 RID: 19
	public float LiveTime;

	// Token: 0x04000014 RID: 20
	public bool NeedPause;

	// Token: 0x04000015 RID: 21
	public string shader;

	// Token: 0x04000016 RID: 22
	public bool isBgm;

	// Token: 0x04000017 RID: 23
	public long uid;

	// Token: 0x04000018 RID: 24
	private static long index;
}
