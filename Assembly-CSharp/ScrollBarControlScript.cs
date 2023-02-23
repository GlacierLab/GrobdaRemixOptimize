using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B7 RID: 183
public class ScrollBarControlScript : MonoBehaviour
{
	// Token: 0x0600040C RID: 1036 RVA: 0x0000DE08 File Offset: 0x0000C208
	public void Up()
	{
		this.bar.value += 0.1f;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0000DE21 File Offset: 0x0000C221
	public void Down()
	{
		this.bar.value -= 0.1f;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0000DE3A File Offset: 0x0000C23A
	public void UpAll()
	{
		this.bar.value = 1f;
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0000DE4C File Offset: 0x0000C24C
	public void DownAll()
	{
		this.bar.value = 0f;
	}

	// Token: 0x04000272 RID: 626
	public Scrollbar bar;
}
