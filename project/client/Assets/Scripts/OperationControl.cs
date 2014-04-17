using UnityEngine;
using System.Collections.Generic;
using GameBase;
using ConfigData;

public class OperationControl : MonoBehaviour {

	public GameObject shader; 
	[HideInInspector]
	private Grids grids;
	private bool dragging = false;
	private UnitControl unit = null;
	private List<GameObject> rangeList = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{	unit = GetComponent<UnitControl>();
		grids = GridsManager.Singleton.SceneGrids;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(dragging)
		{
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = 0;
			transform.position = newPos;
		}
	}

	void OnMouseDown()
	{
		dragging = true;
		ShowRange(unit.Property.MoveRange,shader,Color.green,Color.red);
	}

	void OnMouseUp()
	{
		dragging = false; 
		HideRange();
		if(grids != null)
		{
			//GridsControl gc = m_background.GetComponent<GridsControl>();
			Grid newGrid = grids.GetGrid(transform.position);

			bool bMoved = true;
			if(newGrid == null || !unit.Property.CanMoveTo(newGrid))
			{
				newGrid = unit.Property.Pos;
				bMoved = false;
			}
			//print ("Grids:" + newGrid.PosX + "," + newGrid.PosY);
			Vector3 newPos = new Vector3(newGrid.Rect.center.x,newGrid.Rect.center.y);
			transform.position = newPos;
			if(bMoved)
			{
				unit.Property.MoveTo(newGrid);
			}


			



			//transform.Translate(newPos - transform.position,Space.World);
		}
	}

	private void ShowRange(int range,GameObject tag,Color emptyColor,Color fullColor)
	{
		for (int i = -range; i <= range; i++) 
		{
			for (int j = -range; j <= range; j++) 
			{
				if(i==0 && j==0)
				{
					continue;
				}
				if(Mathf.Abs(i) + Mathf.Abs(j) > range)
				{
					continue;
				}
				Grid pos = grids.GetGrid(unit.Property.Pos.PosX + i,unit.Property.Pos.PosY + j);
				if(pos != null)
				{
					GameObject go = (GameObject)Instantiate(tag,pos.Rect.center,transform.rotation);
					go.GetComponent<SpriteRenderer>().color = (pos.Inner == null?emptyColor:fullColor);
					rangeList.Add(go);
				}
			}	
		}
	}
	private void HideRange()
	{
		foreach(GameObject go in rangeList)
		{
			Destroy(go);
		}
	}
}
