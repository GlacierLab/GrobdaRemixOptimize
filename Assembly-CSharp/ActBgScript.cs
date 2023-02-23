using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000034 RID: 52
public class ActBgScript : ScriptStruct
{
	// Token: 0x060000F3 RID: 243 RVA: 0x00004620 File Offset: 0x00002A20
	public static ActBgScript Create(XmlNode node)
	{
		ActBgScript actBgScript = new ActBgScript();
		actBgScript.init(node);
		return actBgScript;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000463C File Offset: 0x00002A3C
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.BgAct;
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
		this.path = XmlUtil.GetStringFromNode(node, "path");
		this.shader = XmlUtil.GetStringFromNode(node, "shader");
		this.p = XmlUtil.GetVectorFromNode(node, "x", "y", "z");
		this.s = XmlUtil.GetScaleFromNode(node, "sx", "sy", "sz");
		this.r = XmlUtil.GetRotatoFromNode(node, "rx", "ry", "rz");
		this.vp = XmlUtil.GetVectorFromNode(node, "vx", "vy", "vz");
		this.vs = XmlUtil.GetVectorFromNode(node, "vsx", "vsy", "vsz");
		this.vr = XmlUtil.GetRotatoFromNode(node, "vrx", "vry", "vrz");
		this.loop = XmlUtil.GetBoolFromNode(node, "loop", false);
		this.time = XmlUtil.GetFloatFromNode(node, "time", 1f);
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000474E File Offset: 0x00002B4E
	public override BaseAction CreateAction()
	{
		return ActBgAction.Create(this);
	}

	// Token: 0x04000069 RID: 105
	public string path;

	// Token: 0x0400006A RID: 106
	public Vector3 p;

	// Token: 0x0400006B RID: 107
	public Vector3 vp;

	// Token: 0x0400006C RID: 108
	public Vector3 s = Vector3.one;

	// Token: 0x0400006D RID: 109
	public Vector3 vs;

	// Token: 0x0400006E RID: 110
	public Vector3 r;

	// Token: 0x0400006F RID: 111
	public Vector3 vr;

	// Token: 0x04000070 RID: 112
	public bool loop;

	// Token: 0x04000071 RID: 113
	public string shader;

	// Token: 0x04000072 RID: 114
	public float time;

	// Token: 0x04000073 RID: 115
	public bool clear;
}
