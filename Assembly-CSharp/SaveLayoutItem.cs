using System;
using System.Xml.Serialization;

// Token: 0x0200009B RID: 155
public class SaveLayoutItem
{
	// Token: 0x04000205 RID: 517
	[XmlAttribute]
	public string id;

	// Token: 0x04000206 RID: 518
	[XmlAttribute]
	public string source;

	// Token: 0x04000207 RID: 519
	[XmlAttribute]
	public float x;

	// Token: 0x04000208 RID: 520
	[XmlAttribute]
	public float y;

	// Token: 0x04000209 RID: 521
	[XmlAttribute]
	public float z;

	// Token: 0x0400020A RID: 522
	[XmlAttribute]
	public float sx;

	// Token: 0x0400020B RID: 523
	[XmlAttribute]
	public float sy;

	// Token: 0x0400020C RID: 524
	[XmlAttribute]
	public bool isActive;

	// Token: 0x0400020D RID: 525
	[XmlAttribute]
	public string shader;

	// Token: 0x0400020E RID: 526
	[XmlAttribute]
	public float aplha;

	// Token: 0x0400020F RID: 527
	[XmlAttribute]
	public float angle;
}
