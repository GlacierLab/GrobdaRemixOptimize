using System;
using System.Xml;

// Token: 0x02000066 RID: 102
public class TextVisibleScript : ScriptStruct
{
	// Token: 0x060001C0 RID: 448 RVA: 0x0000694C File Offset: 0x00004D4C
	public static TextVisibleScript Create(XmlNode node)
	{
		TextVisibleScript textVisibleScript = new TextVisibleScript();
		textVisibleScript.init(XmlUtil.GetBoolFromNode(node, "value", false));
		return textVisibleScript;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00006972 File Offset: 0x00004D72
	public void init(bool vValue)
	{
		this.visibleValue = vValue;
		this.kind = ScriptKind.System;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00006983 File Offset: 0x00004D83
	public override BaseAction CreateAction()
	{
		return TextVisibleAction.Create(this);
	}

	// Token: 0x0400013A RID: 314
	public bool visibleValue;
}
