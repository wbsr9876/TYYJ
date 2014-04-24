using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using LumenWorks.Framework.IO.Csv;

namespace ConfigData
{

	public class DataUnitProperties
	{
		public int id;	// 索引数字ID
		public string index_name;	// 索引中文名称
		public int move_range;	// 移动范围
		public int attack;	// 攻击力
		public int defense;	// 防御力
		public int max_hp;	// 血量
		public int[] skill_list;	// 技能表
	};
	
	/* 
	@class UnitProperties 
	@author tool GenCSV
	@date 2014/4/24 11:18:29
	@file ConfigUnitProperties.cs
	@brief 从UnitProperties文件中自动生成的配置类
	*/ 
	public class UnitProperties
	{
		public bool LoadFrom(string filename)
		{
			CsvReader csv = CsvReaderFactory.Singleton.Create (filename);
			int index_id = csv.GetFieldIndex("id");
			
			int index_index_name = csv.GetFieldIndex("index_name");
			
			int index_move_range = csv.GetFieldIndex("move_range");
			
			int index_attack = csv.GetFieldIndex("attack");
			
			int index_defense = csv.GetFieldIndex("defense");
			
			int index_max_hp = csv.GetFieldIndex("max_hp");
			
			int index_skill_list = csv.GetFieldIndex("skill_list");
			
			
			IDataReader read = csv;
			read.Read();
			read.Read();
			read.Read();
			while(read.Read())
			{
				DataUnitProperties conf = new DataUnitProperties();
				conf.id = read.GetInt32(index_id);
				conf.index_name = read.GetString(index_index_name);
				conf.move_range = read.GetInt32(index_move_range);
				conf.attack = read.GetInt32(index_attack);
				conf.defense = read.GetInt32(index_defense);
				conf.max_hp = read.GetInt32(index_max_hp);
				{
					string __tmp = read.GetString(index_skill_list);
					string[] stringList = __tmp.Split(new char [] {','});
					conf.skill_list = new int[stringList.Length];
					for(int i = 0; i < stringList.Length; ++i)
						conf.skill_list[i] = int.Parse(stringList[i]);
				}
			m_vtConfigures.Add(conf);
			}
			read.Close();
			return true;
		}
		public DataUnitProperties Get(int row)
		{
			return m_vtConfigures[row];
		}
		public int Count()
		{
			return m_vtConfigures.Count;
		}
		private List<DataUnitProperties> m_vtConfigures = new List<DataUnitProperties>();
	};
}

