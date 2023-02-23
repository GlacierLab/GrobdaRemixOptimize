using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class LightRangeAction : BaseAction
{
	// Token: 0x06000073 RID: 115 RVA: 0x000033D7 File Offset: 0x000017D7
	public override void Action()
	{
		this.layout.AddLightRange(this.vg * Time.deltaTime);
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000033F0 File Offset: 0x000017F0
	public override void FinishAction()
	{
		this.layout.SetLightRange(this.script.range);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00003408 File Offset: 0x00001808
	public static BaseAction Create(LightRangeScript lightPowerScript)
	{
		LightRangeAction lightRangeAction = new LightRangeAction();
		lightRangeAction.init(lightPowerScript);
		lightRangeAction.InitScript(lightPowerScript);
		return lightRangeAction;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x0000342A File Offset: 0x0000182A
	private void init(LightRangeScript lightPowerScript)
	{
		this.script = lightPowerScript;
		this.LastTime = this.script.time;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003444 File Offset: 0x00001844
	public override void Init()
	{
		base.Init();
		Light light = this.layout.GetLight();
		if (light != null)
		{
			this.vg = (this.script.range - light.range) / this.script.time;
		}
	}

	// Token: 0x04000035 RID: 53
	public LightRangeScript script;

	// Token: 0x04000036 RID: 54
	private float vg;
}
