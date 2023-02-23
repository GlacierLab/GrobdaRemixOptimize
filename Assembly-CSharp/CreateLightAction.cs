using System;

// Token: 0x0200000B RID: 11
public class CreateLightAction : BaseAction
{
	// Token: 0x06000036 RID: 54 RVA: 0x00002A14 File Offset: 0x00000E14
	public override void Action()
	{
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002A16 File Offset: 0x00000E16
	public override void FinishAction()
	{
		LightManager.GetInstance().CreateLight(this.script);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002A2C File Offset: 0x00000E2C
	public static BaseAction Create(CreateLightScript createLightScript)
	{
		CreateLightAction createLightAction = new CreateLightAction();
		createLightAction.init(createLightScript);
		createLightAction.InitScript(createLightScript);
		return createLightAction;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002A4E File Offset: 0x00000E4E
	private void init(CreateLightScript createLightScript)
	{
		this.script = createLightScript;
		this.LastTime = 0f;
	}

	// Token: 0x0400001E RID: 30
	private CreateLightScript script;
}
