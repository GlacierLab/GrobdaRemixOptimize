using System;
using System.Xml;

// Token: 0x02000063 RID: 99
public class StopBeScript : ScriptStruct
{
	// Token: 0x060001B4 RID: 436 RVA: 0x00006828 File Offset: 0x00004C28
	public static StopBeScript Create(XmlNode node)
	{
		StopBeScript stopBeScript = new StopBeScript();
		stopBeScript.init();
		return stopBeScript;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00006842 File Offset: 0x00004C42
	public void init()
	{
		this.kind = ScriptKind.StopSE;
		this.layout_id = null;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00006853 File Offset: 0x00004C53
	public override BaseAction CreateAction()
	{
		return StopSeAction.Create(this);
	}
}
