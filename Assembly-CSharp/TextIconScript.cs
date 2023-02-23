using System;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class TextIconScript : MonoBehaviour
{
	// Token: 0x0600043E RID: 1086 RVA: 0x0000E549 File Offset: 0x0000C949
	private void OnEnable()
	{
		base.transform.eulerAngles = new Vector3(0f, 0f, -90f);
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0000E56A File Offset: 0x0000C96A
	private void Update()
	{
		base.transform.Rotate(1f, 0f, 0f);
	}
}
