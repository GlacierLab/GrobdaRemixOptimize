using System;
using System.Xml;

// Token: 0x0200004A RID: 74
public class MovieScript : ScriptStruct
{
	// Token: 0x0600014B RID: 331 RVA: 0x00005264 File Offset: 0x00003664
	public static MovieScript Create(XmlNode node)
	{
		MovieScript movieScript = new MovieScript();
		movieScript.init(node);
		return movieScript;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000527F File Offset: 0x0000367F
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.Movie;
		this.name = XmlUtil.GetStringFromNode(node, "name");
		this.layout_id = null;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000052A1 File Offset: 0x000036A1
	public override BaseAction CreateAction()
	{
		return MovieAction.Create(this);
	}

	// Token: 0x040000A2 RID: 162
	public string name;
}
