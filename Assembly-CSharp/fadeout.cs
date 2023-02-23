using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class fadeout : MonoBehaviour
{
	// Token: 0x06000487 RID: 1159 RVA: 0x0000F469 File Offset: 0x0000D869
	private void Awake()
	{
		this.rtf = base.GetComponent<RectTransform>();
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0000F478 File Offset: 0x0000D878
	private void OnEnable()
	{
		this.rtf.position = new Vector3(0f, 0f, this.rtf.position.z);
		Tweener tweener = this.rtf.DOMoveX((float)Screen.width, 2f, false);
		tweener.SetEase(Ease.Linear);
	}

	// Token: 0x040002B4 RID: 692
	private RectTransform rtf;
}
