using UnityEngine;
using System.Collections;
using GameBase;

public class GridsControl : MonoBehaviour {

	[HideInInspector]
	public Grids m_grids;

	// Use this for initialization
	void Start () 
	{
		//貌似是局部坐标系的问题，暂时不用这种替代方式，反正最后是要单独创建网格的
		//BoxCollider2D test = this.GetComponent<BoxCollider2D>();
		//Vector2 rectPos = test.center - test.size;
		//m_grids = new Grids(new Rect(rectPos.x,rectPos.y,test.size.x*2,test.size.y*2),9,5);
		m_grids = new Grids(new Rect(-7.85f,-4.65f,12.7f,8.3f),9,5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
