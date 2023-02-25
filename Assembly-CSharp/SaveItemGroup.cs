using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Token: 0x020000B5 RID: 181
public class SaveItemGroup : MonoBehaviour
{
	// Token: 0x060003FB RID: 1019 RVA: 0x0000D864 File Offset: 0x0000BC64
	private void Awake()
	{
		Text[] componentsInChildren = base.GetComponentsInChildren<Text>();
		this.index = componentsInChildren[0];
		this.time = componentsInChildren[1];
		this.screenshot = this.GetImageInfo();
		this.screenshot.gameObject.SetActive(false);
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0000D8A7 File Offset: 0x0000BCA7
	public void ClearImage()
	{
		if (this.screenshot != null)
		{
			this.screenshot.sprite = null;
		}
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0000D8C8 File Offset: 0x0000BCC8
	private Image GetImageInfo()
	{
		Image[] componentsInChildren = base.GetComponentsInChildren<Image>();
		foreach (Image image in componentsInChildren)
		{
			if (image.name == "gameinfo")
			{
				return image;
			}
		}
		return null;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0000D910 File Offset: 0x0000BD10
	public void SetSaveData(SaveData sd, int i)
	{
		this.saveData = sd;
		if (this.saveData != null)
		{
			this.SetImage(string.Concat(new object[]
			{
				Application.dataPath,
				"/save/",
				i,
				".png"
			}));
			this.time.text = sd.time + string.Empty;
			DateTime dateTime = TimeUtil.UnixTimestampToDateTime(sd.time);
			this.time.text = string.Concat(new object[]
			{
				dateTime.Year, "/", dateTime.Month, "/", dateTime.Day, "\n", dateTime.Hour, ":", dateTime.Minute, ":",
				dateTime.Second
			});
		}
		else
		{
			this.SetImage(null);
			this.time.text = string.Empty;
		}
		this.SetIndex(i);
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0000DA4C File Offset: 0x0000BE4C
	private void SetIndex(int i)
	{
		this.num = i;
		if (i == 0)
		{
			this.index.text = "auto";
			return;
		}
		string text = i.ToString();
		if (i < 10)
		{
			text = "0" + text;
		}
		this.index.text = text;
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0000DAA5 File Offset: 0x0000BEA5
	private void SetImage(string path)
	{
		if (path == null)
		{
			this.screenshot.gameObject.SetActive(false);
			return;
		}
		this.img = path;
		base.StartCoroutine(this.LoadImage());
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0000DAD4 File Offset: 0x0000BED4
	private IEnumerator LoadImage()
	{
        Texture2D tex = null;
		if (File.Exists(this.img))
		{
            using (UnityWebRequest www = UnityWebRequest.GetTexture(("file://" + this.img),true))
            {
                yield return www.Send();

                if (www.isError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    tex = DownloadHandlerTexture.GetContent(www);
                }
            }
		}
		yield return 0;
		this.screenshot.sprite = this.GetSpriteFromTexture(tex);
		yield return 0;
		this.screenshot.gameObject.SetActive(true);
		yield return 0;
		yield break;
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0000DAF0 File Offset: 0x0000BEF0
	private Sprite LoadPNG(string filePath)
	{
		if (File.Exists(filePath))
		{
			byte[] array = File.ReadAllBytes(filePath);
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.DXT5, false);
			texture2D.LoadImage(array);
			return this.GetSpriteFromTexture(texture2D);
		}
		return null;
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0000DB2D File Offset: 0x0000BF2D
	private Sprite GetSpriteFromTexture(Texture2D tex)
	{
		return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2(0f, 0f));
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0000DB61 File Offset: 0x0000BF61
	public void ClickLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		if (this.saveData == null)
		{
			return;
		}
		this.SaveDialog.Init(this);
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0000DB85 File Offset: 0x0000BF85
	public void ClickSave()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.SaveDialog.Init(this);
	}

	// Token: 0x04000268 RID: 616
	[SerializeField]
	private Text index;

	// Token: 0x04000269 RID: 617
	[SerializeField]
	private Text time;

	// Token: 0x0400026A RID: 618
	[SerializeField]
	private Image screenshot;

	// Token: 0x0400026B RID: 619
	[SerializeField]
	public SaveData saveData;

	// Token: 0x0400026C RID: 620
	private string img;

	// Token: 0x0400026D RID: 621
	public GameObject canvas;

	// Token: 0x0400026E RID: 622
	public int num;

	// Token: 0x0400026F RID: 623
	public SaveDialogScript SaveDialog;
}
