using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200007A RID: 122
[RequireComponent(typeof(Text))]
public class TextLayout : BaseLayout
{
	// Token: 0x0600023B RID: 571 RVA: 0x00007DFB File Offset: 0x000061FB
	private void Awake()
	{
		this.kind = LayoutKind.Text;
		if (this.myEvent == null)
		{
			this.myEvent = new UnityEvent();
		}
		this.mText = base.GetComponent<Text>();
		this.mText.text = string.Empty;
	}

	// Token: 0x0600023C RID: 572 RVA: 0x00007E36 File Offset: 0x00006236
	public override void SetAction(BaseAction a)
	{
		this.action.Clear();
		this.action.Add(a);
		this.status = LayoutStatus.ANIMATION;
	}

	// Token: 0x0600023D RID: 573 RVA: 0x00007E58 File Offset: 0x00006258
	public override void FinishAction()
	{
		base.FinishAction();
		try
		{
			this.myEvent.Invoke();
		}
		catch (Exception)
		{
			Debug.Log("问题");
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x00007E9C File Offset: 0x0000629C
	private void Update()
	{
	}

	// Token: 0x0600023F RID: 575 RVA: 0x00007E9E File Offset: 0x0000629E
	public override void SetText(string str)
	{
		this.mText.text = this.saveText + str;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00007EB7 File Offset: 0x000062B7
	public void SaveText()
	{
		this.saveText = this.mText.text;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x00007ECA File Offset: 0x000062CA
	public void ClearSaveText()
	{
		this.saveText = string.Empty;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00007ED8 File Offset: 0x000062D8
	public override void ConfigSaveData(SaveData data)
	{
		string name = base.name;
		if (name != null)
		{
			if (!(name == "text"))
			{
				if (name == "name")
				{
					data.name = this.mText.text;
				}
			}
			else
			{
				data.text = this.mText.text;
			}
		}
	}

	// Token: 0x0400018A RID: 394
	public UnityEvent myEvent;

	// Token: 0x0400018B RID: 395
	public bool IsEffectWrite = true;

	// Token: 0x0400018C RID: 396
	private Text mText;

	// Token: 0x0400018D RID: 397
	private string saveText = string.Empty;
}
