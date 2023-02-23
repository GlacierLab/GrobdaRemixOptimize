using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000050 RID: 80
public class ScaleScript : ScriptStruct
{
	// Token: 0x06000163 RID: 355 RVA: 0x000054B8 File Offset: 0x000038B8
	public static ScriptStruct Create(XmlNode node)
	{
		ScaleScript scaleScript = new ScaleScript();
		scaleScript.init(node);
		return scaleScript;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x000054D4 File Offset: 0x000038D4
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.Scale;
		this.s = XmlUtil.GetScaleFromNode(node, "sx", "sy", "sz");
		this.time = XmlUtil.GetIntFromNode(node, "time", 100);
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00005528 File Offset: 0x00003928
	public override BaseAction CreateAction()
	{
		return ScaleAction.Create(this);
	}

	// Token: 0x040000AD RID: 173
	public Vector3 s;

	// Token: 0x040000AE RID: 174
	public int time;
}
