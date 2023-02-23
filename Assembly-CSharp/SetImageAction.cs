using System;

// Token: 0x02000025 RID: 37
public class SetImageAction : BaseAction
{
	// Token: 0x060000B1 RID: 177 RVA: 0x00003CD7 File Offset: 0x000020D7
	public SetImageAction(SetImageScript p)
	{
		this.script = p;
		this.shader = p.shader;
		this.LastTime = 0f;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00003D00 File Offset: 0x00002100
	public static SetImageAction Create(SetImageScript p)
	{
		SetImageAction setImageAction = new SetImageAction(p);
		setImageAction.InitScript(p);
		return setImageAction;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00003D1C File Offset: 0x0000211C
	public override void FinishAction()
	{
		this.layout.SetImage(this.script.path);
		this.LiveTime = this.LastTime;
		if (this.script.shader != null || this.layout.GetMaterial() == null)
		{
			this.layout.SetMaterial(MaterialManager.GetInstance().GetMaterialByName(this.shader));
		}
		float z = this.script.p.z;
		if ((double)Math.Abs(z) > 1E-08)
		{
			this.script.p.z = z;
		}
		else
		{
			this.script.p.z = this.layout.transform.position.z;
		}
		this.layout.SetActBgAction(null);
		this.layout.transform.position = this.script.p;
		this.layout.transform.localScale = this.script.s;
		this.layout.SetColor(this.script.c);
		this.layout.SetShaderColor(this.script.shader_color);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00003E5E File Offset: 0x0000225E
	public override void Action()
	{
	}

	// Token: 0x04000053 RID: 83
	public SetImageScript script;
}
