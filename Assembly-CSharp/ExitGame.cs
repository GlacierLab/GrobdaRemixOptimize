using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class ExitGame : MonoBehaviour
{
	// Token: 0x0600037B RID: 891 RVA: 0x0000C40F File Offset: 0x0000A80F
	private void Start()
	{
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0000C411 File Offset: 0x0000A811
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			this.Cancel();
		}
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0000C424 File Offset: 0x0000A824
	public void Exit()
	{
		Singleton<UIManager>.Instance.SetFlag(true);
		Application.Quit();
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0000C436 File Offset: 0x0000A836
	public void Cancel()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
