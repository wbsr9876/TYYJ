using System;
using System.Collections;
using UnityEngine;

namespace ConfigData
{
	public class ConfigDataManager
	{
		private Hashtable unitPropertiesMap = new Hashtable();

		public Hashtable UnitPropertiesMap {
			get {
				return unitPropertiesMap;
			}
		}

		private Hashtable skillInfoMap = new Hashtable();

		public Hashtable SkillInfoMap {
			get {
				return skillInfoMap;
			}
		}

		public static ConfigDataManager Singleton = new ConfigDataManager();
		public static bool Loaded = false;

		public ConfigDataManager ()
		{
		}
		public bool Load(string path)
		{
			if (Loaded) 
			{
				return false;			
			}

			{
				UnitProperties unitPropertiesConf = new UnitProperties();
				if(unitPropertiesConf.LoadFrom(path + "/Data/ConfigUnitProperties.csv"))
				{
					for (int i = 0; i < unitPropertiesConf.Count(); i++) 
					{
						DataUnitProperties test= unitPropertiesConf.Get(i);
						unitPropertiesMap.Add(test.id,test);
					}
				}
				else
				{
					return false;
				}
			}

			{
				SkillInfo skillInfosConf = new SkillInfo();
				if(skillInfosConf.LoadFrom(path + "/Data/ConfigSkillInfo.csv"))
				{
					for (int i = 0; i < skillInfosConf.Count(); i++) 
					{
						DataSkillInfo test= skillInfosConf.Get(i);
						skillInfoMap.Add(test.id,test);
					}
				}
				else
				{
					return false;
				}
			}
			Loaded = true;
			return Loaded;
		}
	}
}

