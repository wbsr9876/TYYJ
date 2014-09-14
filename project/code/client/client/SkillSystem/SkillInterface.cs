using System;
namespace SkillSystem
{
	public interface SkillInterface
	{
		bool CanUseSkill ();
				
		bool UseSkill ();
					
		void HandleCoolDownFinished();

	}
}

