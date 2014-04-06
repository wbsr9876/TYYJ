using System.Collections.Generic;

namespace ConfigData
{

	public class DataCreaturePettyAction
	{
		int id;	// ��������ID
		string index_name;	// ������������
		int type;	// ����(0:����1:����)
		List<string> sequence;	// С������
		List<int> probability;	// ������(������Ч)
	};
	
	/* 
	@class CreaturePettyAction 
	@author tool GenCSV
	@date 2014/4/7 2:52:04
	@file ConfigCreaturePettyAction.cs
	@brief ��CreaturePettyAction�ļ����Զ����ɵ�������
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
