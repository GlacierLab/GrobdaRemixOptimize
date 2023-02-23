using System;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class TestObj : MonoBehaviour
{
	// Token: 0x0600033E RID: 830 RVA: 0x0000BA30 File Offset: 0x00009E30
	private void Start()
	{
		GameObject gameObject = new GameObject("test_mask");
		gameObject.AddComponent<SpriteRenderer>();
	}
}
