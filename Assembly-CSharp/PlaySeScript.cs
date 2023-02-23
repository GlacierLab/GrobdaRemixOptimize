using System;
using System.Xml;

// Token: 0x0200004D RID: 77
public class PlaySeScript : ScriptStruct
{
	// Token: 0x06000157 RID: 343 RVA: 0x00005368 File Offset: 0x00003768
	public static PlaySeScript Create(XmlNode node)
	{
		PlaySeScript playSeScript = new PlaySeScript();
		playSeScript.init(node);
		return playSeScript;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00005383 File Offset: 0x00003783
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.PlaySE;
		this.isLoop = XmlUtil.GetBoolFromNode(node, "loop", false);
		this.name = XmlUtil.GetStringFromNode(node, "name");
		this.layout_id = null;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x000053B7 File Offset: 0x000037B7
	public override BaseAction CreateAction()
	{
		return PlaySeAction.Create(this);
	}

	// Token: 0x040000A6 RID: 166
	public string name;

	// Token: 0x040000A7 RID: 167
	public bool isLoop;
}
