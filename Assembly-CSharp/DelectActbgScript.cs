using System;
using System.Xml;

// Token: 0x0200003B RID: 59
public class DelectActbgScript : ScriptStruct
{
	// Token: 0x0600010F RID: 271 RVA: 0x00004A54 File Offset: 0x00002E54
	public static DelectActbgScript Create(XmlNode node)
	{
		DelectActbgScript delectActbgScript = new DelectActbgScript();
		delectActbgScript.init(node.Attributes["name"].Value);
		return delectActbgScript;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00004A83 File Offset: 0x00002E83
	public void init(string p)
	{
		this.kind = ScriptKind.DeleteActBg;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00004A9B File Offset: 0x00002E9B
	public override BaseAction CreateAction()
	{
		return DelectActbgAction.Create(this);
	}

	// Token: 0x04000082 RID: 130
	public string name;
}
