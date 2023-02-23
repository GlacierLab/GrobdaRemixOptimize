using System;
using System.Xml;

// Token: 0x02000061 RID: 97
public class PauseBgmScript : ScriptStruct
{
	// Token: 0x060001AC RID: 428 RVA: 0x00006788 File Offset: 0x00004B88
	public static PauseBgmScript Create(XmlNode node)
	{
		PauseBgmScript pauseBgmScript = new PauseBgmScript();
		pauseBgmScript.init(node);
		return pauseBgmScript;
	}

	// Token: 0x060001AD RID: 429 RVA: 0x000067A3 File Offset: 0x00004BA3
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.PauseBgm;
		this.name = XmlUtil.GetStringFromNode(node, "name");
		this.layout_id = null;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x000067C5 File Offset: 0x00004BC5
	public override BaseAction CreateAction()
	{
		return PauseBgmAction.Create(this);
	}

	// Token: 0x04000130 RID: 304
	public string name;

	// Token: 0x04000131 RID: 305
	public int time;

	// Token: 0x04000132 RID: 306
	public bool con;
}
