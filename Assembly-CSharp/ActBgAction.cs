using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class ActBgAction : BaseAction
{
	// Token: 0x06000008 RID: 8 RVA: 0x0000240A File Offset: 0x0000080A
	private ActBgAction(ActBgScript actBgScript)
	{
		this.script = actBgScript;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000241C File Offset: 0x0000081C
	public static ActBgAction Create(ActBgScript p)
	{
		ActBgAction actBgAction = new ActBgAction(p);
		actBgAction.InitScript(p);
		return actBgAction;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002438 File Offset: 0x00000838
	public override void Init()
	{
		this.CreateActBgLayout();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002441 File Offset: 0x00000841
	public override void Action()
	{
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002443 File Offset: 0x00000843
	public override void FinishAction()
	{
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002448 File Offset: 0x00000848
	public void UpdateGameObject(GameObject gameObject)
	{
		gameObject.transform.position += this.script.vp * Time.deltaTime;
		gameObject.transform.localScale += this.script.vs * Time.deltaTime;
		gameObject.transform.Rotate(this.script.vr * Time.deltaTime);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000024CC File Offset: 0x000008CC
	public void FinishGameObject(GameObject gameObject)
	{
		gameObject.transform.position = this.script.p + this.script.vp * this.script.time;
		gameObject.transform.localScale = this.script.s + this.script.vs * this.script.time;
		gameObject.transform.eulerAngles = this.script.r + this.script.vr * this.script.time;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000257C File Offset: 0x0000097C
	public void ResetActBgLayout()
	{
		this.script.vp = -this.script.vp;
		this.script.vs = -this.script.vs;
		this.script.vr = -this.script.vr;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000025DC File Offset: 0x000009DC
	private BaseLayout CreateActBgLayout()
	{
		BaseLayout baseLayout;
		if (ImageLayoutsManager.GetInstance().ContainsLayout(this.script.layout_id))
		{
			baseLayout = ImageLayoutsManager.GetInstance().getLayoutByName(this.script.layout_id, "default");
			this.script.p = baseLayout.gameObject.transform.position;
			this.script.s = baseLayout.gameObject.transform.localScale;
			this.script.r = baseLayout.gameObject.transform.eulerAngles;
		}
		else
		{
			baseLayout = ImageLayoutsManager.GetInstance().getLayoutByName(this.script.layout_id, "default");
			baseLayout.SetImage(this.script.path);
			baseLayout.SetMaterial(MaterialManager.GetInstance().GetMaterialByName(this.shader));
			baseLayout.shader = this.shader;
			GameObject gameObject = baseLayout.gameObject;
			gameObject.name = this.script.layout_id;
			this.script.p = gameObject.transform.position;
			gameObject.transform.localScale = this.script.s;
			gameObject.transform.eulerAngles = this.script.r;
			baseLayout.SetMaterial(MaterialManager.GetInstance().GetMaterialByName(this.script.shader));
		}
		baseLayout.SetActBgAction(this);
		return baseLayout;
	}

	// Token: 0x0400000D RID: 13
	public ActBgScript script;
}
