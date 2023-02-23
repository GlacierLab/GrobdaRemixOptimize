using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class TextAction : BaseAction
{
	// Token: 0x060000DB RID: 219 RVA: 0x00004230 File Offset: 0x00002630
	public TextAction(TextScript s)
	{
		this.script = s;
		this.text = s.text;
		this.IsNeedClear = s.IsNeedClear;
		this.charsPerSecond = Mathf.Max(1, this.charsPerSecond);
		this.LastTime = 100000f;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00004294 File Offset: 0x00002694
	public static TextAction Create(TextScript s)
	{
		TextAction textAction = new TextAction(s);
		textAction.InitScript(s);
		return textAction;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x000042B0 File Offset: 0x000026B0
	public override void SetLayout(BaseLayout l)
	{
		this.layout = l;
		if (this.layout != null)
		{
			this.layout.SetAction(this);
			if (!((TextLayout)l).IsEffectWrite)
			{
				this.FinishAction();
			}
		}
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000042EC File Offset: 0x000026EC
	public override void FinishAction()
	{
		if (this.layout.gameObject.name == "text")
		{
			Singleton<UIManager>.Instance.ShowTextIcon();
		}
		this.LiveTime = this.LastTime;
		this.layout.SetText(this.text);
		this.layout.SetStatus(LayoutStatus.WAIT);
		if (this.NeedPause)
		{
			Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.PAUSE);
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00004364 File Offset: 0x00002764
	public override void Init()
	{
		Singleton<UIManager>.Instance.NeedShowUi("text");
		Singleton<UIManager>.Instance.HideTextIcon();
		if (this.IsNeedClear)
		{
			((TextLayout)this.layout).ClearSaveText();
		}
		else
		{
			((TextLayout)this.layout).SaveText();
		}
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x000043BC File Offset: 0x000027BC
	public override void Action()
	{
		int num = (int)((float)this.charsPerSecond * this.timer);
		if (num >= this.text.Length - 1)
		{
			num = this.text.Length;
			this.FinishAction();
			return;
		}
		string text = this.text.Substring(0, num);
		this.timer += Time.deltaTime;
		this.layout.SetText(text);
	}

	// Token: 0x0400005F RID: 95
	public string text;

	// Token: 0x04000060 RID: 96
	public float timer;

	// Token: 0x04000061 RID: 97
	public int charsPerSecond = Singleton<GameConfigManager>.Instance.config.TextSpeed;

	// Token: 0x04000062 RID: 98
	public bool IsNeedClear;

	// Token: 0x04000063 RID: 99
	private TextScript script;
}
