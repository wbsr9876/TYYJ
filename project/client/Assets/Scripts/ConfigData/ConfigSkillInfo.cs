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
		public string index_name;	// 索引名称
	};
	
	/* 
	@class SkillInfo 
	@author tool GenCSV
	@date 2014/4/17 16:13:43
	@file ConfigSkillInfo.cs
	@brief 从SkillInfo文件中自动生成的配置类
	*/ 
	public class SkillInfo
	{
		public bool LoadFrom(string filename)
		{
			CsvReader csv = new CsvReader(new StreamReader(filename),true,'\t','\"','\0','#',ValueTrimmingOptions.All);
			int index_id = csv.GetFieldIndex("id");
			
			int index_index_name = csv.GetFieldIndex("index_name");
			
			
			IDataReader read = csv;
			read.Read();
			read.Read();
			read.Read();
			while(read.Read())
			{
				DataSkillInfo conf = new DataSkillInfo();
				conf.id = read.GetInt32(index_id);
				conf.index_name = read.GetString(index_index_name);
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
