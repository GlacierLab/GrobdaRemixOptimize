using System;
using System.Xml;

// Token: 0x02000042 RID: 66
public class TextGroupScript : BaseGroupScript
{
	// Token: 0x0600012B RID: 299 RVA: 0x00004EB8 File Offset: 0x000032B8
	public override BaseAction CreateAction()
	{
		return TextGroupAction.Create(this);
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00004EC0 File Offset: 0x000032C0
	public void init(XmlNode node)
	{
		this.nameScript = new TextScript();
		this.nameScript.init(XmlUtil.GetStringFromNode(node, "name", string.Empty), "name", true);
		this.conTextScript = new TextScript();
		this.conTextScript.init(XmlUtil.GetStringFromNode(node, "text", string.Empty), "text", XmlUtil.GetBoolFromNode(node, "clear", true));
		this.voiceScript = VoiceScript.Create(node);
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00004F3C File Offset: 0x0000333C
	public static TextGroupScript Create(XmlNode node)
	{
		TextGroupScript textGroupScript = new TextGroupScript();
		textGroupScript.init(node);
		return textGroupScript;
	}

	// Token: 0x04000093 RID: 147
	public TextScript nameScript;

	// Token: 0x04000094 RID: 148
	public TextScript conTextScript;

	// Token: 0x04000095 RID: 149
	public VoiceScript voiceScript;
}
