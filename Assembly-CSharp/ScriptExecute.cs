using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000052 RID: 82
[Serializable]
public class ScriptExecute
{
	// Token: 0x0600016A RID: 362 RVA: 0x000055B0 File Offset: 0x000039B0
	protected ScriptExecute()
	{
		this.parse = new ScriptParse();
		this.parse.InitAllDict();
	}

	// Token: 0x0600016B RID: 363 RVA: 0x000055E4 File Offset: 0x000039E4
	public static ScriptExecute GetInstance()
	{
		if (ScriptExecute._instance == null)
		{
			ScriptExecute._instance = new ScriptExecute();
		}
		return ScriptExecute._instance;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00005600 File Offset: 0x00003A00
	public void LoadScriptFromResource(string path)
	{
		this.index = 0;
		this.nowpath = path;
		Debug.Log(ScriptExecute.filePath + path);
		string text = ScriptExecute.filePath + path + ".xml";
		if (File.Exists(text))
		{
			Debug.Log("load from disk file name:" + text);
			this.scripts = this.parse.CreateScriptStructFromText(text, true);
			this.nowDataSaveItem = DataSaveManager.GetInstance().GetDataSaveItem(path);
		}
		else
		{
			Debug.Log("load from resource file name:" + path);
			this.scripts = this.parse.CreateScriptStructFromText(path, false);
			this.nowDataSaveItem = DataSaveManager.GetInstance().GetDataSaveItem(path);
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x000056B4 File Offset: 0x00003AB4
	private bool IsRead()
	{
		if (this.nowDataSaveItem.line > this.index)
		{
			return true;
		}
		this.nowDataSaveItem.line = this.index;
		return false;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x000056E0 File Offset: 0x00003AE0
	public bool CanSkip()
	{
		return this.IsRead() || Singleton<GameConfigManager>.Instance.config.CtrlMode;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x000056FF File Offset: 0x00003AFF
	public void LoadScriptFromResource(string path, int i)
	{
		this.LoadScriptFromResource(path);
		this.index = i;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0000570F File Offset: 0x00003B0F
	private void AddHistoryItem(TextGroupScript s)
	{
		if (this.history.Count > this.maxHistory)
		{
			this.history.RemoveAt(0);
		}
		this.history.Add(s);
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00005740 File Offset: 0x00003B40
	public ScriptStruct GetNextStruct()
	{
		if (this.index < this.scripts.Count)
		{
			this.temp = this.scripts[this.index++];
			this.IsRead();
			if (this.temp is TextGroupScript)
			{
				this.AddHistoryItem(this.temp as TextGroupScript);
			}
			return this.temp;
		}
		return null;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x000057B5 File Offset: 0x00003BB5
	public void ConfigSaveData(SaveData data)
	{
		data.script_path = this.nowpath;
		data.index = this.index - 1;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x000057D1 File Offset: 0x00003BD1
	public void LoadSaveData(SaveData data)
	{
		this.LoadScriptFromResource(data.script_path, data.index);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000057E5 File Offset: 0x00003BE5
	public void ClearHistory()
	{
		this.history.Clear();
	}

	// Token: 0x06000175 RID: 373 RVA: 0x000057F2 File Offset: 0x00003BF2
	public List<TextGroupScript> GetHistory()
	{
		return this.history;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x000057FA File Offset: 0x00003BFA
	public TextGroupScript GetLastHistory()
	{
		if (this.history.Count == 0)
		{
			return null;
		}
		return this.history[this.history.Count - 1];
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00005826 File Offset: 0x00003C26
	public void ResetExecute()
	{
		this.index = 0;
		this.scripts.Clear();
	}

	// Token: 0x040000B1 RID: 177
	public ScriptParse parse;

	// Token: 0x040000B2 RID: 178
	public List<ScriptStruct> scripts;

	// Token: 0x040000B3 RID: 179
	private List<TextGroupScript> history = new List<TextGroupScript>();

	// Token: 0x040000B4 RID: 180
	public int index;

	// Token: 0x040000B5 RID: 181
	[SerializeField]
	private string nowpath;

	// Token: 0x040000B6 RID: 182
	private ScriptStruct temp;

	// Token: 0x040000B7 RID: 183
	private DataSaveItem nowDataSaveItem;

	// Token: 0x040000B8 RID: 184
	private int maxHistory = 300;

	// Token: 0x040000B9 RID: 185
	private static string filePath = Application.dataPath + "/data/";

	// Token: 0x040000BA RID: 186
	private static ScriptExecute _instance;
}
