using UnityEngine;
using System.Collections;
using GameBase;
using ConfigData;

public class MoveControl : MonoBehaviour {

	[HideInInspector]
	private bool m_bDragging = false;
	private Vector3 m_oldPos;
	private Grids m_grids = null;
	// Use this for initialization
	void Start () 
	{
		m_grids = GameObject.FindWithTag("background").GetComponent<GridsControl>().m_grids;
		//测试代码开始，教学如何加载配置文件并读取
		CreaturePettyAction conf = new CreaturePettyAction();
		conf.LoadFrom(Application.dataPath + "/Data/ConfigCreaturePettyAction.csv");
		DataCreaturePettyAction test= conf.Get(0);
		print(test.index_name);
		print(test.probability[0]);
		//测试代码结束
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
		print("Down Pos:" + m_oldPos);
		m_bDragging = true;
	}

	void OnMouseUp()
	{
		m_bDragging = false; 
		if(!m_grids.Equals(null))
		{
			//GridsControl gc = m_background.GetComponent<GridsControl>();
			Rect rect = m_grids.GetGrid(transform.position);
			Vector3 newPos;
			if(rect.width < 0.1)
			{
				newPos = m_oldPos;
			}
			else
			{
				newPos = new Vector3(rect.center.x,rect.center.y);
			}
			print("Up Pos:" + m_oldPos);
			transform.Translate(newPos - transform.position,Space.World);
		}
	}
}
