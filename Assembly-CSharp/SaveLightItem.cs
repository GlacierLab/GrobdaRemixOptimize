using System;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x0200009A RID: 154
public class SaveLightItem
{
	// Token: 0x040001FE RID: 510
	[XmlAttribute]
	public string kind;

	// Token: 0x040001FF RID: 511
	[XmlAttribute]
	public string id;

	// Token: 0x04000200 RID: 512
	public Vector3 p;

	// Token: 0x04000201 RID: 513
	public Color c;

	// Token: 0x04000202 RID: 514
	public Vector3 angle;

	// Token: 0x04000203 RID: 515
	[XmlAttribute]
	public float pow;

	// Token: 0x04000204 RID: 516
	[XmlAttribute]
	public float range;
}
