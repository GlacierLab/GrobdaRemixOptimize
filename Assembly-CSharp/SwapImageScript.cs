using System;
using System.Xml;

// Token: 0x02000041 RID: 65
public class SwapImageScript : BaseGroupScript
{
	// Token: 0x06000125 RID: 293 RVA: 0x00004D24 File Offset: 0x00003124
	public static SwapImageScript Create(XmlNode node)
	{
		SwapImageScript swapImageScript = new SwapImageScript();
		swapImageScript.init(node);
		return swapImageScript;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00004D40 File Offset: 0x00003140
	private void init(XmlNode node)
	{
		this.time = XmlUtil.GetIntFromNode(node, "time", 500);
		this.id = XmlUtil.GetStringFromNode(node, "id");
		this.copy = XmlUtil.GetBoolFromNode(node, "c", false);
		this.fadeout.init(this.id, this.time, 1f, 0f);
		this.fadein.init("test", this.time, 0f, 1f);
		this.setImage.init(node);
		this.setImage.layout_id = "test";
		this.delete.init(this.id);
		if (!this.copy && this.CheckHasId(this.id))
		{
			this.copy = true;
		}
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00004E18 File Offset: 0x00003218
	private bool CheckHasId(string id)
	{
		foreach (string text in SwapImageScript.keys)
		{
			if (id.ToLower().Contains(text))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00004E57 File Offset: 0x00003257
	public override BaseAction CreateAction()
	{
		return SwapImageAction.Create(this);
	}

	// Token: 0x0400008B RID: 139
	public int time;

	// Token: 0x0400008C RID: 140
	public string id;

	// Token: 0x0400008D RID: 141
	public FadeOutScript fadeout = new FadeOutScript();

	// Token: 0x0400008E RID: 142
	public FadeInScript fadein = new FadeInScript();

	// Token: 0x0400008F RID: 143
	public SetImageScript setImage = new SetImageScript();

	// Token: 0x04000090 RID: 144
	public DeleteLayoutScript delete = new DeleteLayoutScript();

	// Token: 0x04000091 RID: 145
	public bool copy;

	// Token: 0x04000092 RID: 146
	private static string[] keys = new string[] { "lihui", "sh", "ly", "sm", "ak", "yk", "la" };
}
