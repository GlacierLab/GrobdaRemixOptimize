using System;
using System.Xml;

// Token: 0x02000060 RID: 96
public class StopBgmScript : ScriptStruct
{
	// Token: 0x060001A8 RID: 424 RVA: 0x00006738 File Offset: 0x00004B38
	public static StopBgmScript Create(XmlNode node)
	{
		StopBgmScript stopBgmScript = new StopBgmScript();
		stopBgmScript.init(node);
		return stopBgmScript;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00006753 File Offset: 0x00004B53
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.StopBGM;
		this.time = XmlUtil.GetIntFromNode(node, "time", 100);
		this.layout_id = null;
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00006776 File Offset: 0x00004B76
	public override BaseAction CreateAction()
	{
		return StopBgmAction.Create(this);
	}

	// Token: 0x0400012F RID: 303
	public int time;
}
