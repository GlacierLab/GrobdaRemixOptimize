using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class HeadSoundPanelControlScript : MonoBehaviour
{
	// Token: 0x0600039F RID: 927 RVA: 0x0000C794 File Offset: 0x0000AB94
	public void reset()
	{
		this.sy.Init(1f);
		this.ly.Init(1f);
		this.bn.Init(1f);
		this.fen.Init(1f);
		this.biao.Init(1f);
		this.zw.Init(1f);
		this.other.Init(1f);
		Singleton<GameConfigManager>.Instance.config.syVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.lyVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.bnVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.fenVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.zhangVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.zwVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.otherVolume = 1f;
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x0000C8A0 File Offset: 0x0000ACA0
	public void Init()
	{
		this.sy.Init(Singleton<GameConfigManager>.Instance.config.syVolume);
		this.ly.Init(Singleton<GameConfigManager>.Instance.config.lyVolume);
		this.bn.Init(Singleton<GameConfigManager>.Instance.config.bnVolume);
		this.fen.Init(Singleton<GameConfigManager>.Instance.config.fenVolume);
		this.biao.Init(Singleton<GameConfigManager>.Instance.config.zhangVolume);
		this.zw.Init(Singleton<GameConfigManager>.Instance.config.zwVolume);
		this.other.Init(Singleton<GameConfigManager>.Instance.config.otherVolume);
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x0000C963 File Offset: 0x0000AD63
	public void SetActive(bool b)
	{
		base.gameObject.SetActive(b);
	}

	// Token: 0x0400023A RID: 570
	public SYControlScript sy;

	// Token: 0x0400023B RID: 571
	public LyControlScript ly;

	// Token: 0x0400023C RID: 572
	public BnControlScript bn;

	// Token: 0x0400023D RID: 573
	public FenControlScript fen;

	// Token: 0x0400023E RID: 574
	public BiaoControlScript biao;

	// Token: 0x0400023F RID: 575
	public ZWControlScript zw;

	// Token: 0x04000240 RID: 576
	public OtherControlScript other;
}
