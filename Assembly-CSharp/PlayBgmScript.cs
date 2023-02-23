using System;
using System.Xml;

// Token: 0x0200004C RID: 76
public class PlayBgmScript : ScriptStruct
{
	// Token: 0x06000153 RID: 339 RVA: 0x000052E8 File Offset: 0x000036E8
	public static PlayBgmScript Create(XmlNode node)
	{
		PlayBgmScript playBgmScript = new PlayBgmScript();
		playBgmScript.init(node);
		return playBgmScript;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00005304 File Offset: 0x00003704
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.PlayBGM;
		this.name = XmlUtil.GetStringFromNode(node, "name");
		this.time = XmlUtil.GetIntFromNode(node, "time", 100);
		this.con = XmlUtil.GetBoolFromNode(node, "c", false);
		this.layout_id = null;
	}

	// Token: 0x06000155 RID: 341 RVA: 0x00005355 File Offset: 0x00003755
	public override BaseAction CreateAction()
	{
		return PlayBgmAction.Create(this);
	}

	// Token: 0x040000A3 RID: 163
	public string name;

	// Token: 0x040000A4 RID: 164
	public int time;

	// Token: 0x040000A5 RID: 165
	public bool con;
}
