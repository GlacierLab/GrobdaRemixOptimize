using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class ShaderColorChangeAction : BaseAction
{
	// Token: 0x060000BA RID: 186 RVA: 0x00003F08 File Offset: 0x00002308
	public override void Init()
	{
		base.Init();
		this.script.startColor = this.layout.GetShaderColor();
		this.dColor = (this.script.endColor - this.script.startColor) / this.script.time;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00003F62 File Offset: 0x00002362
	public override void Action()
	{
		this.layout.SetShaderColor(this.layout.GetShaderColor() + this.dColor * Time.deltaTime);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00003F8F File Offset: 0x0000238F
	public override void FinishAction()
	{
		this.layout.SetShaderColor(this.script.endColor);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00003FA8 File Offset: 0x000023A8
	public static BaseAction Create(ShaderColorChangeScript shaderColorChangeScript)
	{
		ShaderColorChangeAction shaderColorChangeAction = new ShaderColorChangeAction();
		shaderColorChangeAction.init(shaderColorChangeScript);
		shaderColorChangeAction.InitScript(shaderColorChangeScript);
		return shaderColorChangeAction;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00003FCA File Offset: 0x000023CA
	private void init(ShaderColorChangeScript shaderColorChangeScript)
	{
		this.script = shaderColorChangeScript;
		this.LastTime = this.script.time;
	}

	// Token: 0x04000056 RID: 86
	private ShaderColorChangeScript script;

	// Token: 0x04000057 RID: 87
	private Color dColor;
}
