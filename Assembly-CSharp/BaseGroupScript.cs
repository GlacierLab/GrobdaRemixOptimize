using System;

// Token: 0x0200003F RID: 63
public abstract class BaseGroupScript : ScriptStruct
{
	// Token: 0x0600011E RID: 286 RVA: 0x00004C25 File Offset: 0x00003025
	public BaseGroupScript()
	{
		this.kind = ScriptKind.Group;
		this.Need_SetLayout = false;
	}
}
