using System;
using System.Xml;

// Token: 0x0200005E RID: 94
public class ShowScript : ScriptStruct
{
	// Token: 0x060001A0 RID: 416 RVA: 0x00006688 File Offset: 0x00004A88
	public static ShowScript Create(XmlNode node)
	{
		ShowScript showScript = new ShowScript();
		showScript.init(node.Attributes["name"].Value);
		return showScript;
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x000066B7 File Offset: 0x00004AB7
	public void init(string p)
	{
		this.kind = ScriptKind.Show;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000066CF File Offset: 0x00004ACF
	public override BaseAction CreateAction()
	{
		return ShowAction.Create(this);
	}

	// Token: 0x0400012D RID: 301
	public string name;
}
