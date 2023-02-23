using System;
using System.Xml;

// Token: 0x02000067 RID: 103
public class VoiceScript : ScriptStruct
{
	// Token: 0x060001C4 RID: 452 RVA: 0x00006994 File Offset: 0x00004D94
	public static VoiceScript Create(XmlNode node)
	{
		VoiceScript voiceScript = new VoiceScript();
		voiceScript.init(node);
		return voiceScript;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x000069AF File Offset: 0x00004DAF
	public void init(XmlNode node)
	{
		this.layout_id = null;
		this.voice = XmlUtil.GetStringFromNode(node, "voice");
		this.vkind = XmlUtil.GetIntFromNode(node, "vkind", 100);
		this.kind = ScriptKind.Voice;
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x000069E4 File Offset: 0x00004DE4
	public override BaseAction CreateAction()
	{
		return VoiceAction.Create(this);
	}

	// Token: 0x0400013B RID: 315
	public int vkind;

	// Token: 0x0400013C RID: 316
	public string voice;
}
