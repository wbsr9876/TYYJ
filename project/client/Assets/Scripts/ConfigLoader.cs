using UnityEngine;
using System.Collections;
using ConfigData;

public class ConfigLoader : MonoBehaviour {
	
	private Hashtable unitPropertiesMap = new Hashtable();

	public Hashtable UnitPropertiesMap {
		get {
			return unitPropertiesMap;
		}
	}

	void Awake()
	{
		//测试代码开始，教学如何加载配置文件并读取
		UnitProperties conf = new UnitProperties();
		conf.LoadFrom(Application.dataPath + "/Data/ConfigUnitProperties.csv");
		for (int i = 0; i < conf.Count(); i++) 
		{
			DataUnitProperties test= conf.Get(i);
			unitPropertiesMap.Add(test.id,test);
		}
		//测试代码结束
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
