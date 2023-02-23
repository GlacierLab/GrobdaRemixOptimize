using System;
using System.Xml;

// Token: 0x02000045 RID: 69
public class LightPowerScript : ScriptStruct
{
	// Token: 0x06000137 RID: 311 RVA: 0x00005010 File Offset: 0x00003410
	public static LightPowerScript Create(XmlNode node)
	{
		LightPowerScript lightPowerScript = new LightPowerScript();
		lightPowerScript.init(node);
		return lightPowerScript;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x0000502C File Offset: 0x0000342C
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.LightPower;
		this.power = XmlUtil.GetFloatFromNode(node, "power", 0f);
		this.time = XmlUtil.GetFloatFromNode(node, "time", 0f) / 1000f;
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00005084 File Offset: 0x00003484
	public override BaseAction CreateAction()
	{
		return LightPowerAction.Create(this);
	}

	// Token: 0x04000098 RID: 152
	public float power;

	// Token: 0x04000099 RID: 153
	public float time;
}
