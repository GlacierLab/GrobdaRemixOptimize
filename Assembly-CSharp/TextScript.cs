using System;
using System.Xml;

// Token: 0x02000065 RID: 101
public class TextScript : ScriptStruct
{
	// Token: 0x060001BC RID: 444 RVA: 0x000068D8 File Offset: 0x00004CD8
	public static TextScript Create(XmlNode node)
	{
		TextScript textScript = new TextScript();
		textScript.init(node.Attributes["text"].Value, node.Attributes["id"].Value, true);
		return textScript;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0000691D File Offset: 0x00004D1D
	public void init(string t, string id, bool c = true)
	{
		this.layout_id = id;
		this.text = t;
		this.IsNeedClear = c;
		this.kind = ScriptKind.Text;
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000693B File Offset: 0x00004D3B
	public override BaseAction CreateAction()
	{
		return TextAction.Create(this);
	}

	// Token: 0x04000138 RID: 312
	public string text;

	// Token: 0x04000139 RID: 313
	public bool IsNeedClear;
}
