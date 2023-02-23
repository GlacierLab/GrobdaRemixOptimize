using System;

// Token: 0x0200000C RID: 12
public class DelectLightAction : BaseAction
{
	// Token: 0x0600003A RID: 58 RVA: 0x00002A62 File Offset: 0x00000E62
	public DelectLightAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002A7C File Offset: 0x00000E7C
	public static DelectLightAction Create(DelectLightScript p)
	{
		DelectLightAction delectLightAction = new DelectLightAction(p.name);
		delectLightAction.InitScript(p);
		return delectLightAction;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002A9D File Offset: 0x00000E9D
	public override void Action()
	{
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002A9F File Offset: 0x00000E9F
	public override void FinishAction()
	{
		LightManager.GetInstance().Destroy(this.name);
	}

	// Token: 0x0400001F RID: 31
	public string name;
}
