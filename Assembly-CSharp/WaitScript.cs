using System;
using System.Xml;

// Token: 0x02000069 RID: 105
public class WaitScript : ScriptStruct
{
	// Token: 0x060001CC RID: 460 RVA: 0x00006A54 File Offset: 0x00004E54
	public static WaitScript Create(XmlNode node)
	{
		WaitScript waitScript = new WaitScript();
		waitScript.init((float)XmlUtil.GetIntFromNode(node, "time", 100));
		return waitScript;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00006A7C File Offset: 0x00004E7C
	public void init(float t)
	{
		this.time = t / 1000f;
		this.kind = ScriptKind.Wait;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00006A93 File Offset: 0x00004E93
	public override BaseAction CreateAction()
	{
		return WaitAction.Create(this);
	}

	// Token: 0x0400013F RID: 319
	public float time;
}
