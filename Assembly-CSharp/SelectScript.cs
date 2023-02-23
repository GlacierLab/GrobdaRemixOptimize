using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

// Token: 0x02000058 RID: 88
public class SelectScript : ScriptStruct
{
	// Token: 0x06000186 RID: 390 RVA: 0x00006288 File Offset: 0x00004688
	public List<SelectData> GetItems()
	{
		return this.selectItems;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00006290 File Offset: 0x00004690
	public static SelectScript Create(XmlNode node)
	{
		SelectScript selectScript = new SelectScript();
		selectScript.init(node);
		return selectScript;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x000062AC File Offset: 0x000046AC
	public void init(XmlNode node)
	{
		this.kind = ScriptKind.Select;
		IEnumerator enumerator = node.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				XmlNode xmlNode = (XmlNode)obj;
				this.selectItems.Add(new SelectData(xmlNode));
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
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00006324 File Offset: 0x00004724
	public override BaseAction CreateAction()
	{
		return SelectAction.Create(this);
	}

	// Token: 0x0400011E RID: 286
	private List<SelectData> selectItems = new List<SelectData>();
}
