using System;

// Token: 0x020000D3 RID: 211
internal interface IBaseLayoutManager
{
	// Token: 0x0600049C RID: 1180
	bool checkAllLayoutIsWaiting();

	// Token: 0x0600049D RID: 1181
	void UpdateAllLayout();

	// Token: 0x0600049E RID: 1182
	void FinishAllLayout();

	// Token: 0x0600049F RID: 1183
	void ConfigSaveData(SaveData data);

	// Token: 0x060004A0 RID: 1184
	void LoadSaveData(SaveData data);

	// Token: 0x060004A1 RID: 1185
	void ResetAllLayout();

	// Token: 0x060004A2 RID: 1186
	void DestroyAllLayout();
}
