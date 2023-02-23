using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000079 RID: 121
public class SelectLayout : BaseLayout
{
	// Token: 0x06000234 RID: 564 RVA: 0x00007C3F File Offset: 0x0000603F
	public void SetAction(SelectAction action)
	{
		if (action != null)
		{
			this.items = action.GetSelectScript().GetItems();
			this.parent.SetActive(true);
			this.ConfigButtons();
		}
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00007C6A File Offset: 0x0000606A
	private void ConfigButtons()
	{
		this.ConfigButton(this.item1, this.items[0]);
		this.ConfigButton(this.item2, this.items[1]);
	}

	// Token: 0x06000236 RID: 566 RVA: 0x00007C9C File Offset: 0x0000609C
	private void ConfigButton(Button button, SelectData data)
	{
		button.GetComponentsInChildren<Text>()[0].text = data.text;
		button.interactable = data.IsAction;
		button.onClick.AddListener(delegate
		{
			this.OnClick(button);
		});
	}

	// Token: 0x06000237 RID: 567 RVA: 0x00007D02 File Offset: 0x00006102
	private void Awake()
	{
		this.item1.name = "0";
		this.item2.name = "1";
		this.init();
	}

	// Token: 0x06000238 RID: 568 RVA: 0x00007D2A File Offset: 0x0000612A
	public void init()
	{
	}

	// Token: 0x06000239 RID: 569 RVA: 0x00007D2C File Offset: 0x0000612C
	private void OnClick(Button o)
	{
		int num = Convert.ToInt32(o.name);
		SelectData selectData = this.items[num];
		this.parent.SetActive(false);
		Singleton<AVGManager>.Instance.LoadScript(selectData.loadPath, selectData.NeedReset);
		if (Singleton<AVGManager>.Instance.IsAuto && Singleton<GameConfigManager>.Instance.config.AutoStopMode)
		{
			Singleton<AVGManager>.Instance.IsAuto = false;
		}
		if (GameConfigManager.SkipMode && Singleton<GameConfigManager>.Instance.config.CtrlStopMode)
		{
			GameConfigManager.SkipMode = false;
		}
	}

	// Token: 0x04000185 RID: 389
	private List<SelectData> items;

	// Token: 0x04000186 RID: 390
	[SerializeField]
	private GameObject parent;

	// Token: 0x04000187 RID: 391
	private bool isNeedReset;

	// Token: 0x04000188 RID: 392
	public Button item1;

	// Token: 0x04000189 RID: 393
	public Button item2;
}
