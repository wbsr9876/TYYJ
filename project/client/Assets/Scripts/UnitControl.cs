using UnityEngine;
using System.Collections;
using GameBase;
using ConfigData;

public class UnitControl: MonoBehaviour {

	public int unitIndex;
	private Grid pos;
	private Grids grids = null;
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

	private int moveRange = 2;

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
			grids = main.GetComponent<GridsControl>().SceneGrids;
			DataUnitProperties data =  (DataUnitProperties)main.GetComponent<ConfigLoader>().UnitPropertiesMap[unitIndex];
			moveRange = data.move_range;
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
}
