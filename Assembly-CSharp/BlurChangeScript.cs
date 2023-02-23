using System;
using System.Xml;

// Token: 0x02000036 RID: 54
public class BlurChangeScript : ScriptStruct
{
	// Token: 0x060000FB RID: 251 RVA: 0x000047D4 File Offset: 0x00002BD4
	public static BlurChangeScript Create(XmlNode node)
	{
		BlurChangeScript blurChangeScript = new BlurChangeScript();
		blurChangeScript.init(node);
		return blurChangeScript;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000047F0 File Offset: 0x00002BF0
	private void init(XmlNode node)
	{
		this.size = XmlUtil.GetFloatFromNode(node, "size", 0f);
		this.Need_SetLayout = false;
		this.time = XmlUtil.GetFloatFromNode(node, "time", 0f) / 1000f;
		this.layout_id = "camera";
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00004841 File Offset: 0x00002C41
	public override BaseAction CreateAction()
	{
		return BlurChangeAction.Create(this);
	}

	// Token: 0x04000076 RID: 118
	public float size;

	// Token: 0x04000077 RID: 119
	public float time;
}
