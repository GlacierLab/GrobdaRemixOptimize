using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x0200006B RID: 107
public class GameConfigManager : Singleton<GameConfigManager>
{
	// Token: 0x060001D6 RID: 470 RVA: 0x00006DE3 File Offset: 0x000051E3
	public static void ChangeSkipMode()
	{
		if (ScriptExecute.GetInstance().CanSkip())
		{
			GameConfigManager.SkipMode = !GameConfigManager.SkipMode;
			GameConfigManager.SetGameSpeed();
		}
		else
		{
			GameConfigManager.SkipMode = false;
			GameConfigManager.SetGameSpeed();
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00006E16 File Offset: 0x00005216
	public static void ChangeSkipMode(bool b)
	{
		GameConfigManager.SkipMode = b;
		GameConfigManager.SetGameSpeed();
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00006E24 File Offset: 0x00005224
	private static void SetGameSpeed()
	{
		if (GameConfigManager.SkipMode)
		{
			Singleton<VoiceManager>.Instance.StopSE();
			Time.timeScale = (float)GameConfigManager.SkipSpeed;
			Singleton<AVGManager>.Instance.IsAuto = true;
		}
		else
		{
			Time.timeScale = 1f;
			Singleton<AVGManager>.Instance.IsAuto = false;
		}
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00006E75 File Offset: 0x00005275
	public void Init()
	{
		if (File.Exists(GameConfigManager.SavePath))
		{
			this.LoadAllConfig();
		}
		else
		{
			this.InitAllConfig();
		}
		this.ApplyAllConfig();
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00006EA0 File Offset: 0x000052A0
	public static void SetScreenRatio(int index)
	{
		switch (index)
		{
		case 0:
			Screen.SetResolution(1280, 800, Singleton<GameConfigManager>.Instance.config.ScreenMode);
			break;
		case 1:
			Screen.SetResolution(1920, 1200, Singleton<GameConfigManager>.Instance.config.ScreenMode);
			break;
		case 2:
			Screen.SetResolution(1280, 720, Singleton<GameConfigManager>.Instance.config.ScreenMode);
			break;
		case 3:
			Screen.SetResolution(1920, 1080, Singleton<GameConfigManager>.Instance.config.ScreenMode);
			break;
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00006F5C File Offset: 0x0000535C
	public void ApplyAllConfig()
	{
		Screen.fullScreen = this.config.ScreenMode;
		GameConfigManager.SetScreenRatio(this.config.ScreenRatio);
		Singleton<BGMManager>.Instance.SetVolume(this.config.BgmVolume);
		Singleton<SEManager>.Instance.SetVolume(this.config.SEVolume);
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00006FB3 File Offset: 0x000053B3
	public void SaveAllConfig()
	{
		this.InitAllConfig();
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00006FBC File Offset: 0x000053BC
	private void InitAllConfig()
	{
		XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
		xmlSerializerNamespaces.Add(string.Empty, string.Empty);
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.OmitXmlDeclaration = true;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameConfig));
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, this.config, xmlSerializerNamespaces);
				AesUtil.EncryptTextToFile(stringWriter.ToString(), GameConfigManager.SavePath);
			}
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00007074 File Offset: 0x00005474
	private void LoadAllConfig()
	{
		using (StringReader stringReader = new StringReader(AesUtil.DecryptTextFromFile(GameConfigManager.SavePath)))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameConfig));
			this.config = (GameConfig)xmlSerializer.Deserialize(stringReader);
		}
	}

	// Token: 0x04000160 RID: 352
	public static bool SkipMode = false;

	// Token: 0x04000161 RID: 353
	public static bool IsFirstLoad = true;

	// Token: 0x04000162 RID: 354
	public static string SavePath = Application.dataPath + "/config.dat";

	// Token: 0x04000163 RID: 355
	public static int SkipSpeed = 99;

	// Token: 0x04000164 RID: 356
	public GameConfig config = new GameConfig();
}
