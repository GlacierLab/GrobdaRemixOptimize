using System;
using System.Xml;

// Token: 0x02000047 RID: 71
public class LoadScript : ScriptStruct
{
	// Token: 0x0600013F RID: 319 RVA: 0x00005118 File Offset: 0x00003518
	public static LoadScript Create(XmlNode node)
	{
		LoadScript loadScript = new LoadScript();
		loadScript.init(XmlUtil.GetStringFromNode(node, "path"));
		return loadScript;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000513D File Offset: 0x0000353D
	public void init(string p)
	{
		this.kind = ScriptKind.Load;
		this.path = p;
		this.layout_id = null;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00005155 File Offset: 0x00003555
	public override BaseAction CreateAction()
	{
		return LoadAction.Create(this);
	}

	// Token: 0x0400009C RID: 156
	public string path;
}
