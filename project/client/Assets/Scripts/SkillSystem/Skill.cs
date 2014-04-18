using System;
using ConfigData;
using GameBase;

namespace SkillSystem
{
	public class Skill
	{
		protected DataSkillInfo data;
		protected UnitProperty owner;
		protected bool coolDown = false;
		public Skill(UnitProperty unit,DataSkillInfo skillData)
		{
			owner = unit;
			data = skillData;
		}

		public virtual bool CanUseSkill()
		{
			return false;
		}

		public virtual bool UseSkill()
		{
			return false;
		}

		public void HandleCoolDownFinished()
		{
			coolDown = false;
		}
	}
}

