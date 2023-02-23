using System;
using System.Xml;

// Token: 0x02000062 RID: 98
public class UnPauseBgmScript : ScriptStruct
{
	// Token: 0x060001B0 RID: 432 RVA: 0x000067D8 File Offset: 0x00004BD8
	public static UnPauseBgmScript Create(XmlNode node)
	{
		UnPauseBgmScript unPauseBgmScript = new UnPauseBgmScript();
		unPauseBgmScript.init(node);
		return unPauseBgmScript;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x000067F3 File Offset: 0x00004BF3
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.UnPauseBgm;
		this.name = XmlUtil.GetStringFromNode(node, "name");
		this.layout_id = null;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00006815 File Offset: 0x00004C15
	public override BaseAction CreateAction()
	{
		return UnPauseBgmAction.Create(this);
	}

	// Token: 0x04000133 RID: 307
	public string name;

	// Token: 0x04000134 RID: 308
	public int time;

	// Token: 0x04000135 RID: 309
	public bool con;
}
