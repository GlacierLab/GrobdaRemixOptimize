using System;
using System.Xml;

// Token: 0x0200005A RID: 90
public class SetGroupFlagScript : ScriptStruct
{
	// Token: 0x0600018F RID: 399 RVA: 0x0000639C File Offset: 0x0000479C
	public static SetGroupFlagScript Create(XmlNode node)
	{
		SetGroupFlagScript setGroupFlagScript = new SetGroupFlagScript();
		setGroupFlagScript.init(node.Attributes["name"].Value, XmlUtil.GetBoolFromNode(node, "value", false));
		return setGroupFlagScript;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000063D7 File Offset: 0x000047D7
	public void init(string fName, bool fValue)
	{
		this.flagName = fName;
		this.flagValue = fValue;
		this.kind = ScriptKind.System;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x000063EF File Offset: 0x000047EF
	public override BaseAction CreateAction()
	{
		return SetGroupFlagAction.Create(this);
	}

	// Token: 0x04000120 RID: 288
	public string flagName;

	// Token: 0x04000121 RID: 289
	public bool flagValue;
}
