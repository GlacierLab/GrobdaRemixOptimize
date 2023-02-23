using System;

// Token: 0x02000056 RID: 86
public abstract class ScriptStruct
{
	// Token: 0x06000183 RID: 387
	public abstract BaseAction CreateAction();

	// Token: 0x04000116 RID: 278
	public ScriptKind kind = ScriptKind.Null;

	// Token: 0x04000117 RID: 279
	public string layout_id;

	// Token: 0x04000118 RID: 280
	public bool Need_SetLayout = true;

	// Token: 0x04000119 RID: 281
	public string xmlnode;
}
