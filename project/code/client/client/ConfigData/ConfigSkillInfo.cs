﻿using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using LumenWorks.Framework.IO.Csv;

namespace ConfigData
{

	public class DataSkillInfo
	{
		public int id;	// 索引数字ID
		public string index_name;	// 索引中文名称
		public float cool_down;	// 冷却时间
		public string animation_name;	// 动作名称
	};
	
	/* 
	@class SkillInfo 
	@author tool GenCSV
	@date 2014/9/17 1:09:40
	@file ConfigSkillInfo.cs
	@brief 从SkillInfo文件中自动生成的配置类
	*/ 
	public class SkillInfo
	{
		public bool LoadFrom(string filename)
		{
			CsvReader csv = CsvReaderFactory.Singleton.Create (filename);
			int index_id = csv.GetFieldIndex("id");
			
			int index_index_name = csv.GetFieldIndex("index_name");
			
			int index_cool_down = csv.GetFieldIndex("cool_down");
			
			int index_animation_name = csv.GetFieldIndex("animation_name");
			
			
			IDataReader read = csv;
			read.Read();
			read.Read();
			read.Read();
			while(read.Read())
			{
				DataSkillInfo conf = new DataSkillInfo();
				conf.id = read.GetInt32(index_id);
				conf.index_name = read.GetString(index_index_name);
				conf.cool_down = read.GetFloat(index_cool_down);
				conf.animation_name = read.GetString(index_animation_name);
			m_vtConfigures.Add(conf);
			}
			read.Close();
			return true;
		}
		public DataSkillInfo Get(int row)
		{
			return m_vtConfigures[row];
		}
		public int Count()
		{
			return m_vtConfigures.Count;
		}
		private List<DataSkillInfo> m_vtConfigures = new List<DataSkillInfo>();
	};
}

