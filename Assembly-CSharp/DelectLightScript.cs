using System;
using System.Xml;

// Token: 0x0200003A RID: 58
public class DelectLightScript : ScriptStruct
{
	// Token: 0x0600010B RID: 267 RVA: 0x000049FC File Offset: 0x00002DFC
	public static DelectLightScript Create(XmlNode node)
	{
		DelectLightScript delectLightScript = new DelectLightScript();
		delectLightScript.init(node.Attributes["id"].Value);
		return delectLightScript;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00004A2B File Offset: 0x00002E2B
	public void init(string p)
	{
		this.kind = ScriptKind.DeleteLight;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00004A43 File Offset: 0x00002E43
	public override BaseAction CreateAction()
	{
		return DelectLightAction.Create(this);
	}

	// Token: 0x04000081 RID: 129
	public string name;
}
