using System;
using ConfigData;
using GameBase;
using UnityEngine;

namespace SkillSystem
{
	public class Skill:SkillInterface
	{
		protected DataSkillInfo data;
		protected UnitProperty owner;
		protected bool coolDown = false;
        protected float endTime = -1f;
		public Skill(UnitProperty unit,DataSkillInfo skillData)
		{
			owner = unit;
			data = skillData;
		}

		public bool CanUseSkill()
		{
            if (coolDown)
            {
                return false;
            }
			return CanUseSkill_imp();
		}

		public bool UseSkill()
		{
            if (coolDown)
            {
                return false;
            }
            if (!UseSkill_imp()) return false;
            coolDown = true;
            endTime = GameObject.FindWithTag("Main").GetComponent<TimerManager>().SetTimer(data.cool_down, HandleCoolDownFinished);
            //do action then call back do after
            PlayAnimation();
			return true;
		}

        public virtual bool CanUseSkill_imp()
        {
            return false;
        }

        public virtual bool UseSkill_imp()
        {
            return false;
        }

		public void HandleCoolDownFinished()
		{
			coolDown = false;
		}

        protected void PlayAnimation()
        {
            owner.Owner.GetComponent<Animator>().SetTrigger(data.animation_name);
            return;
        }

        public float GetCoolDownRemain()
        {
            if (!coolDown) return 0.0f;
            return endTime - Time.time;
        }
	}
}

