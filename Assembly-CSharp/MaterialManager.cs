using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000084 RID: 132
public class MaterialManager
{
	// Token: 0x060002AF RID: 687 RVA: 0x00009B8C File Offset: 0x00007F8C
	protected MaterialManager()
	{
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00009B9F File Offset: 0x00007F9F
	public static MaterialManager GetInstance()
	{
		if (MaterialManager.instance == null)
		{
			MaterialManager.instance = new MaterialManager();
		}
		return MaterialManager.instance;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00009BBC File Offset: 0x00007FBC
	public void InitResource()
	{
		this.materials.Add("diffuse", Resources.Load<Material>("material/sprite_diffuse"));
		this.materials.Add("default", Resources.Load<Material>("material/sprite_default"));
		this.materials.Add("mask_base", Resources.Load<Material>("material/mask"));
		this.materials.Add("mask_cross", Resources.Load<Material>("material/mask_cross"));
		this.materials.Add("sprite_gray", Resources.Load<Material>("material/sprite_gray"));
		this.materials.Add("inverse", Resources.Load<Material>("material/sprite-inverse"));
		this.materials.Add("white", Resources.Load<Material>("material/sprite_white"));
		this.materials.Add("part", Resources.Load<Material>("material/sprite_part"));
		this.materials.Add("part1", Resources.Load<Material>("material/sprite_part_1"));
		this.materials.Add("color", Resources.Load<Material>("material/sprite_color"));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00009CD0 File Offset: 0x000080D0
	public Material GetMaterialByName(string name)
	{
		if (name == null)
		{
			return UnityEngine.Object.Instantiate<Material>(this.materials["default"]);
		}
		if (this.materials.ContainsKey(name))
		{
			return UnityEngine.Object.Instantiate<Material>(this.materials[name]);
		}
		return UnityEngine.Object.Instantiate<Material>(this.materials["default"]);
	}

	// Token: 0x040001C3 RID: 451
	private Dictionary<string, Material> materials = new Dictionary<string, Material>();

	// Token: 0x040001C4 RID: 452
	private static MaterialManager instance;
}
