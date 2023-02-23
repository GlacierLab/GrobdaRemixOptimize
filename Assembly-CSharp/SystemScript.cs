using System;
using System.Xml;

// Token: 0x02000064 RID: 100
public class SystemScript : ScriptStruct
{
	// Token: 0x060001B8 RID: 440 RVA: 0x00006864 File Offset: 0x00004C64
	public static SystemScript Create(XmlNode node)
	{
		SystemScript systemScript = new SystemScript();
		systemScript.init(node.Attributes["name"].Value, node.Attributes["value"].Value);
		return systemScript;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x000068A8 File Offset: 0x00004CA8
	public void init(string n, string v)
	{
		this.kind = ScriptKind.System;
		this.layout_id = null;
		this.name = n;
		this.value = v;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x000068C7 File Offset: 0x00004CC7
	public override BaseAction CreateAction()
	{
		return SystemAction.Create(this);
	}

	// Token: 0x04000136 RID: 310
	public string name;

	// Token: 0x04000137 RID: 311
	public string value;
}
