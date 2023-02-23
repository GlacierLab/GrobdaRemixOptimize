using System;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class UnityUtil
{
	// Token: 0x060004BC RID: 1212 RVA: 0x0000FE94 File Offset: 0x0000E294
	public static Color ToColor(string colorName)
	{
		if (colorName.StartsWith("#"))
		{
			colorName = colorName.Replace("#", string.Empty);
		}
		int num = int.Parse(colorName, NumberStyles.HexNumber);
		return new Color
		{
			a = (float)Convert.ToByte((num >> 24) & 255),
			r = (float)Convert.ToByte((num >> 16) & 255),
			g = (float)Convert.ToByte((num >> 8) & 255),
			b = (float)Convert.ToByte((num >> 0) & 255)
		};
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0000FF34 File Offset: 0x0000E334
	public static void MakeCameraImg(int name)
	{
		Rect rect = new Rect(0f, 0f, 1f, 1f);
		int width = Screen.width;
		int height = Screen.height;
		Camera component = GameObject.Find("Main Camera").GetComponent<Camera>();
		if (component == null)
		{
			return;
		}
		RenderTexture renderTexture = new RenderTexture(width, height, 2);
		component.pixelRect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
		component.targetTexture = renderTexture;
		Texture2D texture2D = new Texture2D((int)((float)width * rect.width), (int)((float)height * rect.height), TextureFormat.RGB24, false);
		component.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect((float)width * rect.x, (float)width * rect.y, (float)width * rect.width, (float)height * rect.height), 0, 0);
		component.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.Destroy(renderTexture);
		byte[] array = texture2D.EncodeToPNG();
		string text = string.Concat(new object[]
		{
			UnityUtil.filepath,
			"/",
			name,
			".png"
		});
		File.WriteAllBytes(text, array);
	}

	// Token: 0x040002C3 RID: 707
	private static string filepath = Application.dataPath + "/save";
}
