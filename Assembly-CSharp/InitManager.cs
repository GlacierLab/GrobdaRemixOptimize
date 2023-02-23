using System;
using UnityEngine;

// Token: 0x02000070 RID: 112
public class InitManager : MonoBehaviour
{
	// Token: 0x060001F2 RID: 498 RVA: 0x000072E4 File Offset: 0x000056E4
	private void Start()
	{
		if (this.IsDebug)
		{
			this.DebugLoad();
		}
		Singleton<AVGManager>.Instance.ResetAllLayout();
		Singleton<AVGManager>.Instance.SetStartStatus();
		Singleton<AVGManager>.Instance.LoadScript();
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00007318 File Offset: 0x00005718
	private void DebugLoad()
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
		LoadScriptConfig.SetConfig("xml/testXml", 0);
	}

	// Token: 0x0400016F RID: 367
	public bool IsDebug;
}
