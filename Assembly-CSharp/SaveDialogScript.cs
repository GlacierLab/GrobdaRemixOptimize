using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000B4 RID: 180
public class SaveDialogScript : MonoBehaviour
{
	// Token: 0x060003F6 RID: 1014 RVA: 0x0000D761 File Offset: 0x0000BB61
	public void Init(SaveItemGroup g)
	{
		base.gameObject.SetActive(true);
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 0.5f);
		this.saveItemGroup = g;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0000D79C File Offset: 0x0000BB9C
	public void Save()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		int num = this.saveItemGroup.num;
		this.saveItemGroup.saveData = SaveDataManager.GetInstance().SaveDataToDisk(num, false);
		this.saveItemGroup.SetSaveData(this.saveItemGroup.saveData, num);
		SaveDataManager.GetInstance().CopySaveData(num, 0);
		this.saveItemGroup.SetSaveData(this.saveItemGroup.saveData, 0);
		base.gameObject.SetActive(false);
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0000D81D File Offset: 0x0000BC1D
	public void Load()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		LoadScriptConfig.SetSaveData(this.saveItemGroup.saveData);
		SceneManager.LoadScene("logo");
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0000D843 File Offset: 0x0000BC43
	public void Cancel()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000266 RID: 614
	public CanvasGroup canvasGroup;

	// Token: 0x04000267 RID: 615
	public SaveItemGroup saveItemGroup;
}
