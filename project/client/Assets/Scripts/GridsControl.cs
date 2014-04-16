using UnityEngine;
using System.Collections;
using GameBase;

public class GridsControl : MonoBehaviour {

	[HideInInspector]
	private Grids sceneGrids;

	public Grids SceneGrids 
	{
		get 
		{
			return sceneGrids;
		}
	}

	// Use this for initialization
	void Awake () 
	{
		//貌似是局部坐标系的问题，暂时不用这种替代方式，反正最后是要单独创建网格的
		//BoxCollider2D test = this.GetComponent<BoxCollider2D>();
		//Vector2 rectPos = test.center - test.size;
		//m_grids = new Grids(new Rect(rectPos.x,rectPos.y,test.size.x*2,test.size.y*2),9,5);
		sceneGrids = new Grids(new Rect(-10.1f,-4.8f,12.7f,8.3f),9,5);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
