using System;
using UnityEngine;

// Token: 0x02000071 RID: 113
public class InitResource : MonoBehaviour
{
	// Token: 0x060001F5 RID: 501 RVA: 0x000073A8 File Offset: 0x000057A8
	private void Awake()
	{
		AesUtil.Init();
		SaveDataManager.GetInstance().LoadAllSaveData();
		if (GameConfigManager.IsFirstLoad)
		{
			MaterialManager.GetInstance().InitResource();
			Singleton<CGManager>.Instance.InitResource();
			Singleton<BGMManager>.Instance.InitResource();
			Singleton<UIManager>.Instance.InitResource();
			Singleton<SEManager>.Instance.InitResource();
			Singleton<PointManager>.Instance.InitResource();
			Singleton<SystemSoundManager>.Instance.InitResource();
			Singleton<VoiceManager>.Instance.InitResource();
			Singleton<MovieManager>.Instance.InitResource();
			Singleton<AddinManager>.Instance.InitResource();
			Singleton<AVGManager>.Instance.LoadLogoScript();
			GameConfigManager.IsFirstLoad = false;
		}
		else
		{
			Singleton<UIManager>.Instance.ShowUi("new_main");
		}
		Singleton<AVGManager>.Instance.SetStartStatus();
		CGSaveDataManager.GetInstance();
		BgmSaveDataManager.GetInstance();
		DataSaveManager.GetInstance();
		MovieSaveDataManager.GetInstance();
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00007478 File Offset: 0x00005878
	private void Start()
	{
		Singleton<GameConfigManager>.Instance.Init();
	}
}
