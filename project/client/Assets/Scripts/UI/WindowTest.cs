using UnityEngine;
using System.Collections;

public class WindowTest : MonoBehaviour {

	public Texture iconTexture;
	private Rect WindowRect = new Rect(10,60,300,50);
	private bool WindowShowOrNot  = false;

	void Start()
	{
		WindowShowOrNot = true;
	}
	void OnGUI () 
	{
		WindowShowOrNot = GUI.Toggle (new Rect (10, 10, 100, 20), WindowShowOrNot, "显示窗口");
		if(WindowShowOrNot)
		WindowRect = GUI.Window (0, WindowRect, TestFunction, "TestWindow","horizontalslider");
	}

	void TestFunction(int id)
	{
		if (GUI.Button(new Rect(10,20,100,20),"WindowButton"))

			Debug.Log ("1");
		if(iconTexture)
		{

			if(GUI.Button(new Rect(120,10,iconTexture.width,iconTexture.height),iconTexture))
			{
				GameObject.FindWithTag("Player").GetComponent<UnitControl>().Property.UseSkill(0);
			}
		}

		GUI.DragWindow (new Rect (0, 0, 10000, 10000));
	}
}
