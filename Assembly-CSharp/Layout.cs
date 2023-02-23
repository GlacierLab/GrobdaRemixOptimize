using System;
using UnityEngine;

// Token: 0x02000076 RID: 118
public class Layout : BaseLayout
{
	// Token: 0x06000218 RID: 536 RVA: 0x000076E1 File Offset: 0x00005AE1
	private void Awake()
	{
		this.kind = LayoutKind.Image;
		this.spriteRender = base.gameObject.GetComponent<SpriteRenderer>();
	}

	// Token: 0x06000219 RID: 537 RVA: 0x000076FB File Offset: 0x00005AFB
	public override void SetActBgAction(ActBgAction a)
	{
		this.actBgAction = a;
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00007704 File Offset: 0x00005B04
	public override void UpdateActBg()
	{
		if (this.actBgAction == null)
		{
			return;
		}
		this.actBgActionTime += Time.deltaTime;
		if (this.actBgActionTime < this.actBgAction.script.time)
		{
			this.actBgAction.UpdateGameObject(base.gameObject);
		}
		else
		{
			this.actBgAction.FinishGameObject(base.gameObject);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00007771 File Offset: 0x00005B71
	public override Color GetColor()
	{
		return this.spriteRender.color;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00007780 File Offset: 0x00005B80
	public override void SetAplha(float a)
	{
		this.spriteRender.color = new Color(this.spriteRender.color.r, this.spriteRender.color.g, this.spriteRender.color.b, a);
	}

	// Token: 0x0600021D RID: 541 RVA: 0x000077D7 File Offset: 0x00005BD7
	public override void SetColor(Color c)
	{
		this.spriteRender.color = c;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x000077E5 File Offset: 0x00005BE5
	public override void SetImage(Sprite s)
	{
		this.actBgAction = null;
		this.spriteRender.sprite = s;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000077FA File Offset: 0x00005BFA
	public override void SetImage(string path)
	{
		this.SetImage(Singleton<CGManager>.Instance.GetSpriteByName(path));
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0000780D File Offset: 0x00005C0D
	public override void SetMaterial(Material material)
	{
		this.spriteRender.material = material;
	}

	// Token: 0x06000221 RID: 545 RVA: 0x0000781B File Offset: 0x00005C1B
	public override Sprite GetSprite()
	{
		return this.spriteRender.sprite;
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00007828 File Offset: 0x00005C28
	public override void ConfigSaveData(SaveData data)
	{
		SaveLayoutItem saveLayoutItem = new SaveLayoutItem();
		saveLayoutItem.id = base.name;
		if (this.spriteRender.sprite != null)
		{
			saveLayoutItem.source = this.spriteRender.sprite.name;
		}
		else
		{
			saveLayoutItem.source = "null";
		}
		saveLayoutItem.x = base.transform.position.x;
		saveLayoutItem.y = base.transform.position.y;
		saveLayoutItem.z = base.transform.position.z;
		saveLayoutItem.sx = base.transform.localScale.x;
		saveLayoutItem.sy = base.transform.localScale.y;
		saveLayoutItem.isActive = base.gameObject.activeInHierarchy;
		saveLayoutItem.shader = this.shader;
		saveLayoutItem.angle = base.gameObject.transform.eulerAngles.z;
		saveLayoutItem.aplha = this.spriteRender.color.a;
		data.items.Add(saveLayoutItem);
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00007964 File Offset: 0x00005D64
	public override void SetShaderColor(Color c)
	{
		this.spriteRender.material.color = c;
	}

	// Token: 0x06000224 RID: 548 RVA: 0x00007977 File Offset: 0x00005D77
	public override Color GetShaderColor()
	{
		return this.spriteRender.material.color;
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00007989 File Offset: 0x00005D89
	public override Material GetMaterial()
	{
		return this.spriteRender.material;
	}

	// Token: 0x0400017C RID: 380
	public SpriteRenderer spriteRender;

	// Token: 0x0400017D RID: 381
	[SerializeField]
	private ActBgAction actBgAction;

	// Token: 0x0400017E RID: 382
	[SerializeField]
	private float actBgActionTime;
}
