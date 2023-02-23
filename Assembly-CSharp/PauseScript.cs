using System;
using System.Xml;

// Token: 0x0200004B RID: 75
public class PauseScript : ScriptStruct
{
	// Token: 0x0600014F RID: 335 RVA: 0x000052B4 File Offset: 0x000036B4
	public static PauseScript Create(XmlNode node)
	{
		PauseScript pauseScript = new PauseScript();
		pauseScript.init();
		return pauseScript;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x000052CE File Offset: 0x000036CE
	public void init()
	{
		this.kind = ScriptKind.Pause;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x000052D7 File Offset: 0x000036D7
	public override BaseAction CreateAction()
	{
		throw new NotImplementedException();
	}
}
