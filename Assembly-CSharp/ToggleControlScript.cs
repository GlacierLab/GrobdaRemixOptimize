using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C3 RID: 195
public class ToggleControlScript : MonoBehaviour
{
	// Token: 0x0600044C RID: 1100 RVA: 0x0000E876 File Offset: 0x0000CC76
	private void Awake()
	{
		this.yes = base.gameObject.GetComponentsInChildren<Toggle>()[0];
		this.no = base.gameObject.GetComponentsInChildren<Toggle>()[1];
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0000E89E File Offset: 0x0000CC9E
	public void SetStatus(bool flag)
	{
		if (flag)
		{
			this.yes.isOn = true;
		}
		else
		{
			this.no.isOn = true;
		}
	}

	// Token: 0x04000291 RID: 657
	[SerializeField]
	private Toggle yes;

	// Token: 0x04000292 RID: 658
	[SerializeField]
	private Toggle no;
}
