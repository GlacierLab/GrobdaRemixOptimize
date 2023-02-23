using System;
using System.Xml;

// Token: 0x0200003E RID: 62
public class FadeOutScript : ScriptStruct
{
	// Token: 0x0600011B RID: 283 RVA: 0x00004BA4 File Offset: 0x00002FA4
	public static FadeOutScript Create(XmlNode node)
	{
		FadeOutScript fadeOutScript = new FadeOutScript();
		fadeOutScript.init(node.Attributes["id"].Value, XmlConvert.ToInt32(node.Attributes["time"].Value), 1f, 0f);
		return fadeOutScript;
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00004BF7 File Offset: 0x00002FF7
	public void init(string id, int t, float s = 1f, float e = 0f)
	{
		this.kind = ScriptKind.FadeOut;
		this.layout_id = id;
		this.StartAplha = s;
		this.EndAplha = e;
		this.LastTime = t;
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00004C1D File Offset: 0x0000301D
	public override BaseAction CreateAction()
	{
		return FadeOutAction.Create(this);
	}

	// Token: 0x04000087 RID: 135
	public int LastTime;

	// Token: 0x04000088 RID: 136
	public float StartAplha;

	// Token: 0x04000089 RID: 137
	public float EndAplha;
}
