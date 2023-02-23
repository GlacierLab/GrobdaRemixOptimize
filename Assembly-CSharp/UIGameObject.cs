using System;
using UnityEngine;

// Token: 0x020000D8 RID: 216
public class UIGameObject : MonoBehaviour
{
	// Token: 0x060004B8 RID: 1208 RVA: 0x0000BC9B File Offset: 0x0000A09B
	public virtual void Show()
	{
		base.gameObject.SetActive(true);
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x0000BCA9 File Offset: 0x0000A0A9
	public virtual void Hide()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0000BCB7 File Offset: 0x0000A0B7
	public virtual bool isActive()
	{
		return base.gameObject.activeInHierarchy;
	}
}
