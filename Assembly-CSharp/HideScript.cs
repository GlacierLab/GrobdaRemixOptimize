using System;
using System.Xml;

// Token: 0x02000043 RID: 67
public class HideScript : ScriptStruct
{
	// Token: 0x0600012F RID: 303 RVA: 0x00004F60 File Offset: 0x00003360
	public static HideScript Create(XmlNode node)
	{
		HideScript hideScript = new HideScript();
		hideScript.init(node.Attributes["name"].Value);
		return hideScript;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00004F8F File Offset: 0x0000338F
	public void init(string p)
	{
		this.kind = ScriptKind.Hide;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00004FA7 File Offset: 0x000033A7
	public override BaseAction CreateAction()
	{
		return HideAction.Create(this);
	}

	// Token: 0x04000096 RID: 150
	public string name;
}
