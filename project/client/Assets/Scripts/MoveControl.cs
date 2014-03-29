using UnityEngine;
using System.Collections;
using GameBase;

public class MoveControl : MonoBehaviour {

	[HideInInspector]
	private bool m_bDragging = false;
	private Vector3 m_oldPos;

	private Grids m_sceneGrids;
	// Use this for initialization
	void Start () 
	{
		GameObject myBackground = GameObject.FindWithTag("background");
		if(myBackground)
		{
			GridsControl gc = myBackground.GetComponent<GridsControl>();
			m_sceneGrids = gc.m_grids;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_bDragging)
		{
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = 0;
			transform.Translate(newPos - transform.position,Space.World);
		}
	}

	void OnMouseDown()
	{
		m_oldPos = transform.position;
		//print("Down Pos:" + m_oldPos);
		m_bDragging = true;
	}

	void OnMouseUp()
	{
		m_bDragging = false;
		Rect rect = m_sceneGrids.GetGrid(transform.position);
		Vector3 newPos;
		if(rect.width < 0.1)
		{
			newPos = m_oldPos;
		}
		else
		{
			newPos = new Vector3(rect.center.x,rect.center.y);
		}
		//print("Up Pos:" + m_oldPos);
		transform.Translate(newPos - transform.position,Space.World);
	}
}
