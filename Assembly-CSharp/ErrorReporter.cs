using System;

// Token: 0x020000D2 RID: 210
public class ErrorReporter : Singleton<ErrorReporter>
{
	// Token: 0x040002BD RID: 701
	private string debugText = string.Empty;

	// Token: 0x040002BE RID: 702
	private string postURL = "http://157.7.205.205/unity_report.php";
}
