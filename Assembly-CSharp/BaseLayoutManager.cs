using System;
using System.Collections.Generic;

// Token: 0x020000D4 RID: 212
public abstract class BaseLayoutManager : IBaseLayoutManager
{
	// Token: 0x060004A4 RID: 1188 RVA: 0x00009018 File Offset: 0x00007418
	public virtual bool checkAllLayoutIsWaiting()
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			if (baseLayout.GetStatus() == LayoutStatus.ANIMATION)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x00009088 File Offset: 0x00007488
	public virtual void UpdateAllLayout()
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			baseLayout.UpdateLayout();
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x000090E8 File Offset: 0x000074E8
	public virtual void FinishAllLayout()
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			baseLayout.FinishAction();
		}
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x00009148 File Offset: 0x00007548
	public virtual void ConfigSaveData(SaveData data)
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			baseLayout.ConfigSaveData(data);
		}
	}

	// Token: 0x060004A8 RID: 1192
	public abstract void LoadSaveData(SaveData data);

	// Token: 0x060004A9 RID: 1193
	public abstract void ResetAllLayout();

	// Token: 0x060004AA RID: 1194
	public abstract void DestroyAllLayout();

	// Token: 0x040002BF RID: 703
	protected Dictionary<string, BaseLayout> layouts = new Dictionary<string, BaseLayout>();
}
