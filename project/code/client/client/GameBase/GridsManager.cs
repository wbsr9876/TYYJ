using System;
using UnityEngine;
namespace GameBase
{
	public class GridsManager
	{
		public static GridsManager Singleton = new GridsManager();
		private Grids sceneGrids;

		public Grids SceneGrids {
			get {
				return sceneGrids;
			}
		}

		public GridsManager ()
		{
		}

		public void CreateGrids(Rect rect,int x,int y)
		{
			sceneGrids = new Grids(rect,x,y);
		}
	}
}

