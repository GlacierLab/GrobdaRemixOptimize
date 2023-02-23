using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
[ExecuteInEditMode]
[AddComponentMenu("Camera/ScreenWaterDropEffect")]
public class ScreenWaterDropEffect : MonoBehaviour
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x0000208F File Offset: 0x0000048F
	private Material material
	{
		get
		{
			if (this.CurMaterial == null)
			{
				this.CurMaterial = new Material(this.CurShader);
				this.CurMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.CurMaterial;
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020C8 File Offset: 0x000004C8
	private void Start()
	{
		ScreenWaterDropEffect.ChangeDistortion = this.Distortion;
		ScreenWaterDropEffect.ChangeSizeX = this.SizeX;
		ScreenWaterDropEffect.ChangeSizeY = this.SizeY;
		ScreenWaterDropEffect.ChangeDropSpeed = this.DropSpeed;
		this.ScreenWaterDropTex = Resources.Load("ScreenWaterDrop") as Texture2D;
		this.CurShader = Shader.Find("Camera/ScreenWaterDropEffect");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002138 File Offset: 0x00000538
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.CurShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_CurTime", this.TimeX);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_SizeX", this.SizeX);
			this.material.SetFloat("_SizeY", this.SizeY);
			this.material.SetFloat("_DropSpeed", this.DropSpeed);
			this.material.SetTexture("_ScreenWaterDropTex", this.ScreenWaterDropTex);
			Graphics.Blit(sourceTexture, destTexture, this.material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002220 File Offset: 0x00000620
	private void OnValidate()
	{
		ScreenWaterDropEffect.ChangeDistortion = this.Distortion;
		ScreenWaterDropEffect.ChangeSizeX = this.SizeX;
		ScreenWaterDropEffect.ChangeSizeY = this.SizeY;
		ScreenWaterDropEffect.ChangeDropSpeed = this.DropSpeed;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000224E File Offset: 0x0000064E
	private void Update()
	{
		if (Application.isPlaying)
		{
			this.Distortion = ScreenWaterDropEffect.ChangeDistortion;
			this.SizeX = ScreenWaterDropEffect.ChangeSizeX;
			this.SizeY = ScreenWaterDropEffect.ChangeSizeY;
			this.DropSpeed = ScreenWaterDropEffect.ChangeDropSpeed;
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002286 File Offset: 0x00000686
	private void OnDisable()
	{
		if (this.CurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.CurMaterial);
		}
	}

	// Token: 0x04000001 RID: 1
	public Shader CurShader;

	// Token: 0x04000002 RID: 2
	private Material CurMaterial;

	// Token: 0x04000003 RID: 3
	private float TimeX = 1f;

	// Token: 0x04000004 RID: 4
	private Texture2D ScreenWaterDropTex;

	// Token: 0x04000005 RID: 5
	[Range(5f, 64f)]
	[Tooltip("溶解度")]
	public float Distortion = 8f;

	// Token: 0x04000006 RID: 6
	[Range(0f, 7f)]
	[Tooltip("水滴在X坐标上的尺寸")]
	public float SizeX = 1f;

	// Token: 0x04000007 RID: 7
	[Range(0f, 7f)]
	[Tooltip("水滴在Y坐标上的尺寸")]
	public float SizeY = 0.5f;

	// Token: 0x04000008 RID: 8
	[Range(0f, 10f)]
	[Tooltip("水滴的流动速度")]
	public float DropSpeed = 3.6f;

	// Token: 0x04000009 RID: 9
	public static float ChangeDistortion;

	// Token: 0x0400000A RID: 10
	public static float ChangeSizeX;

	// Token: 0x0400000B RID: 11
	public static float ChangeSizeY;

	// Token: 0x0400000C RID: 12
	public static float ChangeDropSpeed;
}
