using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

// Token: 0x02000040 RID: 64
public class GroupScript : BaseGroupScript
{
	// Token: 0x06000120 RID: 288 RVA: 0x00004C4F File Offset: 0x0000304F
	public List<ScriptStruct> GetAllList()
	{
		return this.list;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00004C57 File Offset: 0x00003057
	public override BaseAction CreateAction()
	{
		return GroupAction.Create(this);
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00004C5F File Offset: 0x0000305F
	public void AddScript(ScriptStruct ss)
	{
		this.list.Add(ss);
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00004C70 File Offset: 0x00003070
	public static GroupScript Create(XmlNode node)
	{
		GroupScript groupScript = new GroupScript();
		IEnumerator enumerator = node.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				XmlNode xmlNode = (XmlNode)obj;
				ScriptStruct scriptStruct = ScriptParse.CreateScript(xmlNode);
				if (scriptStruct != null)
				{
					groupScript.AddScript(ScriptParse.CreateScript(xmlNode));
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
		return groupScript;
	}

	// Token: 0x0400008A RID: 138
	private List<ScriptStruct> list = new List<ScriptStruct>();
}
