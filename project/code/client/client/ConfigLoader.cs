using UnityEngine;
using System.Collections;
using ConfigData;

public class ConfigLoader : MonoBehaviour 
{
	private bool loaded = false;
	void Awake()
	{
		loaded = ConfigDataManager.Singleton.Load (Application.streamingAssetsPath);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
