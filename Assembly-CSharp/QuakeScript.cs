using System;
using System.Xml;

// Token: 0x0200004E RID: 78
public class QuakeScript : ScriptStruct
{
	// Token: 0x0600015B RID: 347 RVA: 0x000053C8 File Offset: 0x000037C8
	public static QuakeScript Create(XmlNode node)
	{
		QuakeScript quakeScript = new QuakeScript();
		quakeScript.init(node);
		return quakeScript;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x000053E4 File Offset: 0x000037E4
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.Quake;
		this.w = XmlUtil.GetFloatFromNode(node, "w", 0.1f);
		this.h = XmlUtil.GetFloatFromNode(node, "h", 0.1f);
		this.LastTime = XmlUtil.GetFloatFromNode(node, "time", 2f) / 1000f;
		this.interval = XmlUtil.GetIntFromNode(node, "i", 5);
		this.layout_id = "camera";
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000545D File Offset: 0x0000385D
	public override BaseAction CreateAction()
	{
		return new QuakeAction(this);
	}

	// Token: 0x040000A8 RID: 168
	public float LastTime;

	// Token: 0x040000A9 RID: 169
	public float w;

	// Token: 0x040000AA RID: 170
	public float h;

	// Token: 0x040000AB RID: 171
	public int interval;
}
