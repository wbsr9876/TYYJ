using UnityEngine;
using System.Collections;

public class WindowTest : MonoBehaviour {

	private Rect WindowRect = new Rect(10,60,120,50);
	private bool WindowShowOrNot  = true;

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

		GUI.DragWindow (new Rect (0, 0, 10000, 10000));
	}
}
