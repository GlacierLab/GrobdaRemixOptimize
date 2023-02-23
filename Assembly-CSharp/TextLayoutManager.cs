using System;

// Token: 0x0200008B RID: 139
public class TextLayoutManager : BaseLayoutManager
{
	// Token: 0x060002D6 RID: 726 RVA: 0x0000A4AD File Offset: 0x000088AD
	protected TextLayoutManager()
	{
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0000A4B5 File Offset: 0x000088B5
	public static TextLayoutManager GetInstance()
	{
		if (TextLayoutManager.instance == null)
		{
			TextLayoutManager.instance = new TextLayoutManager();
		}
		return TextLayoutManager.instance;
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0000A4D0 File Offset: 0x000088D0
	public void InitAllTextLayout()
	{
		UIGameObject ui = Singleton<UIManager>.Instance.GetUi("text");
		TextLayout[] componentsInChildren = ui.GetComponentsInChildren<TextLayout>(true);
		foreach (TextLayout textLayout in componentsInChildren)
		{
			this.layouts.Add(textLayout.name, textLayout);
		}
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x0000A526 File Offset: 0x00008926
	public TextLayout GetLayout(string name)
	{
		if (this.layouts.ContainsKey(name))
		{
			return (TextLayout)this.layouts[name];
		}
		return null;
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0000A54C File Offset: 0x0000894C
	public override void LoadSaveData(SaveData data)
	{
		Singleton<UIManager>.Instance.ShowUi("text");
		this.ConfigTextLayout("name", data.name);
		this.ConfigTextLayout("text", data.text);
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0000A57F File Offset: 0x0000897F
	public override void ResetAllLayout()
	{
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0000A581 File Offset: 0x00008981
	public override void DestroyAllLayout()
	{
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0000A584 File Offset: 0x00008984
	private void ConfigTextLayout(string id, string text)
	{
		TextLayout textLayout = this.layouts[id] as TextLayout;
		if (textLayout == null)
		{
			return;
		}
		textLayout.SetText(text);
	}

	// Token: 0x040001E1 RID: 481
	private static TextLayoutManager instance;
}
