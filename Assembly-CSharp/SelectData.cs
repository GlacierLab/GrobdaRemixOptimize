using System;
using System.Xml;

// Token: 0x02000057 RID: 87
public class SelectData
{
	// Token: 0x06000184 RID: 388 RVA: 0x0000621C File Offset: 0x0000461C
	public SelectData(XmlNode item)
	{
		this.IsAction = XmlUtil.GetBoolFromNode(item, "action", false);
		this.text = XmlUtil.GetStringFromNode(item, "text");
		this.loadPath = XmlUtil.GetStringFromNode(item, "load");
		this.NeedReset = XmlUtil.GetBoolFromNode(item, "reset", true);
	}

	// Token: 0x0400011A RID: 282
	public bool IsAction;

	// Token: 0x0400011B RID: 283
	public string text;

	// Token: 0x0400011C RID: 284
	public string loadPath;

	// Token: 0x0400011D RID: 285
	public bool NeedReset;
}
