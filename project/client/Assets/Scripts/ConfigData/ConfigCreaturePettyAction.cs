using System.Collections.Generic;

namespace ConfigData
{

	public class DataCreaturePettyAction
	{
		int id;	// 索引数字ID
		string index_name;	// 索引中文名称
		int type;	// 类型(0:概率1:序列)
		List<string> sequence;	// 小动作列
		List<int> probability;	// 概率列(概率有效)
	};
	
	/* 
	@class CreaturePettyAction 
	@author tool GenCSV
	@date 2014/4/7 2:52:04
	@file ConfigCreaturePettyAction.cs
	@brief 从CreaturePettyAction文件中自动生成的配置类
	*/ 
	public class CreaturePettyAction
	{
		public bool LoadFrom(string filename)
		{
			return false;
		}
		public DataCreaturePettyAction Get(int row)
		{
			return m_vtConfigures[row];
		}
		public int Count()
		{
			return m_vtConfigures.Count();
		}
		private List<DataCreaturePettyAction> m_vtConfigures;
	};
}
