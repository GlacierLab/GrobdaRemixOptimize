using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class MovieSaveDataManager : BaseSaveDataManager<MovieSaveData>
{
	// Token: 0x06000324 RID: 804 RVA: 0x0000B43F File Offset: 0x0000983F
	protected MovieSaveDataManager()
	{
		this.filename = Application.dataPath + "/save/movie";
		base.Init();
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0000B462 File Offset: 0x00009862
	public override void InitDict()
	{
		this.saveData.savedata.Add("pv1", false);
		base.Serializer();
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0000B480 File Offset: 0x00009880
	public void SetMovie(string name)
	{
		if (this.saveData.savedata.ContainsKey(name))
		{
			this.saveData.savedata[name] = true;
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0000B4AA File Offset: 0x000098AA
	public bool GetMovieStatus(string name)
	{
		return this.saveData.savedata.ContainsKey(name) && this.saveData.savedata[name];
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0000B4D5 File Offset: 0x000098D5
	public static MovieSaveDataManager GetInstance()
	{
		if (MovieSaveDataManager.instance == null)
		{
			MovieSaveDataManager.instance = new MovieSaveDataManager();
		}
		return MovieSaveDataManager.instance;
	}

	// Token: 0x040001FD RID: 509
	private static MovieSaveDataManager instance;
}
