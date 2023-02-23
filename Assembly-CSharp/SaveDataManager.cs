using System;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x0200009D RID: 157
public class SaveDataManager
{
	// Token: 0x06000330 RID: 816 RVA: 0x0000B610 File Offset: 0x00009A10
	protected SaveDataManager()
	{
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0000B63A File Offset: 0x00009A3A
	public static SaveDataManager GetInstance()
	{
		if (SaveDataManager.instance == null)
		{
			SaveDataManager.instance = new SaveDataManager();
		}
		return SaveDataManager.instance;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0000B655 File Offset: 0x00009A55
	public void AddSaveData(int name, SaveData data)
	{
		this.savedatas[name] = data;
		this.SaveDataToDisk(name, data, false);
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0000B66A File Offset: 0x00009A6A
	public SaveData GetLatestSaveData()
	{
		return null;
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0000B66D File Offset: 0x00009A6D
	public SaveData GetSaveData(int name)
	{
		return this.savedatas[name];
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0000B677 File Offset: 0x00009A77
	public SaveData[] GetAllSaveData()
	{
		return this.savedatas;
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0000B680 File Offset: 0x00009A80
	public SaveData CopySaveData(int srcName, int dstName)
	{
		if (File.Exists(string.Concat(new object[] { this.filepath, "/", srcName, ".png" })))
		{
			File.Copy(string.Concat(new object[] { this.filepath, "/", srcName, ".png" }), string.Concat(new object[] { this.filepath, "/", dstName, ".png" }), true);
		}
		return this.SaveDataToDisk(dstName, this.GetSaveData(srcName), false);
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0000B734 File Offset: 0x00009B34
	public SaveData SaveDataToDisk(int name, SaveData data, bool isQuick = false)
	{
		this.savedatas[name] = data;
		if (!Directory.Exists(this.filepath))
		{
			Directory.CreateDirectory(this.filepath);
		}
		else if (File.Exists(this.filepath + "/test.png"))
		{
			if (File.Exists(string.Concat(new object[] { this.filepath, "/", name, ".png" })))
			{
				File.Delete(string.Concat(new object[] { this.filepath, "/", name, ".png" }));
			}
			File.Copy(this.filepath + "/test.png", string.Concat(new object[] { this.filepath, "/", name, ".png" }));
		}
		FileStream fileStream = new FileStream(string.Concat(new object[] { this.filepath, "/", name, ".dat" }), FileMode.Create);
		StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8"));
		streamWriter.Write(SaveData.Serializer(data));
		streamWriter.Close();
		fileStream.Close();
		return data;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0000B88E File Offset: 0x00009C8E
	public SaveData SaveDataToDisk(int name, bool isQuick = false)
	{
		return this.SaveDataToDisk(name, this.SaveAvgManager(), isQuick);
	}

	// Token: 0x06000339 RID: 825 RVA: 0x0000B89E File Offset: 0x00009C9E
	private SaveData SaveAvgManager()
	{
		return Singleton<AVGManager>.Instance.CreateSaveData();
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0000B8AC File Offset: 0x00009CAC
	public void SaveAllToDisk()
	{
		if (!Directory.Exists(this.filepath))
		{
			Directory.CreateDirectory(this.filepath);
		}
		for (int i = 0; i < this.savedatas.Length; i++)
		{
			if (this.savedatas[i] != null)
			{
				FileStream fileStream = new FileStream(string.Concat(new object[] { this.filepath, "/", i, ".dat" }), FileMode.Create);
				StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
				streamWriter.Write(SaveData.Serializer(this.savedatas[i]));
				streamWriter.Close();
				fileStream.Close();
			}
		}
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0000B960 File Offset: 0x00009D60
	public void LoadAllSaveData()
	{
		if (!Directory.Exists(this.filepath))
		{
			Directory.CreateDirectory(this.filepath);
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(this.filepath);
		FileInfo[] files = directoryInfo.GetFiles("*.dat");
		foreach (FileInfo fileInfo in files)
		{
			using (StreamReader streamReader = new StreamReader(fileInfo.OpenRead()))
			{
				int num = int.Parse(fileInfo.Name.Split(new char[] { '.' })[0]);
				SaveData saveData = SaveData.Deserialize(streamReader);
				this.savedatas[num] = saveData;
			}
		}
	}

	// Token: 0x0400021B RID: 539
	private string filepath = Application.dataPath + "/save";

	// Token: 0x0400021C RID: 540
	private static SaveDataManager instance;

	// Token: 0x0400021D RID: 541
	private SaveData[] savedatas = new SaveData[100];
}
