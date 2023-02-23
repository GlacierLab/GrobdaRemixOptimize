using System;

// Token: 0x02000032 RID: 50
public class VolumeAction : BaseAction
{
	// Token: 0x060000EA RID: 234 RVA: 0x000044E4 File Offset: 0x000028E4
	public override void Action()
	{
		string text = this.kind;
		if (text != null)
		{
			if (!(text == "bgm"))
			{
				if (text == "se")
				{
					Singleton<SEManager>.Instance.SetVolume((float)this.v / 100f);
				}
			}
			else
			{
				Singleton<BGMManager>.Instance.SetVolume((float)this.v / 100f);
			}
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00004560 File Offset: 0x00002960
	public override void FinishAction()
	{
		this.Action();
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00004568 File Offset: 0x00002968
	public static BaseAction Create(VolumeScript volumeScript)
	{
		VolumeAction volumeAction = new VolumeAction();
		volumeAction.init(volumeScript);
		volumeAction.InitScript(volumeScript);
		return volumeAction;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000458A File Offset: 0x0000298A
	private void init(VolumeScript volumeScript)
	{
		this.v = volumeScript.v;
		this.kind = volumeScript.k;
		this.LastTime = 0f;
	}

	// Token: 0x04000066 RID: 102
	private int v;

	// Token: 0x04000067 RID: 103
	private string kind;
}
