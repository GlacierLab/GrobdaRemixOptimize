using System;
using System.Xml;

// Token: 0x02000039 RID: 57
public class CreateScript : ScriptStruct
{
	// Token: 0x06000107 RID: 263 RVA: 0x000049A4 File Offset: 0x00002DA4
	public static CreateScript Create(XmlNode node)
	{
		CreateScript createScript = new CreateScript();
		createScript.init(node.Attributes["name"].Value);
		return createScript;
	}

	// Token: 0x06000108 RID: 264 RVA: 0x000049D3 File Offset: 0x00002DD3
	public void init(string p)
	{
		this.kind = ScriptKind.Create;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x06000109 RID: 265 RVA: 0x000049EB File Offset: 0x00002DEB
	public override BaseAction CreateAction()
	{
		return global::CreateAction.Create(this);
	}

	// Token: 0x04000080 RID: 128
	public string name;
}
