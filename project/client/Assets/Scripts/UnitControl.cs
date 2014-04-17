using UnityEngine;
using System.Collections;
using GameBase;
using ConfigData;
using SkillSystem;

public class UnitControl: MonoBehaviour {

	public int unitIndex;
	private Grids grids = null;
	//prop
	private Grid pos;
	private int moveRange = 2;
	private int maxHp;
	private int hp;
	private Hashtable skillSocket = new Hashtable();

	public Grid Pos 
	{
		get 
		{
			return pos;
		}
		set 
		{
			if(pos != null)
			{
				pos.Inner = null;
			}
			pos = value;
			pos.Inner = gameObject;
		}
	}
	
	public int MoveRange 
	{
		get 
		{
			return moveRange;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		GameObject main = GameObject.FindWithTag("Main");
		if(main != null)
		{
			grids = GridsManager.Singleton.SceneGrids;
			DataUnitProperties data =  (DataUnitProperties)ConfigDataManager.Singleton.UnitPropertiesMap[unitIndex];
			//test
			skillSocket.Add("NormalAttack",SkillFactory.Singleton.Create(1));
		}
		SetPos(transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void SetPos(Vector3 posVector)
	{
		Pos = grids.GetGrid(posVector);
	}
	public bool CanMoveTo(Grid target)
	{
		return (Mathf.Abs(target.PosX - pos.PosX) + Mathf.Abs(target.PosY - pos.PosY) <= moveRange) && (target.Inner == null);
	}
	public bool MoveTo(Grid target)
	{
		if(!CanMoveTo(target))
		{
			return false;
		}
		Pos = target;
		return true;

	}
	public bool UseSkill(int index)
	{
		if (index >= skillSocket.Count) 
		{
			return false;
		}

		// do skill
		return true;
	}
}
