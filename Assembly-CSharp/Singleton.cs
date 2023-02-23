using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060004B0 RID: 1200 RVA: 0x00006C34 File Offset: 0x00005034
	public static T Instance
	{
		get
		{
			if (Singleton<T>.applicationIsQuitting)
			{
				Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit. Won't create again - returning null.");
				return (T)((object)null);
			}
			object @lock = Singleton<T>._lock;
			T instance;
			lock (@lock)
			{
				if (Singleton<T>._instance == null)
				{
					Singleton<T>._instance = (T)((object)UnityEngine.Object.FindObjectOfType(typeof(T)));
					if (UnityEngine.Object.FindObjectsOfType(typeof(T)).Length > 1)
					{
						Debug.LogError("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopening the scene might fix it.");
						return Singleton<T>._instance;
					}
					if (Singleton<T>._instance == null)
					{
						GameObject gameObject = new GameObject();
						Singleton<T>._instance = gameObject.AddComponent<T>();
						gameObject.name = "(singleton) " + typeof(T).ToString();
						UnityEngine.Object.DontDestroyOnLoad(gameObject);
						Debug.Log(string.Concat(new object[]
						{
							"[Singleton] An instance of ",
							typeof(T),
							" is needed in the scene, so '",
							gameObject,
							"' was created with DontDestroyOnLoad."
						}));
					}
					else
					{
						Debug.Log("[Singleton] Using instance already created: " + Singleton<T>._instance.gameObject.name);
					}
				}
				instance = Singleton<T>._instance;
			}
			return instance;
		}
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00006DB4 File Offset: 0x000051B4
	public void OnDestroy()
	{
		Singleton<T>.applicationIsQuitting = true;
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x00006DBC File Offset: 0x000051BC
	public virtual void InitResource()
	{
	}

	// Token: 0x040002C0 RID: 704
	private static T _instance;

	// Token: 0x040002C1 RID: 705
	private static object _lock = new object();

	// Token: 0x040002C2 RID: 706
	private static bool applicationIsQuitting = false;
}
