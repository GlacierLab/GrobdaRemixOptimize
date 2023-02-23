using System;

// Token: 0x02000082 RID: 130
public class LayoutManager : IBaseLayoutManager
{
	// Token: 0x0600029C RID: 668 RVA: 0x00009760 File Offset: 0x00007B60
	protected LayoutManager()
	{
		this.imageLayoutsManager = ImageLayoutsManager.GetInstance();
		this.textLayoutManager = TextLayoutManager.GetInstance();
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0000977E File Offset: 0x00007B7E
	public static LayoutManager GetInstance()
	{
		if (LayoutManager.instance == null)
		{
			LayoutManager.instance = new LayoutManager();
		}
		return LayoutManager.instance;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x00009799 File Offset: 0x00007B99
	public bool checkAllLayoutIsWaiting()
	{
		return this.imageLayoutsManager.checkAllLayoutIsWaiting() && this.textLayoutManager.checkAllLayoutIsWaiting();
	}

	// Token: 0x0600029F RID: 671 RVA: 0x000097B9 File Offset: 0x00007BB9
	public void UpdateAllLayout()
	{
		this.imageLayoutsManager.UpdateAllLayout();
		this.textLayoutManager.UpdateAllLayout();
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x000097D1 File Offset: 0x00007BD1
	public void UpdateActBgLayout()
	{
		this.imageLayoutsManager.UpdataAllActBg();
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x000097DE File Offset: 0x00007BDE
	public void FinishAllLayout()
	{
		this.imageLayoutsManager.FinishAllLayout();
		this.textLayoutManager.FinishAllLayout();
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x000097F6 File Offset: 0x00007BF6
	public void ConfigSaveData(SaveData data)
	{
		this.imageLayoutsManager.ConfigSaveData(data);
		this.textLayoutManager.ConfigSaveData(data);
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00009810 File Offset: 0x00007C10
	public void LoadSaveData(SaveData data)
	{
		this.imageLayoutsManager.LoadSaveData(data);
		this.textLayoutManager.LoadSaveData(data);
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x0000982A File Offset: 0x00007C2A
	public void ResetAllLayout()
	{
		this.imageLayoutsManager.ResetAllLayout();
		this.textLayoutManager.ResetAllLayout();
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x00009842 File Offset: 0x00007C42
	public void DestroyAllLayout()
	{
		this.imageLayoutsManager.DestroyAllLayout();
		this.textLayoutManager.DestroyAllLayout();
	}

	// Token: 0x040001BE RID: 446
	private static LayoutManager instance;

	// Token: 0x040001BF RID: 447
	private ImageLayoutsManager imageLayoutsManager;

	// Token: 0x040001C0 RID: 448
	private TextLayoutManager textLayoutManager;
}
