using System;
namespace GameBase
{
	public class Timer:IComparable
	{
		public delegate void OnTimeHandle();
		public event OnTimeHandle timerEvent;
		private float absTime;
		public Timer (float time,OnTimeHandle newEvent)
		{
			timerEvent += newEvent;
			absTime = time;
		}

		public virtual bool OnTime()
		{
			if (timerEvent != null) 
			{
				timerEvent();
			}
			return false;
		}

		public void Stop()
		{
			timerEvent = null;
		}
		public int CompareTo (object obj)
		{
			if (absTime > ((Timer)obj).absTime) 
			{
				return 1;
			}
			else if (absTime < ((Timer)obj).absTime)
			{
				return -1;
			}
			return 0;
			
		}
	}
}

