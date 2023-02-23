using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class RotateScript : ScriptStruct
{
	// Token: 0x06000167 RID: 359 RVA: 0x00005538 File Offset: 0x00003938
	public static ScriptStruct Create(XmlNode node)
	{
		RotateScript rotateScript = new RotateScript();
		rotateScript.init(node);
		return rotateScript;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00005554 File Offset: 0x00003954
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.Rotate;
		this.angle = XmlUtil.GetVectorFromNode(node, "x", "y", "z");
		this.time = XmlUtil.GetIntFromNode(node, "time", 100);
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
	}

	// Token: 0x06000169 RID: 361 RVA: 0x000055A8 File Offset: 0x000039A8
	public override BaseAction CreateAction()
	{
		return RotateAction.Create(this);
	}

	// Token: 0x040000AF RID: 175
	public Vector3 angle;

	// Token: 0x040000B0 RID: 176
	public int time;
}
