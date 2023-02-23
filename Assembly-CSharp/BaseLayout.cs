using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class BaseLayout : MonoBehaviour
{
	// Token: 0x060001F8 RID: 504 RVA: 0x000074A5 File Offset: 0x000058A5
	public LayoutStatus GetStatus()
	{
		return this.status;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x000074AD File Offset: 0x000058AD
	public virtual void SetAction(BaseAction a)
	{
		this.action.Add(a);
		this.status = LayoutStatus.ANIMATION;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x000074C2 File Offset: 0x000058C2
	public virtual void SetActBgAction(ActBgAction a)
	{
	}

	// Token: 0x060001FB RID: 507 RVA: 0x000074C4 File Offset: 0x000058C4
	public void RemoveAction(BaseAction a)
	{
		this.action.Remove(a);
	}

	// Token: 0x060001FC RID: 508 RVA: 0x000074D4 File Offset: 0x000058D4
	protected void ClearAllAction()
	{
		foreach (BaseAction baseAction in this.action)
		{
			baseAction.FinishAction();
		}
		this.action.Clear();
		this.status = LayoutStatus.WAIT;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00007544 File Offset: 0x00005944
	protected void UpdateAllAction()
	{
		foreach (BaseAction baseAction in this.action)
		{
			baseAction.animation();
		}
		this.CheckAllAction();
	}

	// Token: 0x060001FE RID: 510 RVA: 0x000075A8 File Offset: 0x000059A8
	protected void CheckAllAction()
	{
		int i = 0;
		while (i < this.action.Count)
		{
			if (this.action[i].IsFinish())
			{
				this.action.RemoveAt(i);
			}
			else
			{
				i++;
			}
		}
		if (this.action.Count == 0)
		{
			this.status = LayoutStatus.WAIT;
		}
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0000760F File Offset: 0x00005A0F
	public virtual void FinishAction()
	{
		if (this.status == LayoutStatus.ANIMATION)
		{
			this.ClearAllAction();
		}
		this.status = LayoutStatus.WAIT;
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00007629 File Offset: 0x00005A29
	public virtual void UpdateActBg()
	{
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000762C File Offset: 0x00005A2C
	public virtual void UpdateLayout()
	{
		LayoutStatus layoutStatus = this.status;
		if (layoutStatus != LayoutStatus.ANIMATION)
		{
			if (layoutStatus != LayoutStatus.WAIT)
			{
			}
		}
		else
		{
			this.updateAction();
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00007667 File Offset: 0x00005A67
	private void updateAction()
	{
		this.UpdateAllAction();
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000766F File Offset: 0x00005A6F
	public virtual void SetAplha(float a)
	{
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00007674 File Offset: 0x00005A74
	public virtual Color GetColor()
	{
		return default(Color);
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000768A File Offset: 0x00005A8A
	public virtual void SetColor(Color c)
	{
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000768C File Offset: 0x00005A8C
	public virtual Sprite GetSprite()
	{
		return null;
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0000768F File Offset: 0x00005A8F
	public virtual void SetImage(string path)
	{
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00007691 File Offset: 0x00005A91
	public virtual void SetImage(Sprite s)
	{
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00007693 File Offset: 0x00005A93
	public virtual void SetMaterial(Material material)
	{
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00007695 File Offset: 0x00005A95
	public virtual Material GetMaterial()
	{
		return null;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00007698 File Offset: 0x00005A98
	public virtual void SetText(string str)
	{
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000769A File Offset: 0x00005A9A
	public virtual void SetLightPower(float p)
	{
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000769C File Offset: 0x00005A9C
	public virtual void SetLightRange(float p)
	{
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000769E File Offset: 0x00005A9E
	public virtual void AddLightPower(float p)
	{
	}

	// Token: 0x0600020F RID: 527 RVA: 0x000076A0 File Offset: 0x00005AA0
	public virtual void AddLightRange(float p)
	{
	}

	// Token: 0x06000210 RID: 528 RVA: 0x000076A2 File Offset: 0x00005AA2
	public virtual void SetShaderColor(Color c)
	{
	}

	// Token: 0x06000211 RID: 529 RVA: 0x000076A4 File Offset: 0x00005AA4
	public virtual Color GetShaderColor()
	{
		return default(Color);
	}

	// Token: 0x06000212 RID: 530 RVA: 0x000076BA File Offset: 0x00005ABA
	public virtual Light GetLight()
	{
		return null;
	}

	// Token: 0x06000213 RID: 531 RVA: 0x000076BD File Offset: 0x00005ABD
	public void SetStatus(LayoutStatus s)
	{
		this.status = s;
	}

	// Token: 0x06000214 RID: 532 RVA: 0x000076C6 File Offset: 0x00005AC6
	public virtual void ConfigSaveData(SaveData data)
	{
	}

	// Token: 0x04000178 RID: 376
	protected LayoutStatus status = LayoutStatus.WAIT;

	// Token: 0x04000179 RID: 377
	public List<BaseAction> action = new List<BaseAction>();

	// Token: 0x0400017A RID: 378
	public LayoutKind kind = LayoutKind.None;

	// Token: 0x0400017B RID: 379
	public string shader;
}
