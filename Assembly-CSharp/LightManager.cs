using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000083 RID: 131
public class LightManager
{
	// Token: 0x060002A6 RID: 678 RVA: 0x0000985A File Offset: 0x00007C5A
	protected LightManager()
	{
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x0000986D File Offset: 0x00007C6D
	public GameObject CreateLight(CreateLightScript script)
	{
		return this.CreateLight(script.light_kind, script.id, script.angle, script.c, script.p, script.pow, script.range);
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0000989F File Offset: 0x00007C9F
	public static LightManager GetInstance()
	{
		if (LightManager.instance == null)
		{
			LightManager.instance = new LightManager();
		}
		return LightManager.instance;
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x000098BA File Offset: 0x00007CBA
	private GameObject CreateLight(SaveLightItem item)
	{
		return this.CreateLight(item.kind, item.id, item.angle, item.c, item.p, item.pow, item.range);
	}

	// Token: 0x060002AA RID: 682 RVA: 0x000098EC File Offset: 0x00007CEC
	private GameObject CreateLight(string kind, string id, Vector3 angle, Color c, Vector3 p, float pow, float range)
	{
		GameObject gameObject;
		if (kind != null)
		{
			if (kind == "point")
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("prefab/point_light"));
				goto IL_6A;
			}
			if (kind == "direction")
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("prefab/direction_light"));
				goto IL_6A;
			}
		}
		gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("prefab/direction_light"));
		IL_6A:
		LightLayout lightLayout = gameObject.AddComponent<LightLayout>();
		gameObject.name = id;
		gameObject.transform.position = p;
		gameObject.transform.eulerAngles = angle;
		Light component = gameObject.GetComponent<Light>();
		component.color = c;
		component.range = range;
		component.intensity = pow;
		this.lights.Add(id, gameObject);
		ImageLayoutsManager.GetInstance().AddLightLayout(lightLayout);
		return gameObject;
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000099C2 File Offset: 0x00007DC2
	public void DestroyAll()
	{
		this.lights.Clear();
	}

	// Token: 0x060002AC RID: 684 RVA: 0x000099CF File Offset: 0x00007DCF
	public void Destroy(string name)
	{
		if (this.lights.ContainsKey(name))
		{
			UnityEngine.Object.Destroy(this.lights[name]);
			this.lights.Remove(name);
			ImageLayoutsManager.GetInstance().RemoveLightLayout(name);
		}
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00009A0C File Offset: 0x00007E0C
	public void LoadSaveData(SaveData save)
	{
		foreach (SaveLightItem saveLightItem in save.lights)
		{
			this.CreateLight(saveLightItem);
		}
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00009A6C File Offset: 0x00007E6C
	public void CreateSaveData(SaveData save)
	{
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.lights)
		{
			GameObject value = keyValuePair.Value;
			Light component = value.GetComponent<Light>();
			SaveLightItem saveLightItem = new SaveLightItem();
			LightType type = component.type;
			if (type != LightType.Point)
			{
				if (type != LightType.Directional)
				{
					saveLightItem.kind = "direction";
				}
				else
				{
					saveLightItem.kind = "direction";
				}
			}
			else
			{
				saveLightItem.kind = "point";
			}
			saveLightItem.angle = value.transform.eulerAngles;
			saveLightItem.range = component.range;
			saveLightItem.c = component.color;
			saveLightItem.pow = component.intensity;
			saveLightItem.id = value.name;
			saveLightItem.p = value.transform.position;
			save.lights.Add(saveLightItem);
		}
	}

	// Token: 0x040001C1 RID: 449
	private static LightManager instance;

	// Token: 0x040001C2 RID: 450
	private Dictionary<string, GameObject> lights = new Dictionary<string, GameObject>();
}
