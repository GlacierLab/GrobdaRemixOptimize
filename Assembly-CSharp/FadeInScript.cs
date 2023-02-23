using System;
using System.Xml;

// Token: 0x0200003D RID: 61
public class FadeInScript : ScriptStruct
{
	// Token: 0x06000117 RID: 279 RVA: 0x00004B04 File Offset: 0x00002F04
	public static FadeInScript Create(XmlNode node)
	{
		FadeInScript fadeInScript = new FadeInScript();
		fadeInScript.init(node.Attributes["id"].Value, XmlConvert.ToInt32(node.Attributes["time"].Value), 0f, 1f);
		fadeInScript.EndAplha = XmlUtil.GetFloatFromNode(node, "e", 1f);
		return fadeInScript;
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00004B6D File Offset: 0x00002F6D
	public void init(string id, int t, float s = 0f, float e = 1f)
	{
		this.kind = ScriptKind.FadeIn;
		this.layout_id = id;
		this.StartAplha = s;
		this.EndAplha = e;
		this.LastTime = t;
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00004B93 File Offset: 0x00002F93
	public override BaseAction CreateAction()
	{
		return FadeInAction.Create(this);
	}

	// Token: 0x04000084 RID: 132
	public int LastTime;

	// Token: 0x04000085 RID: 133
	public float StartAplha;

	// Token: 0x04000086 RID: 134
	public float EndAplha;
}
