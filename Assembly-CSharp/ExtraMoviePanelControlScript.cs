using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
public class ExtraMoviePanelControlScript : MonoBehaviour
{
	// Token: 0x0600045C RID: 1116 RVA: 0x0000EA81 File Offset: 0x0000CE81
	private void Start()
	{
		this.InitAllItemGroup();
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0000EA89 File Offset: 0x0000CE89
	public void InitAllItemGroup()
	{
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x0000EA91 File Offset: 0x0000CE91
	public void DeleteUnUseful()
	{
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0000EA99 File Offset: 0x0000CE99
	public void playMovie(string arg)
	{
		Singleton<MovieManager>.Instance.PlayMovie(arg, true);
	}

	// Token: 0x04000298 RID: 664
	[SerializeField]
	private int nowSelect;
}
