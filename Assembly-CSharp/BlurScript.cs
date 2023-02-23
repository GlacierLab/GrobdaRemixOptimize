using System;
using System.Xml;

// Token: 0x02000037 RID: 55
public class BlurScript : ScriptStruct
{
	// Token: 0x060000FF RID: 255 RVA: 0x00004854 File Offset: 0x00002C54
	public static BlurScript Create(XmlNode node)
	{
		BlurScript blurScript = new BlurScript();
		blurScript.init(node);
		return blurScript;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000486F File Offset: 0x00002C6F
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.Blur;
		this.layout_id = null;
		this.action = XmlUtil.GetStringFromNode(node, "action", "show");
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00004896 File Offset: 0x00002C96
	public override BaseAction CreateAction()
	{
		return BlurAction.Create(this);
	}

	// Token: 0x04000078 RID: 120
	public string action;
}
