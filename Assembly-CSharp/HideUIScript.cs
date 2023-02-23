using System;
using System.Xml;

// Token: 0x02000044 RID: 68
public class HideUIScript : ScriptStruct
{
	// Token: 0x06000133 RID: 307 RVA: 0x00004FB8 File Offset: 0x000033B8
	public static HideUIScript Create(XmlNode node)
	{
		HideUIScript hideUIScript = new HideUIScript();
		hideUIScript.init(node.Attributes["name"].Value);
		return hideUIScript;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00004FE7 File Offset: 0x000033E7
	public void init(string p)
	{
		this.kind = ScriptKind.HideUI;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00004FFF File Offset: 0x000033FF
	public override BaseAction CreateAction()
	{
		return HideUIAction.Create(this);
	}

	// Token: 0x04000097 RID: 151
	public string name;
}
