using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200007D RID: 125
public class AddinManager : Singleton<AddinManager>
{
	// Token: 0x06000264 RID: 612 RVA: 0x000088BC File Offset: 0x00006CBC
	public void HideAllAddin()
	{
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.addins)
		{
			UnityEngine.Object.DestroyImmediate(keyValuePair.Value);
		}
		this.addins.Clear();
	}

	// Token: 0x06000265 RID: 613 RVA: 0x00008928 File Offset: 0x00006D28
	public void ShowAddIn(string name)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("prefab/" + name));
		gameObject.transform.SetParent(base.gameObject.transform, false);
		gameObject.name = name;
		this.addins.Add(name, gameObject);
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00008976 File Offset: 0x00006D76
	public void HideAddIn(string name)
	{
		UnityEngine.Object.Destroy(this.addins[name]);
		this.addins.Remove(name);
	}

	// Token: 0x06000267 RID: 615 RVA: 0x00008998 File Offset: 0x00006D98
	public void ConfigSaveData(SaveData data)
	{
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.addins)
		{
			data.Addin.Add(keyValuePair.Key);
		}
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00008A00 File Offset: 0x00006E00
	public void LoadSaveData(SaveData data)
	{
		foreach (string text in data.Addin)
		{
			this.ShowAddIn(text);
		}
	}

	// Token: 0x040001A8 RID: 424
	private Dictionary<string, GameObject> addins = new Dictionary<string, GameObject>();
}
