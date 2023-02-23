using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AA RID: 170
public class HistoryControlScript : MonoBehaviour
{
	// Token: 0x060003AB RID: 939 RVA: 0x0000CA78 File Offset: 0x0000AE78
	public void AddItem(TextGroupScript item)
	{
		NewHistoryItemScript newHistoryItemScript = UnityEngine.Object.Instantiate<NewHistoryItemScript>(Resources.Load<NewHistoryItemScript>("prefab/newHistoryItem"));
		newHistoryItemScript.transform.SetParent(this.content.transform, false);
		this.list.Add(newHistoryItemScript);
		newHistoryItemScript.Init(item);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x0000CAC0 File Offset: 0x0000AEC0
	public void InitAllItem()
	{
		this.DestroyAllItem();
		List<TextGroupScript> history = ScriptExecute.GetInstance().GetHistory();
		foreach (TextGroupScript textGroupScript in history)
		{
			this.AddItem(textGroupScript);
		}
		this.bar.value = 0.0001f;
		this.bar.value = 0f;
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0000CB48 File Offset: 0x0000AF48
	private void DestroyAllItem()
	{
		IEnumerator enumerator = this.list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				NewHistoryItemScript newHistoryItemScript = (NewHistoryItemScript)obj;
				UnityEngine.Object.Destroy(newHistoryItemScript.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		this.list.Clear();
	}

	// Token: 0x04000244 RID: 580
	public GameObject content;

	// Token: 0x04000245 RID: 581
	private ArrayList list = new ArrayList();

	// Token: 0x04000246 RID: 582
	public Scrollbar bar;
}
