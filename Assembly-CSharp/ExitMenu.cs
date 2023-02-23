using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class ExitMenu : MonoBehaviour
{
	// Token: 0x06000380 RID: 896 RVA: 0x0000C44B File Offset: 0x0000A84B
	private void Start()
	{
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0000C44D File Offset: 0x0000A84D
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			this.Cancel();
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0000C460 File Offset: 0x0000A860
	public void Exit()
	{
		Singleton<AVGManager>.Instance.ExitToMenu();
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0000C46C File Offset: 0x0000A86C
	public void Cancel()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
