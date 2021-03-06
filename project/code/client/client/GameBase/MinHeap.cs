using System;
using System.Collections.Generic;

namespace GameBase
{
	public class MinHeap<T> where T:IComparable
	{
		public MinHeap ()
		{
		}
		public bool Insert(T value)
		{
			if(nCurrentSize == m_heap.Count)
			{
				m_heap.Add(value);
			}
			else if(nCurrentSize < m_heap.Count)
			{
				m_heap[nCurrentSize] = value;
			}
			FilterUp(nCurrentSize++);
			return true;
		}
		public T RemoveMin()
		{
			T temp = m_heap[0];
			m_heap[0] = m_heap[--nCurrentSize];
			FilterDown(0,nCurrentSize - 1);
			m_heap[nCurrentSize] = default(T);
			return temp;
		}
		public T GetMin()
		{
			return m_heap[0];
		}
		public bool IsEmpty()
		{
			return nCurrentSize == 0;
		}
		private void FilterDown(int nStart,int nEnd)
		{
			int i = nStart;
			int j = 2*i+1;
			T temp = m_heap[i];
			while(j <= nEnd)
			{
				if((j<nEnd)&&(m_heap[j].CompareTo(m_heap[j+1]) > 0))
				{
					j++;
				}
				if(temp.CompareTo(m_heap[j]) > 0)
				{
					m_heap[i] = m_heap[j];
					i = j;
					j = 2*j+1;
				}
				else
				{
					break;
				}
			}
			m_heap[i] = temp;
		}

		private void FilterUp(int nStart)
		{
			int j = nStart;
			int i = (j-1)/2;
			T temp = m_heap[j];
			while(j > 0)
			{
				if(m_heap[i].CompareTo(temp) > 0 )
				{
					m_heap[j] = m_heap[i];
					j = i;
					i = (i-1)/2;
				}
				else
				{
					break;
				}
			}
			m_heap[j] = temp;
		}
		private List<T> m_heap = new List<T>();
		private int nCurrentSize = 0;
	}
}

