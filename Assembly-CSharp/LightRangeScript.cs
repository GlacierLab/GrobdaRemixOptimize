using System;
using System.Xml;

// Token: 0x02000046 RID: 70
public class LightRangeScript : ScriptStruct
{
	// Token: 0x0600013B RID: 315 RVA: 0x00005094 File Offset: 0x00003494
	public static LightRangeScript Create(XmlNode node)
	{
		LightRangeScript lightRangeScript = new LightRangeScript();
		lightRangeScript.init(node);
		return lightRangeScript;
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000050B0 File Offset: 0x000034B0
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.LightRange;
		this.range = XmlUtil.GetFloatFromNode(node, "range", 0f);
		this.time = XmlUtil.GetFloatFromNode(node, "time", 0f) / 1000f;
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00005108 File Offset: 0x00003508
	public override BaseAction CreateAction()
	{
		return LightRangeAction.Create(this);
	}

	// Token: 0x0400009A RID: 154
	public float range;

	// Token: 0x0400009B RID: 155
	public float time;
}
