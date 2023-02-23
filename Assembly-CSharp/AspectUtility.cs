using System;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class AspectUtility : MonoBehaviour
{
	// Token: 0x06000491 RID: 1169 RVA: 0x0000F7D0 File Offset: 0x0000DBD0
	private void Awake()
	{
		AspectUtility._landscapeModeOnly = this.landscapeModeOnly;
		AspectUtility.cam = base.GetComponent<Camera>();
		if (!AspectUtility.cam)
		{
			AspectUtility.cam = Camera.main;
		}
		if (!AspectUtility.cam)
		{
			return;
		}
		AspectUtility.wantedAspectRatio = this._wantedAspectRatio;
		AspectUtility.SetCamera();
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0000F834 File Offset: 0x0000DC34
	public static void SetCamera()
	{
		float num;
		if (Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft)
		{
			num = (float)Screen.width / (float)Screen.height;
		}
		else if (Screen.height > Screen.width && AspectUtility._landscapeModeOnly)
		{
			num = (float)Screen.height / (float)Screen.width;
		}
		else
		{
			num = (float)Screen.width / (float)Screen.height;
		}
		if ((double)Mathf.Abs(num - AspectUtility.wantedAspectRatio) < 0.01)
		{
			AspectUtility.cam.rect = new Rect(0f, 0f, 1f, 1f);
			if (AspectUtility.backgroundCam)
			{
				UnityEngine.Object.Destroy(AspectUtility.backgroundCam.gameObject);
			}
			return;
		}
		if (num > AspectUtility.wantedAspectRatio)
		{
			float num2 = 1f - AspectUtility.wantedAspectRatio / num;
			AspectUtility.cam.rect = new Rect(num2 / 2f, 0f, 1f - num2, 1f);
		}
		else
		{
			float num3 = 1f - num / AspectUtility.wantedAspectRatio;
			AspectUtility.cam.rect = new Rect(0f, num3 / 2f, 1f, 1f - num3);
		}
		if (!AspectUtility.backgroundCam)
		{
			AspectUtility.backgroundCam = new GameObject("BackgroundCam", new Type[] { typeof(Camera) }).GetComponent<Camera>();
			AspectUtility.backgroundCam.depth = -2.14748365E+09f;
			AspectUtility.backgroundCam.clearFlags = CameraClearFlags.Color;
			AspectUtility.backgroundCam.backgroundColor = Color.black;
			AspectUtility.backgroundCam.cullingMask = 0;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000F9EC File Offset: 0x0000DDEC
	public static int screenHeight
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.height);
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000FA14 File Offset: 0x0000DE14
	public static int screenWidth
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.width);
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000FA3C File Offset: 0x0000DE3C
	public static int xOffset
	{
		get
		{
			return (int)((float)Screen.width * AspectUtility.cam.rect.x);
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000FA64 File Offset: 0x0000DE64
	public static int yOffset
	{
		get
		{
			return (int)((float)Screen.height * AspectUtility.cam.rect.y);
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000FA8C File Offset: 0x0000DE8C
	public static Rect screenRect
	{
		get
		{
			return new Rect(AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.width * (float)Screen.width, AspectUtility.cam.rect.height * (float)Screen.height);
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000FB04 File Offset: 0x0000DF04
	public static Vector3 mousePosition
	{
		get
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.y -= (float)((int)(AspectUtility.cam.rect.y * (float)Screen.height));
			mousePosition.x -= (float)((int)(AspectUtility.cam.rect.x * (float)Screen.width));
			return mousePosition;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000FB6C File Offset: 0x0000DF6C
	public static Vector2 guiMousePosition
	{
		get
		{
			Vector2 mousePosition = Event.current.mousePosition;
			mousePosition.y = Mathf.Clamp(mousePosition.y, AspectUtility.cam.rect.y * (float)Screen.height, AspectUtility.cam.rect.y * (float)Screen.height + AspectUtility.cam.rect.height * (float)Screen.height);
			mousePosition.x = Mathf.Clamp(mousePosition.x, AspectUtility.cam.rect.x * (float)Screen.width, AspectUtility.cam.rect.x * (float)Screen.width + AspectUtility.cam.rect.width * (float)Screen.width);
			return mousePosition;
		}
	}

	// Token: 0x040002B7 RID: 695
	public float _wantedAspectRatio = 1.6f;

	// Token: 0x040002B8 RID: 696
	public bool landscapeModeOnly = true;

	// Token: 0x040002B9 RID: 697
	public static bool _landscapeModeOnly = true;

	// Token: 0x040002BA RID: 698
	private static float wantedAspectRatio;

	// Token: 0x040002BB RID: 699
	private static Camera cam;

	// Token: 0x040002BC RID: 700
	private static Camera backgroundCam;
}
