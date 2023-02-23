using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
public class PointManager : Singleton<PointManager>
{
	// Token: 0x060002BA RID: 698 RVA: 0x00009F1E File Offset: 0x0000831E
	private void Start()
	{
		this.currentMousePosition = Input.mousePosition;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00009F2C File Offset: 0x0000832C
	private void Update()
	{
		if (Singleton<GameConfigManager>.Instance.config.MouseHide)
		{
			switch (this.pointerState)
			{
			case PointManager.PointerState.stateInvisible:
				if (!this.hideOverride && Input.mousePosition != this.currentMousePosition)
				{
					this.pointerState = PointManager.PointerState.stateSetVisible;
				}
				break;
			case PointManager.PointerState.stateVisible:
				if (this.timeOutCounter > 0f)
				{
					this.timeOutCounter -= Time.deltaTime;
				}
				else
				{
					this.pointerState = PointManager.PointerState.stateSetInvisible;
				}
				break;
			case PointManager.PointerState.stateSetInvisible:
				Cursor.visible = false;
				this.currentMousePosition = Input.mousePosition;
				this.pointerState = PointManager.PointerState.stateInvisible;
				break;
			case PointManager.PointerState.stateSetVisible:
				this.timeOutCounter = this.timeOutReset;
				Cursor.visible = true;
				this.pointerState = PointManager.PointerState.stateVisible;
				break;
			}
		}
	}

	// Token: 0x040001C9 RID: 457
	public PointManager.PointerState pointerState = PointManager.PointerState.stateSetInvisible;

	// Token: 0x040001CA RID: 458
	public float timeOutReset = 2f;

	// Token: 0x040001CB RID: 459
	private bool hideOverride;

	// Token: 0x040001CC RID: 460
	private float timeOutCounter;

	// Token: 0x040001CD RID: 461
	private Vector3 currentMousePosition;

	// Token: 0x02000087 RID: 135
	public enum PointerState
	{
		// Token: 0x040001CF RID: 463
		stateInvisible,
		// Token: 0x040001D0 RID: 464
		stateVisible,
		// Token: 0x040001D1 RID: 465
		stateSetInvisible,
		// Token: 0x040001D2 RID: 466
		stateSetVisible
	}
}
