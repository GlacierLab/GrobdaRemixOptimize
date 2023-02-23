using System;
using System.Xml;

// Token: 0x02000068 RID: 104
public class VolumeScript : ScriptStruct
{
	// Token: 0x060001C8 RID: 456 RVA: 0x000069F4 File Offset: 0x00004DF4
	public static ScriptStruct Create(XmlNode node)
	{
		VolumeScript volumeScript = new VolumeScript();
		volumeScript.init(node);
		return volumeScript;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00006A0F File Offset: 0x00004E0F
	private void init(XmlNode node)
	{
		this.kind = ScriptKind.Volume;
		this.v = XmlUtil.GetIntFromNode(node, "v", 100);
		this.k = XmlUtil.GetStringFromNode(node, "kind");
		this.layout_id = null;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00006A44 File Offset: 0x00004E44
	public override BaseAction CreateAction()
	{
		return VolumeAction.Create(this);
	}

	// Token: 0x0400013D RID: 317
	public int v;

	// Token: 0x0400013E RID: 318
	public string k;
}
