using System;
using System.Xml;
using UnityEngine;

// Token: 0x0200005D RID: 93
public class ShaderColorChangeScript : ScriptStruct
{
	// Token: 0x0600019C RID: 412 RVA: 0x000065D8 File Offset: 0x000049D8
	public static ShaderColorChangeScript Create(XmlNode node)
	{
		ShaderColorChangeScript shaderColorChangeScript = new ShaderColorChangeScript();
		shaderColorChangeScript.init(node);
		return shaderColorChangeScript;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x000065F4 File Offset: 0x000049F4
	private void init(XmlNode node)
	{
		this.time = XmlUtil.GetFloatFromNode(node, "time", 0f) / 1000f;
		this.endColor = XmlUtil.GetColorFromNode(node, "er", "eg", "eb", "ea");
		this.startColor = XmlUtil.GetColorFromNode(node, "sr", "sg", "sb", "sa");
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
		this.kind = ScriptKind.ShaderColor;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00006676 File Offset: 0x00004A76
	public override BaseAction CreateAction()
	{
		return ShaderColorChangeAction.Create(this);
	}

	// Token: 0x0400012A RID: 298
	public Color endColor;

	// Token: 0x0400012B RID: 299
	public Color startColor;

	// Token: 0x0400012C RID: 300
	public float time;
}
