using UnityEngine;
using System.Collections;
using ConfigData;

public class ConfigLoader : MonoBehaviour {
		
	void Awake()
	{
		ConfigDataManager.Singleton.Load (Application.dataPath);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
