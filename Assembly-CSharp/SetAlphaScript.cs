using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000059 RID: 89
public class SetAlphaScript : ScriptStruct
{
	// Token: 0x0600018B RID: 395 RVA: 0x00006334 File Offset: 0x00004734
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.SetAlpha;
		this.layout_id = XmlUtil.GetStringFromNode(node, "id");
		this.c = XmlUtil.GetColorFromNode(node, "r", "g", "b", "a");
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00006370 File Offset: 0x00004770
	public static SetAlphaScript Create(XmlNode node)
	{
		SetAlphaScript setAlphaScript = new SetAlphaScript();
		setAlphaScript.init(node);
		return setAlphaScript;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0000638B File Offset: 0x0000478B
	public override BaseAction CreateAction()
	{
		return SetAlphaAction.Create(this);
	}

	// Token: 0x0400011F RID: 287
	public Color c;
}
