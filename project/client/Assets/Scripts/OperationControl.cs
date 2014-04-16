using UnityEngine;
using System.Collections.Generic;
using GameBase;
using ConfigData;

public class OperationControl : MonoBehaviour {

	public GameObject shader; 
	[HideInInspector]
	private Grids grids;
	private bool dragging = false;
	private Vector3 oldPos;
	private UnitControl unit = null;
	private List<GameObject> rangeList = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{	unit = GetComponent<UnitControl>();
		grids = GameObject.FindWithTag("background").GetComponent<GridsControl>().SceneGrids;
		/*
		//测试代码开始，教学如何加载配置文件并读取
		CreaturePettyAction conf = new CreaturePettyAction();
		conf.LoadFrom(Application.dataPath + "/Data/ConfigCreaturePettyAction.csv");
		DataCreaturePettyAction test= conf.Get(0);
		print(test.index_name);
		print(test.probability[0]);
		//测试代码结束
		*/
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
		ShowRange(unit.MoveRange,shader,Color.green,Color.red);
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
			if(newGrid == null || !unit.CanMoveTo(newGrid))
			{
				newGrid = unit.Pos;
				bMoved = false;
			}
			print ("Grids:" + newGrid.PosX + "," + newGrid.PosY);
			Vector3 newPos = new Vector3(newGrid.Rect.center.x,newGrid.Rect.center.y);
			transform.position = newPos;
			if(bMoved)
			{
				unit.MoveTo(newGrid);
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
				Grid pos = grids.GetGrid(unit.Pos.PosX + i,unit.Pos.PosY + j);
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
