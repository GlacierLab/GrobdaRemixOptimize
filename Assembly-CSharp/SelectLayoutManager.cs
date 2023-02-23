using System;

// Token: 0x02000089 RID: 137
public class SelectLayoutManager
{
	// Token: 0x060002C7 RID: 711 RVA: 0x0000A2F7 File Offset: 0x000086F7
	protected SelectLayoutManager()
	{
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0000A2FF File Offset: 0x000086FF
	public static SelectLayoutManager GetInstance()
	{
		if (SelectLayoutManager.instance == null)
		{
			SelectLayoutManager.instance = new SelectLayoutManager();
		}
		return SelectLayoutManager.instance;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x0000A31C File Offset: 0x0000871C
	public void InitAllSelectLayout()
	{
		UIGameObject ui = Singleton<UIManager>.Instance.GetUi("select");
		this.selectLayout = ui.GetComponentsInChildren<SelectLayout>(true)[0];
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0000A348 File Offset: 0x00008748
	public SelectLayout GetSelectLayout()
	{
		return this.selectLayout;
	}

	// Token: 0x040001DA RID: 474
	private static SelectLayoutManager instance;

	// Token: 0x040001DB RID: 475
	private SelectLayout selectLayout;
}
