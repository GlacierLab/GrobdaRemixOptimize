using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000081 RID: 129
public class ImageLayoutsManager : BaseLayoutManager
{
	// Token: 0x06000285 RID: 645 RVA: 0x000091AC File Offset: 0x000075AC
	protected ImageLayoutsManager()
	{
	}

	// Token: 0x06000286 RID: 646 RVA: 0x000091BC File Offset: 0x000075BC
	public CameraLayout GetCameraLayout()
	{
		if (this.cameraLayout == null)
		{
			this.InitCameraLayout();
		}
		return this.cameraLayout;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x000091DB File Offset: 0x000075DB
	public static ImageLayoutsManager GetInstance()
	{
		if (ImageLayoutsManager.instance == null)
		{
			ImageLayoutsManager.instance = new ImageLayoutsManager();
		}
		return ImageLayoutsManager.instance;
	}

	// Token: 0x06000288 RID: 648 RVA: 0x000091F8 File Offset: 0x000075F8
	public override void DestroyAllLayout()
	{
		foreach (KeyValuePair<string, BaseLayout> keyValuePair in this.layouts)
		{
			if (keyValuePair.Value != null)
			{
				UnityEngine.Object.DestroyImmediate(keyValuePair.Value.gameObject);
			}
		}
		this.layouts.Clear();
	}

	// Token: 0x06000289 RID: 649 RVA: 0x0000927C File Offset: 0x0000767C
	public void InitCameraLayout()
	{
		if (this.cameraLayout == null)
		{
			this.cameraLayout = GameObject.Find("Main Camera").GetComponent<CameraLayout>();
			if (this.cameraLayout == null)
			{
				this.cameraLayout = GameObject.Find("Main Camera").AddComponent<CameraLayout>();
			}
		}
	}

	// Token: 0x0600028A RID: 650 RVA: 0x000092D5 File Offset: 0x000076D5
	public void RemoveLayout(string name)
	{
		UnityEngine.Object.Destroy(this.layouts[name].gameObject);
		this.layouts.Remove(name);
		this.Zbuff++;
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00009308 File Offset: 0x00007708
	public override bool checkAllLayoutIsWaiting()
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			if (baseLayout.GetStatus() == LayoutStatus.ANIMATION)
			{
				return false;
			}
		}
		return this.cameraLayout.GetStatus() != LayoutStatus.ANIMATION;
	}

	// Token: 0x0600028C RID: 652 RVA: 0x0000938C File Offset: 0x0000778C
	public override void UpdateAllLayout()
	{
		base.UpdateAllLayout();
		this.cameraLayout.UpdateLayout();
	}

	// Token: 0x0600028D RID: 653 RVA: 0x0000939F File Offset: 0x0000779F
	public override void FinishAllLayout()
	{
		base.FinishAllLayout();
		if (this.cameraLayout != null)
		{
			this.cameraLayout.FinishAction();
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x000093C3 File Offset: 0x000077C3
	public bool ContainsLayout(string name)
	{
		return this.layouts.ContainsKey(name);
	}

	// Token: 0x0600028F RID: 655 RVA: 0x000093D4 File Offset: 0x000077D4
	public BaseLayout getLayoutByName(string name, string shader = "default")
	{
		BaseLayout baseLayout;
		if (this.layouts.ContainsKey(name))
		{
			baseLayout = this.layouts[name];
		}
		else
		{
			baseLayout = this.createLayout(name, shader, "null");
			this.layouts.Add(name, baseLayout);
		}
		return baseLayout;
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00009420 File Offset: 0x00007820
	public BaseLayout createLayout(string name, string shader = null, string source = "null")
	{
		GameObject gameObject = new GameObject();
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = Singleton<CGManager>.Instance.GetSpriteByName(source);
		spriteRenderer.material = MaterialManager.GetInstance().GetMaterialByName(shader);
		Layout layout = gameObject.AddComponent<Layout>();
		layout.shader = shader;
		gameObject.name = name;
		gameObject.transform.position = new Vector3(0f, 0f, (float)(--this.Zbuff));
		gameObject.transform.parent = this.GetLayouts().transform;
		return layout;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000094B4 File Offset: 0x000078B4
	public BaseLayout createLayout(SaveLayoutItem item)
	{
		BaseLayout baseLayout = this.createLayout(item.id, item.shader, item.source);
		baseLayout.SetAplha(item.aplha);
		baseLayout.gameObject.SetActive(item.isActive);
		baseLayout.gameObject.transform.position = new Vector3(item.x, item.y, item.z);
		baseLayout.gameObject.transform.eulerAngles = new Vector3(0f, 0f, item.angle);
		baseLayout.gameObject.transform.localScale = new Vector3(item.sx, item.sy, 1f);
		return baseLayout;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x0000956C File Offset: 0x0000796C
	public GameObject GetLayouts()
	{
		if (this.layoutGroup != null)
		{
			return this.layoutGroup;
		}
		this.layoutGroup = GameObject.Find("layouts");
		if (this.layoutGroup != null)
		{
			return this.layoutGroup;
		}
		this.layoutGroup = new GameObject("layouts");
		return this.layoutGroup;
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000095CF File Offset: 0x000079CF
	public void resetZbuff()
	{
		this.Zbuff = 10;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x000095DC File Offset: 0x000079DC
	public void ConfigLayouts(SaveData data)
	{
		foreach (SaveLayoutItem saveLayoutItem in data.items)
		{
			this.layouts.Add(saveLayoutItem.id, this.createLayout(saveLayoutItem));
		}
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0000964C File Offset: 0x00007A4C
	public override void ResetAllLayout()
	{
		this.resetZbuff();
		this.InitCameraLayout();
	}

	// Token: 0x06000296 RID: 662 RVA: 0x0000965A File Offset: 0x00007A5A
	public override void LoadSaveData(SaveData data)
	{
		this.ConfigLayouts(data);
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00009663 File Offset: 0x00007A63
	public void AddImageLayout(BaseLayout temp)
	{
		temp.transform.SetParent(this.layoutGroup.transform, false);
		this.layouts.Add(temp.name, temp);
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0000968E File Offset: 0x00007A8E
	public void AddLightLayout(BaseLayout temp)
	{
		this.layouts.Add(temp.name, temp);
	}

	// Token: 0x06000299 RID: 665 RVA: 0x000096A2 File Offset: 0x00007AA2
	public void RemoveLightLayout(string name)
	{
		this.layouts.Remove(name);
	}

	// Token: 0x0600029A RID: 666 RVA: 0x000096B4 File Offset: 0x00007AB4
	public void UpdataAllActBg()
	{
		foreach (BaseLayout baseLayout in this.layouts.Values)
		{
			baseLayout.UpdateActBg();
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00009714 File Offset: 0x00007B14
	public void ChangeName(string test, string id)
	{
		if (this.layouts.ContainsKey(test))
		{
			BaseLayout baseLayout = this.layouts[test];
			this.layouts.Remove(test);
			baseLayout.name = id;
			this.layouts.Add(id, baseLayout);
		}
	}

	// Token: 0x040001BA RID: 442
	private static ImageLayoutsManager instance;

	// Token: 0x040001BB RID: 443
	private CameraLayout cameraLayout;

	// Token: 0x040001BC RID: 444
	public GameObject layoutGroup;

	// Token: 0x040001BD RID: 445
	public int Zbuff = 10;
}
