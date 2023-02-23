using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

// Token: 0x02000053 RID: 83
public class ScriptParse
{
	// Token: 0x0600017A RID: 378 RVA: 0x00005858 File Offset: 0x00003C58
	public void InitAllDict()
	{
		ScriptParse.funcDict.Clear();
		ScriptParse.funcDict.Add("fadein", new ScriptParse.CreateSpriteStruct(FadeInScript.Create));
		ScriptParse.funcDict.Add("fadeout", new ScriptParse.CreateSpriteStruct(FadeOutScript.Create));
		ScriptParse.funcDict.Add("text", new ScriptParse.CreateSpriteStruct(TextScript.Create));
		ScriptParse.funcDict.Add("p", new ScriptParse.CreateSpriteStruct(PauseScript.Create));
		ScriptParse.funcDict.Add("image", new ScriptParse.CreateSpriteStruct(SetImageScript.Create));
		ScriptParse.funcDict.Add("playbgm", new ScriptParse.CreateSpriteStruct(PlayBgmScript.Create));
		ScriptParse.funcDict.Add("stopbgm", new ScriptParse.CreateSpriteStruct(StopBgmScript.Create));
		ScriptParse.funcDict.Add("move", new ScriptParse.CreateSpriteStruct(MoveScript.Create));
		ScriptParse.funcDict.Add("playse", new ScriptParse.CreateSpriteStruct(PlaySeScript.Create));
		ScriptParse.funcDict.Add("setposition", new ScriptParse.CreateSpriteStruct(SetPostionScript.Create));
		ScriptParse.funcDict.Add("load", new ScriptParse.CreateSpriteStruct(LoadScript.Create));
		ScriptParse.funcDict.Add("delete", new ScriptParse.CreateSpriteStruct(DeleteLayoutScript.Create));
		ScriptParse.funcDict.Add("hide", new ScriptParse.CreateSpriteStruct(HideScript.Create));
		ScriptParse.funcDict.Add("show", new ScriptParse.CreateSpriteStruct(ShowScript.Create));
		ScriptParse.funcDict.Add("create", new ScriptParse.CreateSpriteStruct(global::CreateScript.Create));
		ScriptParse.funcDict.Add("system", new ScriptParse.CreateSpriteStruct(SystemScript.Create));
		ScriptParse.funcDict.Add("addin", new ScriptParse.CreateSpriteStruct(AddinScript.Create));
		ScriptParse.funcDict.Add("group", new ScriptParse.CreateSpriteStruct(GroupScript.Create));
		ScriptParse.funcDict.Add("wait", new ScriptParse.CreateSpriteStruct(WaitScript.Create));
		ScriptParse.funcDict.Add("textp", new ScriptParse.CreateSpriteStruct(TextGroupScript.Create));
		ScriptParse.funcDict.Add("setalpha", new ScriptParse.CreateSpriteStruct(SetAlphaScript.Create));
		ScriptParse.funcDict.Add("select", new ScriptParse.CreateSpriteStruct(SelectScript.Create));
		ScriptParse.funcDict.Add("rotate", new ScriptParse.CreateSpriteStruct(RotateScript.Create));
		ScriptParse.funcDict.Add("volume", new ScriptParse.CreateSpriteStruct(VolumeScript.Create));
		ScriptParse.funcDict.Add("light", new ScriptParse.CreateSpriteStruct(CreateLightScript.Create));
		ScriptParse.funcDict.Add("deletelight", new ScriptParse.CreateSpriteStruct(DelectLightScript.Create));
		ScriptParse.funcDict.Add("lightpower", new ScriptParse.CreateSpriteStruct(LightPowerScript.Create));
		ScriptParse.funcDict.Add("lightrange", new ScriptParse.CreateSpriteStruct(LightRangeScript.Create));
		ScriptParse.funcDict.Add("swapimage", new ScriptParse.CreateSpriteStruct(SwapImageScript.Create));
		ScriptParse.funcDict.Add("shadercolorchange", new ScriptParse.CreateSpriteStruct(ShaderColorChangeScript.Create));
		ScriptParse.funcDict.Add("blur", new ScriptParse.CreateSpriteStruct(BlurScript.Create));
		ScriptParse.funcDict.Add("blurchange", new ScriptParse.CreateSpriteStruct(BlurChangeScript.Create));
		ScriptParse.funcDict.Add("stopse", new ScriptParse.CreateSpriteStruct(StopBeScript.Create));
		ScriptParse.funcDict.Add("voice", new ScriptParse.CreateSpriteStruct(VoiceScript.Create));
		ScriptParse.funcDict.Add("movie", new ScriptParse.CreateSpriteStruct(MovieScript.Create));
		ScriptParse.funcDict.Add("showui", new ScriptParse.CreateSpriteStruct(ShowUIScript.Create));
		ScriptParse.funcDict.Add("hideui", new ScriptParse.CreateSpriteStruct(HideUIScript.Create));
		ScriptParse.funcDict.Add("scale", new ScriptParse.CreateSpriteStruct(ScaleScript.Create));
		ScriptParse.funcDict.Add("actbg", new ScriptParse.CreateSpriteStruct(ActBgScript.Create));
		ScriptParse.funcDict.Add("quake", new ScriptParse.CreateSpriteStruct(QuakeScript.Create));
		ScriptParse.funcDict.Add("deleteactbg", new ScriptParse.CreateSpriteStruct(DelectActbgScript.Create));
		ScriptParse.funcDict.Add("pausebgm", new ScriptParse.CreateSpriteStruct(PauseBgmScript.Create));
		ScriptParse.funcDict.Add("unpausebgm", new ScriptParse.CreateSpriteStruct(UnPauseBgmScript.Create));
		ScriptParse.funcDict.Add("textvisible", new ScriptParse.CreateSpriteStruct(TextVisibleScript.Create));
		ScriptParse.funcDict.Add("setgroupflag", new ScriptParse.CreateSpriteStruct(SetGroupFlagScript.Create));
		ScriptParse.funcDict.Add("returntoUI", new ScriptParse.CreateSpriteStruct(ReturnToUIScript.Create));
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00006058 File Offset: 0x00004458
	public List<ScriptStruct> CreateScriptStructFromText(string path, bool isFromDisk = false)
	{
		DateTime now = DateTime.Now;
		XmlDocument xmlDocument = new XmlDocument();
		List<ScriptStruct> list = new List<ScriptStruct>();
		if (isFromDisk)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				using (StreamReader streamReader = new StreamReader(fileStream))
				{
					xmlDocument.LoadXml(streamReader.ReadToEnd());
					streamReader.Close();
				}
			}
		}
		else
		{
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			xmlDocument.LoadXml(textAsset.text);
		}
		DateTime now2 = DateTime.Now;
		Debug.Log("load xml time:" + (now2 - now));
		XmlNode firstChild = xmlDocument.FirstChild;
		XmlNodeList childNodes = firstChild.ChildNodes;
		IEnumerator enumerator = childNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				XmlNode xmlNode = (XmlNode)obj;
				ScriptStruct scriptStruct = ScriptParse.CreateScript(xmlNode);
				if (scriptStruct != null)
				{
					list.Add(scriptStruct);
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		DateTime now3 = DateTime.Now;
		Debug.Log(string.Concat(new object[]
		{
			"load ",
			path,
			" xml time:",
			now3 - now2
		}));
		return list;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x000061D8 File Offset: 0x000045D8
	public static ScriptStruct CreateScript(XmlNode node)
	{
		string name = node.Name;
		if (ScriptParse.funcDict.ContainsKey(name))
		{
			return ScriptParse.funcDict[name](node);
		}
		return null;
	}

	// Token: 0x040000BB RID: 187
	public static Dictionary<string, ScriptParse.CreateSpriteStruct> funcDict = new Dictionary<string, ScriptParse.CreateSpriteStruct>();

	// Token: 0x02000054 RID: 84
	// (Invoke) Token: 0x0600017F RID: 383
	public delegate ScriptStruct CreateSpriteStruct(XmlNode node);
}
