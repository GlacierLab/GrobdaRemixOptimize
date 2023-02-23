using System;
using System.Xml;

// Token: 0x02000049 RID: 73
public class MoveScript : ScriptStruct
{
	// Token: 0x06000147 RID: 327 RVA: 0x000051B8 File Offset: 0x000035B8
	public static ScriptStruct Create(XmlNode node)
	{
		MoveScript moveScript = new MoveScript();
		moveScript.init(node);
		return moveScript;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000051D4 File Offset: 0x000035D4
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.Move;
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
		this.x = (float)XmlUtil.GetIntFromNode(node, "x", 100) / 100f;
		this.y = (float)XmlUtil.GetIntFromNode(node, "y", 100) / 100f;
		this.time = XmlUtil.GetIntFromNode(node, "time", 100);
		this.forward = XmlUtil.GetBoolFromNode(node, "f", true);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00005253 File Offset: 0x00003653
	public override BaseAction CreateAction()
	{
		return MoveAction.Create(this);
	}

	// Token: 0x0400009E RID: 158
	public float x;

	// Token: 0x0400009F RID: 159
	public float y;

	// Token: 0x040000A0 RID: 160
	public int time;

	// Token: 0x040000A1 RID: 161
	public bool forward;
}
