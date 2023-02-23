using System;

// Token: 0x0200006A RID: 106
[Serializable]
public class GameConfig
{
	// Token: 0x060001D0 RID: 464 RVA: 0x00006B5A File Offset: 0x00004F5A
	public float GetBgmVolume()
	{
		if (this.BgmMute)
		{
			return 0f;
		}
		return this.BgmVolume;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00006B73 File Offset: 0x00004F73
	public float GetSeVolume()
	{
		if (this.SeMute)
		{
			return 0f;
		}
		return this.SEVolume;
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00006B8C File Offset: 0x00004F8C
	public float GetSystemVolume()
	{
		if (this.SystemMute)
		{
			return 0f;
		}
		return this.SystemVolume;
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00006BA5 File Offset: 0x00004FA5
	public float GetMovieVolume()
	{
		if (this.MovieMute)
		{
			return 0f;
		}
		return this.MovieVolume;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00006BC0 File Offset: 0x00004FC0
	public float GetVolumeByKind(int i)
	{
		switch (i)
		{
		case 0:
			return this.syVolume;
		case 1:
			return this.lyVolume;
		case 2:
			return this.bnVolume;
		case 3:
			return this.fenVolume;
		case 4:
			return this.zhangVolume;
		case 5:
			return this.zwVolume;
		case 6:
			return this.otherVolume;
		default:
			return this.syVolume;
		}
	}

	// Token: 0x04000140 RID: 320
	public bool IsStepMode;

	// Token: 0x04000141 RID: 321
	public bool ScreenMode;

	// Token: 0x04000142 RID: 322
	public int ScreenRatio;

	// Token: 0x04000143 RID: 323
	public bool ResourceMode;

	// Token: 0x04000144 RID: 324
	public bool HisStoryMode = true;

	// Token: 0x04000145 RID: 325
	public bool MouseHide;

	// Token: 0x04000146 RID: 326
	public bool MouseChange;

	// Token: 0x04000147 RID: 327
	public bool MouseSpeed = true;

	// Token: 0x04000148 RID: 328
	public int TextSpeed = 7;

	// Token: 0x04000149 RID: 329
	public float AutoTime = 2f;

	// Token: 0x0400014A RID: 330
	public int FontKind;

	// Token: 0x0400014B RID: 331
	public bool CtrlMode;

	// Token: 0x0400014C RID: 332
	public bool AutoStopMode;

	// Token: 0x0400014D RID: 333
	public bool CtrlStopMode;

	// Token: 0x0400014E RID: 334
	public float BgmVolume = 0.3f;

	// Token: 0x0400014F RID: 335
	public bool BgmMute;

	// Token: 0x04000150 RID: 336
	public float SEVolume = 1f;

	// Token: 0x04000151 RID: 337
	public bool SeMute;

	// Token: 0x04000152 RID: 338
	public float SystemVolume = 1f;

	// Token: 0x04000153 RID: 339
	public bool SystemMute;

	// Token: 0x04000154 RID: 340
	public float MovieVolume = 1f;

	// Token: 0x04000155 RID: 341
	public bool MovieMute;

	// Token: 0x04000156 RID: 342
	public bool TextVoiceStop;

	// Token: 0x04000157 RID: 343
	public bool SkipVoiceStop = true;

	// Token: 0x04000158 RID: 344
	public float syVolume = 1f;

	// Token: 0x04000159 RID: 345
	public float lyVolume = 1f;

	// Token: 0x0400015A RID: 346
	public float bnVolume = 1f;

	// Token: 0x0400015B RID: 347
	public float fenVolume = 1f;

	// Token: 0x0400015C RID: 348
	public float zhangVolume = 1f;

	// Token: 0x0400015D RID: 349
	public float zwVolume = 1f;

	// Token: 0x0400015E RID: 350
	public float otherVolume = 1f;

	// Token: 0x0400015F RID: 351
	public float textAlpha = 0.5f;
}
