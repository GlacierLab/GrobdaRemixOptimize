using System;
using System.Reflection;
using UnityEngine;

// Token: 0x0200006E RID: 110
[Obfuscation(Exclude = true)]
public class DebugScreen : MonoBehaviour
{
	// Token: 0x060001E6 RID: 486 RVA: 0x0000713D File Offset: 0x0000553D
	private void Start()
	{
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000713F File Offset: 0x0000553F
	private void Update()
	{
		this.UpdateTick();
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00007147 File Offset: 0x00005547
	private void OnGUI()
	{
		this.DrawFps();
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00007150 File Offset: 0x00005550
	private void DrawFps()
	{
		if (DebugScreen.mLastFps > 50L)
		{
			GUI.color = new Color(0f, 1f, 0f);
		}
		else if (DebugScreen.mLastFps > 40L)
		{
			GUI.color = new Color(1f, 1f, 0f);
		}
		else
		{
			GUI.color = new Color(1f, 0f, 0f);
		}
		GUI.Label(new Rect(0f, 0f, 64f, 24f), "fps: " + DebugScreen.mLastFps);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00007200 File Offset: 0x00005600
	private void UpdateTick()
	{
		this.mFrameCount += 1L;
		long num = DebugScreen.TickToMilliSec(DateTime.Now.Ticks);
		if (this.mLastFrameTime == 0L)
		{
			this.mLastFrameTime = DebugScreen.TickToMilliSec(DateTime.Now.Ticks);
		}
		if (num - this.mLastFrameTime >= 1000L)
		{
			long num2 = (long)((float)this.mFrameCount * 1f / ((float)(num - this.mLastFrameTime) / 1000f));
			DebugScreen.mLastFps = num2;
			this.mFrameCount = 0L;
			this.mLastFrameTime = num;
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0000729B File Offset: 0x0000569B
	public static long TickToMilliSec(long tick)
	{
		return tick / 10000L;
	}

	// Token: 0x0400016B RID: 363
	private long mFrameCount;

	// Token: 0x0400016C RID: 364
	private long mLastFrameTime;

	// Token: 0x0400016D RID: 365
	private static long mLastFps;
}
