using System;
using System.Xml;

// Token: 0x0200005F RID: 95
public class ShowUIScript : ScriptStruct
{
	// Token: 0x060001A4 RID: 420 RVA: 0x000066E0 File Offset: 0x00004AE0
	public static ShowUIScript Create(XmlNode node)
	{
		ShowUIScript showUIScript = new ShowUIScript();
		showUIScript.init(node.Attributes["name"].Value);
		return showUIScript;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000670F File Offset: 0x00004B0F
	public void init(string p)
	{
		this.kind = ScriptKind.ShowUI;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00006727 File Offset: 0x00004B27
	public override BaseAction CreateAction()
	{
		return ShowUIAction.Create(this);
	}

	// Token: 0x0400012E RID: 302
	public string name;
}
