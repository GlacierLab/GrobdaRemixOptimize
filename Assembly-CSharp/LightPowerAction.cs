using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class LightPowerAction : BaseAction
{
	// Token: 0x0600006D RID: 109 RVA: 0x00003310 File Offset: 0x00001710
	public override void Action()
	{
		this.layout.AddLightPower(this.vp * Time.deltaTime);
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00003329 File Offset: 0x00001729
	public override void FinishAction()
	{
		this.layout.SetLightPower(this.script.power);
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00003344 File Offset: 0x00001744
	public static BaseAction Create(LightPowerScript lightPowerScript)
	{
		LightPowerAction lightPowerAction = new LightPowerAction();
		lightPowerAction.init(lightPowerScript);
		lightPowerAction.InitScript(lightPowerScript);
		return lightPowerAction;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00003366 File Offset: 0x00001766
	private void init(LightPowerScript lightPowerScript)
	{
		this.script = lightPowerScript;
		this.LastTime = this.script.time;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00003380 File Offset: 0x00001780
	public override void Init()
	{
		base.Init();
		Light light = this.layout.GetLight();
		if (light != null)
		{
			this.vp = (this.script.power - light.intensity) / this.script.time;
		}
	}

	// Token: 0x04000033 RID: 51
	public LightPowerScript script;

	// Token: 0x04000034 RID: 52
	private float vp;
}
