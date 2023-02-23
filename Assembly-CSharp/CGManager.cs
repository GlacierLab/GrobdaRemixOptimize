using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class CGManager : Singleton<CGManager>
{
	// Token: 0x0600027E RID: 638 RVA: 0x00008DCC File Offset: 0x000071CC
	protected CGManager()
	{
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00008DDF File Offset: 0x000071DF
	public override void InitResource()
	{
		this.LoadResourceFromAb();
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00008DE8 File Offset: 0x000071E8
	public Sprite GetSpriteByName(string name)
	{
		if (name == null)
		{
			return null;
		}
		if (this.spritDict.ContainsKey(name))
		{
			return this.spritDict[name];
		}
		Sprite sprite = this.FindSprite(name);
		if (sprite == null)
		{
			return null;
		}
		this.spritDict.Add(sprite.name, sprite);
		return sprite;
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00008E44 File Offset: 0x00007244
	private Sprite FindSprite(string name)
	{
		if (name == "null")
		{
			return null;
		}
		Sprite sprite = ((!this.imgPatch) ? null : this.imgPatch.LoadAsset<Sprite>(name));
		if (sprite == null)
		{
			sprite = this.background.LoadAsset<Sprite>(name);
		}
		if (sprite == null)
		{
			sprite = this.cg.LoadAsset<Sprite>(name);
			if (sprite != null)
			{
				CGSaveDataManager.GetInstance().SetReadCG(name);
			}
		}
		if (sprite == null)
		{
			sprite = this.mask.LoadAsset<Sprite>(name);
		}
		if (sprite == null)
		{
			sprite = this.sh.LoadAsset<Sprite>(name);
		}
		if (sprite == null)
		{
			Debug.LogError("can't load image：" + name);
		}
		return sprite;
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00008F1E File Offset: 0x0000731E
	public Dictionary<string, Sprite> GetAllKey()
	{
		return this.spritDict;
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00008F28 File Offset: 0x00007328
	private void LoadResourceFromAb()
	{
		string text = Application.dataPath + "/data/background";
		string text2 = Application.dataPath + "/data/cg";
		string text3 = Application.dataPath + "/data/mask";
		string text4 = Application.dataPath + "/data/sh";
		string text5 = ((!File.Exists(Application.dataPath + "/data/imgpatch")) ? null : (Application.dataPath + "/data/imgpatch"));
		this.background = AssetBundle.LoadFromFile(text);
		this.cg = AssetBundle.LoadFromFile(text2);
		this.mask = AssetBundle.LoadFromFile(text3);
		this.sh = AssetBundle.LoadFromFile(text4);
		this.imgPatch = ((text5 == null) ? null : AssetBundle.LoadFromFile(text5));
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00008FEF File Offset: 0x000073EF
	public void UnloadSpriteAsset()
	{
		this.spritDict.Clear();
	}

	// Token: 0x040001B4 RID: 436
	private Dictionary<string, Sprite> spritDict = new Dictionary<string, Sprite>();

	// Token: 0x040001B5 RID: 437
	private AssetBundle background;

	// Token: 0x040001B6 RID: 438
	private AssetBundle cg;

	// Token: 0x040001B7 RID: 439
	private AssetBundle mask;

	// Token: 0x040001B8 RID: 440
	private AssetBundle sh;

	// Token: 0x040001B9 RID: 441
	private AssetBundle imgPatch;
}
