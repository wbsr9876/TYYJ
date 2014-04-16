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
		public int move_range;	// 类型(0:概率1:序列)
	};
	
	/* 
	@class UnitProperties 
	@author tool GenCSV
	@date 2014/4/17 3:00:57
	@file ConfigUnitProperties.cs
	@brief 从UnitProperties文件中自动生成的配置类
	*/ 
	public class UnitProperties
	{
		public bool LoadFrom(string filename)
		{
			CsvReader csv = new CsvReader(new StreamReader(filename),true,'\t','\"','\0','#',ValueTrimmingOptions.All);
			int index_id = csv.GetFieldIndex("id");
			
			int index_index_name = csv.GetFieldIndex("index_name");
			
			int index_move_range = csv.GetFieldIndex("move_range");
			
			
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

