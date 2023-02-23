using System;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class GlobleDebug
{
	// Token: 0x060001ED RID: 493 RVA: 0x000072A7 File Offset: 0x000056A7
	protected GlobleDebug()
	{
	}

	// Token: 0x060001EE RID: 494 RVA: 0x000072AF File Offset: 0x000056AF
	public static void Log(object message)
	{
		if (GlobleDebug.canLog)
		{
			Debug.Log(message);
		}
	}

	// Token: 0x060001EF RID: 495 RVA: 0x000072C1 File Offset: 0x000056C1
	public static void Log(object message, UnityEngine.Object context)
	{
		if (GlobleDebug.canLog)
		{
			Debug.Log(message, context);
		}
	}

	// Token: 0x0400016E RID: 366
	private static bool canLog = true;
}
