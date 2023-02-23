using System;
using System.Xml;

// Token: 0x0200005C RID: 92
public class SetPostionScript : ScriptStruct
{
	// Token: 0x06000198 RID: 408 RVA: 0x0000655C File Offset: 0x0000495C
	public static SetPostionScript Create(XmlNode node)
	{
		SetPostionScript setPostionScript = new SetPostionScript();
		setPostionScript.init(XmlUtil.GetStringFromNode(node, "id"), XmlUtil.GetIntFromNode(node, "x", 100), XmlUtil.GetIntFromNode(node, "y", 100));
		return setPostionScript;
	}

	// Token: 0x06000199 RID: 409 RVA: 0x0000659B File Offset: 0x0000499B
	public void init(string id, int _x, int _y)
	{
		this.kind = ScriptKind.FadeIn;
		this.layout_id = id;
		this.x = (float)_x / 100f;
		this.y = (float)_y / 100f;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x000065C7 File Offset: 0x000049C7
	public override BaseAction CreateAction()
	{
		return SetPositionAction.Create(this);
	}

	// Token: 0x04000128 RID: 296
	public float x;

	// Token: 0x04000129 RID: 297
	public float y;
}
