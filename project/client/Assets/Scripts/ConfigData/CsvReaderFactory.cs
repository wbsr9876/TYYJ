using System;
using System.IO;
using System.Runtime.InteropServices;
using LumenWorks.Framework.IO.Csv;
#if UNITY_ANDROID
using UnityEngine;
#endif

namespace ConfigData
{
	public class CsvReaderFactory
	{
		public static CsvReaderFactory Singleton = new CsvReaderFactory();
		public CsvReaderFactory ()
		{
		}

		public CsvReader Create(string filename)
		{
			if(Application.platform == RuntimePlatform.Android)
			{
				WWW www = new WWW(filename);
				while(!www.isDone){}
				CsvReader csv = new CsvReader(new StringReader(www.text),true,'\t','\"','\0','#',ValueTrimmingOptions.All);
				return csv;
			}
			else
			{
				CsvReader csv = new CsvReader(new StreamReader(filename),true,'\t','\"','\0','#',ValueTrimmingOptions.All);
				return csv;
			}

		}
	}
}

