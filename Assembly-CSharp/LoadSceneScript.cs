using System;
using System.Xml;

// Token: 0x02000048 RID: 72
public class LoadSceneScript : ScriptStruct
{
	// Token: 0x06000143 RID: 323 RVA: 0x00005168 File Offset: 0x00003568
	public static LoadSceneScript Create(XmlNode node)
	{
		LoadSceneScript loadSceneScript = new LoadSceneScript();
		loadSceneScript.init(XmlUtil.GetStringFromNode(node, "path"));
		return loadSceneScript;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0000518D File Offset: 0x0000358D
	public void init(string p)
	{
		this.kind = ScriptKind.Load;
		this.path = p;
		this.layout_id = null;
	}

	// Token: 0x06000145 RID: 325 RVA: 0x000051A5 File Offset: 0x000035A5
	public override BaseAction CreateAction()
	{
		return LoadSceneAction.Create(this);
	}

	// Token: 0x0400009D RID: 157
	public string path;
}
