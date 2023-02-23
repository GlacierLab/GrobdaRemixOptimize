using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
public class LightLayout : Layout
{
	// Token: 0x06000227 RID: 551 RVA: 0x0000799E File Offset: 0x00005D9E
	private void Awake()
	{
		this.kind = LayoutKind.Image;
		this.spriteRender = base.gameObject.GetComponent<SpriteRenderer>();
		this.l = base.gameObject.GetComponent<Light>();
	}

	// Token: 0x06000228 RID: 552 RVA: 0x000079C9 File Offset: 0x00005DC9
	public override void ConfigSaveData(SaveData data)
	{
	}

	// Token: 0x06000229 RID: 553 RVA: 0x000079CB File Offset: 0x00005DCB
	public override void SetLightPower(float p)
	{
		this.l.intensity = p;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000079D9 File Offset: 0x00005DD9
	public override void SetLightRange(float p)
	{
		this.l.range = p;
	}

	// Token: 0x0600022B RID: 555 RVA: 0x000079E7 File Offset: 0x00005DE7
	public override void AddLightPower(float p)
	{
		this.l.intensity += p;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x000079FC File Offset: 0x00005DFC
	public override void AddLightRange(float p)
	{
		this.l.range += p;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00007A11 File Offset: 0x00005E11
	public override Light GetLight()
	{
		return this.l;
	}

	// Token: 0x0400017F RID: 383
	private Light l;
}
