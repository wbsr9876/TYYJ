using System;
using UnityEngine;
using ConfigData;
using GameBase;

namespace SkillSystem
{
	public class NormalAttack:Skill
	{
		public NormalAttack (UnitProperty unit,DataSkillInfo skillData)
			:base(unit,skillData)
		{
		}
		public override bool CanUseSkill_imp ()
		{
			Grid targetPos = GridsManager.Singleton.SceneGrids.GetGrid(owner.Pos.PosX + 1,owner.Pos.PosY);
			if(targetPos == null)
			{
				return false;
			}
			if(targetPos.Inner == null)
			{
				return false;
			}

			return true;
		}

        public override bool UseSkill_imp()
		{
			Grid targetPos = GridsManager.Singleton.SceneGrids.GetGrid(owner.Pos.PosX + 1,owner.Pos.PosY);
			
			if(targetPos == null)
			{
                return false;
			}
			
			UnitProperty target = targetPos.Inner;
			if(target == null)
			{
                return false;
			}
			
			int damage = Mathf.Min(owner.Atk - target.Def,target.Hp);
			target.Hp = target.Hp - damage;
			return true;
		}
	}
}
