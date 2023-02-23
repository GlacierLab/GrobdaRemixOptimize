using System;
using System.Xml;

// Token: 0x0200004F RID: 79
public class ReturnToUIScript : ScriptStruct
{
	// Token: 0x0600015F RID: 351 RVA: 0x00005470 File Offset: 0x00003870
	public static ReturnToUIScript Create(XmlNode node)
	{
		ReturnToUIScript returnToUIScript = new ReturnToUIScript();
		returnToUIScript.init(XmlUtil.GetStringFromNode(node, "value"));
		return returnToUIScript;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00005495 File Offset: 0x00003895
	public void init(string vValue)
	{
		this.UIName = vValue;
		this.kind = ScriptKind.System;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x000054A6 File Offset: 0x000038A6
	public override BaseAction CreateAction()
	{
		return ReturnToUIAction.Create(this);
	}

	// Token: 0x040000AC RID: 172
	public string UIName;
}
