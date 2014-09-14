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
		public override bool CanUseSkill ()
		{
			Grid targetPos = GridsManager.Singleton.SceneGrids.GetGrid(owner.Pos.PosX,owner.Pos.PosY + 1);
			if(targetPos == null)
			{
				return false;
			}
			if(targetPos.Inner == null)
			{
				return false;
			}
			if(coolDown)
			{
				return false;
			}
			return true;
		}
		
		public override bool UseSkill ()
		{
			if(coolDown)
			{
				return false;
			}
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
			
			coolDown = true;
			GameObject.FindWithTag("Main").GetComponent<TimerManager>().SetTimer(data.cool_down,HandleCoolDownFinished);
			//do action then call back do after
			owner.Owner.GetComponent<Animator>().SetTrigger("Shoot");
			int damage = Mathf.Min(owner.Atk - target.Def,target.Hp);
			target.Hp = target.Hp - damage;
			return true;
		}
	}
}