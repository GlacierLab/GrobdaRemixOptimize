using System;
using System.Xml;

// Token: 0x0200003C RID: 60
public class DeleteLayoutScript : ScriptStruct
{
	// Token: 0x06000113 RID: 275 RVA: 0x00004AAC File Offset: 0x00002EAC
	public static DeleteLayoutScript Create(XmlNode node)
	{
		DeleteLayoutScript deleteLayoutScript = new DeleteLayoutScript();
		deleteLayoutScript.init(node.Attributes["name"].Value);
		return deleteLayoutScript;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00004ADB File Offset: 0x00002EDB
	public void init(string p)
	{
		this.kind = ScriptKind.Delete;
		this.layout_id = null;
		this.name = p;
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00004AF3 File Offset: 0x00002EF3
	public override BaseAction CreateAction()
	{
		return DeleteLayoutAction.Create(this);
	}

	// Token: 0x04000083 RID: 131
	public string name;
}
