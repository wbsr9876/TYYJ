using UnityEngine;
using System.Collections;
using GameBase;
using ConfigData;
using SkillSystem;

public class UnitControl: MonoBehaviour {

	public int unitIndex;
	private UnitProperty property;

	public UnitProperty Property 
	{
		get 
		{
			return property;
		}
	}	
	
	// Use this for initialization
	void Start () 
	{
		property = new UnitProperty(gameObject,unitIndex);
		property.SetPos(transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(property != null)
		{
			if (property.Status == UnitProperty.UnitStatus.Dead) 
			{
				property.Pos = null;
				Destroy(gameObject);
			}
		}
	}

	void OnGUI ()
	{

		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		Vector2 screenPos2D = new Vector2(screenPos.x,screenPos.y);
		//print ("s:"+screenPos2D);
		Vector2 guiPos = GUIUtility.ScreenToGUIPoint(screenPos2D);
		//print("g:" + guiPos);
		string hpString = property.Hp.ToString() + "/" + property.MaxHp.ToString();
		GUI.Label(new Rect(guiPos.x - 25,(float)Screen.height - guiPos.y - 75,100,30),hpString);
	}
}
