using System;
using System.Xml;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class SetImageScript : ScriptStruct
{
	// Token: 0x06000193 RID: 403 RVA: 0x00006400 File Offset: 0x00004800
	public static SetImageScript Create(XmlNode node)
	{
		SetImageScript setImageScript = new SetImageScript();
		setImageScript.init(node);
		return setImageScript;
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0000641C File Offset: 0x0000481C
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.SetImage;
		this.layout_id = node.Attributes["id"].Value;
		this.path = node.Attributes["path"].Value;
		this.shader = XmlUtil.GetStringFromNode(node, "shader");
		this.p = XmlUtil.GetVectorFromNode(node, "x", "y", "z");
		this.s = XmlUtil.GetScaleFromNode(node, "sx", "sy", "sz");
		this.c = XmlUtil.GetColorFromNode(node, "r", "g", "b", "a");
		this.shader_color = XmlUtil.GetShaderColorFromNode(node, "sr", "sg", "sb", "sa");
	}

	// Token: 0x06000195 RID: 405 RVA: 0x000064F0 File Offset: 0x000048F0
	public void init(string id, string _path, Color _c, Vector3 _p, string _shader = "default")
	{
		this.kind = ScriptKind.SetImage;
		this.layout_id = id;
		this.path = _path;
		this.shader = _shader;
		this.p = _p;
		this.c = _c;
		this.shader_color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00006549 File Offset: 0x00004949
	public override BaseAction CreateAction()
	{
		return SetImageAction.Create(this);
	}

	// Token: 0x04000122 RID: 290
	public string path;

	// Token: 0x04000123 RID: 291
	public string shader;

	// Token: 0x04000124 RID: 292
	public Color c;

	// Token: 0x04000125 RID: 293
	public Vector3 p;

	// Token: 0x04000126 RID: 294
	public Vector3 s;

	// Token: 0x04000127 RID: 295
	public Color shader_color;
}
