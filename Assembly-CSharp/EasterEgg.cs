using System;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class EasterEgg : MonoBehaviour
{
	// Token: 0x060002FB RID: 763 RVA: 0x0000AC50 File Offset: 0x00009050
	private void Update()
	{
		if (this.index < this.list.Length)
		{
			if (Input.anyKeyDown)
			{
				if (this.CheckKeyDown(this.list[this.index]))
				{
					this.index++;
				}
				else
				{
					this.index = 0;
				}
			}
		}
		else
		{
			Debug.Log("哲学");
			this.index = 0;
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0000ACC2 File Offset: 0x000090C2
	private bool CheckKeyDown(KeyCode k)
	{
		return Input.GetKeyDown(k);
	}

	// Token: 0x040001E8 RID: 488
	[SerializeField]
	private KeyCode[] list = new KeyCode[]
	{
		KeyCode.Z,
		KeyCode.H,
		KeyCode.E,
		KeyCode.X,
		KeyCode.U,
		KeyCode.E
	};

	// Token: 0x040001E9 RID: 489
	[SerializeField]
	private int index;
}
