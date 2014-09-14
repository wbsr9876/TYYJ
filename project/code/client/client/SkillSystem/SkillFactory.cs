using System;
using ConfigData;
using GameBase;

namespace SkillSystem
{
	public class SkillFactory
	{
		public static SkillFactory Singleton = new SkillFactory();
		public SkillFactory ()
		{
		}

		public Skill Create(UnitProperty unit,int id)
		{
			switch (id) 
			{
			case 1:
				return new NormalAttack(unit,(DataSkillInfo)ConfigDataManager.Singleton.SkillInfoMap[id]);
			default:
				break;
			}
			return null;
		}
	}
}

