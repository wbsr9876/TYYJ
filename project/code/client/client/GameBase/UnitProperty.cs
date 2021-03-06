using System;
using System.Collections.Generic;
using UnityEngine;
using ConfigData;
using SkillSystem;

namespace GameBase
{
	public class UnitProperty
	{
		//private int unitIndex;
		private GameObject owner;

		public GameObject Owner {
			get {
				return owner;
			}
		}

		private Grid pos;
		private int moveRange = 2;
		private int maxHp;
		public enum UnitStatus
		{
			Live,
			Dead
		}
		private UnitStatus status = UnitStatus.Live;

		public UnitStatus Status {
			get {
				return status;
			}
		}

		public int MaxHp {
			get {
				return maxHp;
			}
		}
		
		private int hp;
		
		public int Hp {
			get {
				return hp;
			}
			set {
				hp = value;
				if(hp <= 0)
				{
					status = UnitStatus.Dead;
				}
			}
		}
		
		private int atk;
		
		public int Atk {
			get {
				return atk;
			}
		}
		
		private int def;
		
		public int Def {
			get {
				return def;
			}
		}
		
		private List<Skill> skillSocket = new List<Skill>();
		
		public Grid Pos 
		{
			get 
			{
				return pos;
			}
			set 
			{
				if(pos != null)
				{
					pos.Inner = null;
				}
				pos = value;
				if(pos != null)
				{
					pos.Inner = this;
				}

			}
		}
		
		public int MoveRange 
		{
			get 
			{
				return moveRange;
			}
		}
		public UnitProperty (GameObject go,int index)
		{
			owner = go;
			//grids = GridsManager.Singleton.SceneGrids;
			DataUnitProperties data =  (DataUnitProperties)ConfigDataManager.Singleton.UnitPropertiesMap[index];
			moveRange = data.move_range;
			maxHp = data.max_hp;
			hp = maxHp;
			atk = data.attack;
			def = data.defense;
			//test
			foreach (int i in data.skill_list) 
			{
				skillSocket.Add(SkillFactory.Singleton.Create(this,i));
			}

		}
		public void InitPos(Vector3 posVector)
		{
			Pos = GridsManager.Singleton.SceneGrids.GetGrid(posVector);
		}
		public bool CanMoveTo(Grid target)
		{
			if (target == null || target.Inner != null) 
			{
				return false;
			}
			return (Mathf.Abs(target.PosX - pos.PosX) + Mathf.Abs(target.PosY - pos.PosY) <= moveRange) && (target.Inner == null);
		}
		public bool MoveTo(Grid target)
		{
			if(!CanMoveTo(target))
			{
				return false;
			}

			Pos = target;
			return true;
			
		}

        public Skill GetSkill(int index)
        {
            if (index >= skillSocket.Count)
            {
                return null;
            }
            return skillSocket[index];
        }
	}
}

