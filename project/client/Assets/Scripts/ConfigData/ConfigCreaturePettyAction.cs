using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using LumenWorks.Framework.IO.Csv;

namespace ConfigData
{

	public class DataCreaturePettyAction
	{
		public int id;	// 索引数字ID
		public string index_name;	// 索引中文名称
		public int type;	// 类型(0:概率1:序列)
		public string[] sequence;	// 小动作列
		public int[] probability;	// 概率列(概率有效)
	};
	
	/* 
	@class CreaturePettyAction 
	@author tool GenCSV
	@date 2014/4/13 3:19:44
	@file ConfigCreaturePettyAction.cs
	@brief 从CreaturePettyAction文件中自动生成的配置类
	*/ 
	public class CreaturePettyAction
	{
		public bool LoadFrom(string filename)
		{
			CsvReader csv = new CsvReader(new StreamReader(filename),true,'\t','\"','\0','#',ValueTrimmingOptions.All);
			int index_id = csv.GetFieldIndex("id");
			
			int index_index_name = csv.GetFieldIndex("index_name");
			
			int index_type = csv.GetFieldIndex("type");
			
			int index_sequence = csv.GetFieldIndex("sequence");
			
			int index_probability = csv.GetFieldIndex("probability");
			
			
			IDataReader read = csv;
			read.Read();
			read.Read();
			read.Read();
			while(read.Read())
			{
				DataCreaturePettyAction conf = new DataCreaturePettyAction();
				conf.id = read.GetInt32(index_id);
				conf.index_name = read.GetString(index_index_name);
				conf.type = read.GetInt32(index_type);
				{
					string __tmp = read.GetString(index_sequence);
					conf.sequence = __tmp.Split(new char [] {','});
				}
				{
					string __tmp = read.GetString(index_probability);
					string[] stringList = __tmp.Split(new char [] {','});
					conf.probability = new int[stringList.Length];
					for(int i = 0; i < stringList.Length; ++i)
						conf.probability[i] = int.Parse(stringList[i]);
				}
			m_vtConfigures.Add(conf);
			}
			read.Close();
			return true;
		}
		public DataCreaturePettyAction Get(int row)
		{
			return m_vtConfigures[row];
		}
		public int Count()
		{
			return m_vtConfigures.Count;
		}
		private List<DataCreaturePettyAction> m_vtConfigures = new List<DataCreaturePettyAction>();
	};
}

