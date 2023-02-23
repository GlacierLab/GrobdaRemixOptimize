using System;
using System.Xml;

// Token: 0x02000035 RID: 53
public class AddinScript : ScriptStruct
{
	// Token: 0x060000F7 RID: 247 RVA: 0x00004760 File Offset: 0x00002B60
	public static AddinScript Create(XmlNode node)
	{
		AddinScript addinScript = new AddinScript();
		addinScript.init(node.Attributes["name"].Value, node.Attributes["action"].Value);
		return addinScript;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x000047A4 File Offset: 0x00002BA4
	public void init(string p, string a)
	{
		this.kind = ScriptKind.Addin;
		this.name = p;
		this.action = a;
		this.layout_id = null;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000047C3 File Offset: 0x00002BC3
	public override BaseAction CreateAction()
	{
		return AddinAction.Create(this);
	}

	// Token: 0x04000074 RID: 116
	public string name;

	// Token: 0x04000075 RID: 117
	public string action;
}
