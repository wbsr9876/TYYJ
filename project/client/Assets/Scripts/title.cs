using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0))
						Application.LoadLevel ("test");
	
	}

	void OnGUI()
	{
	
				GUI.Label (new Rect (250, 200, 200, 100), "          Press to Start!");
		}
}
