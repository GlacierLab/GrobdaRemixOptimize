using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class CreateLightScript : ScriptStruct
{
	// Token: 0x06000103 RID: 259 RVA: 0x000048A8 File Offset: 0x00002CA8
	public static CreateLightScript Create(XmlNode node)
	{
		CreateLightScript createLightScript = new CreateLightScript();
		createLightScript.init(node);
		return createLightScript;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x000048C4 File Offset: 0x00002CC4
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.CreateLight;
		this.id = XmlUtil.GetStringFromNode(node, "id");
		this.light_kind = XmlUtil.GetStringFromNode(node, "kind", "point");
		this.p = XmlUtil.GetVectorFromNode(node, "x", "y", "z") / 100f;
		this.c = XmlUtil.GetColorFromNode(node, "r", "g", "b", "a");
		this.angle = XmlUtil.GetVectorFromNode(node, "ax", "ay", "az");
		this.pow = XmlUtil.GetFloatFromNode(node, "pow", 1f);
		this.range = XmlUtil.GetFloatFromNode(node, "range", 1000f) / 100f;
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00004992 File Offset: 0x00002D92
	public override BaseAction CreateAction()
	{
		return CreateLightAction.Create(this);
	}

	// Token: 0x04000079 RID: 121
	public string light_kind;

	// Token: 0x0400007A RID: 122
	public string id;

	// Token: 0x0400007B RID: 123
	public Vector3 p;

	// Token: 0x0400007C RID: 124
	public Vector3 angle;

	// Token: 0x0400007D RID: 125
	public Color c;

	// Token: 0x0400007E RID: 126
	public float pow;

	// Token: 0x0400007F RID: 127
	public float range;
}
