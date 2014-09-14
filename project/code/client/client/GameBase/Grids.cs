using System;
using UnityEngine;

namespace GameBase
{

	public class Grids
	{
		private int maxX;
		private int maxY;
		private Rect gridsRect;
		private Vector2 cellSize;
		private Grid[,] gridList;

		public Grids ()
		{
		}

		public Grids(Rect rect,int x,int y)
		{
			maxX = x;
			maxY = y;
			gridsRect = rect;
			cellSize.x = gridsRect.width / x;
			cellSize.y = gridsRect.height / y;
			gridList = new Grid[x,y];
			for (int i = 0; i < maxX; i++) 
			{
				for (int j = 0; j < maxY; j++) 
				{
					gridList[i,j] = new Grid(i,j,GetRect(i,j));
				}
			}
		}

		private Rect GetRect(int x,int y)
		{
			if (x >= maxX || x < 0 || y >= maxY || y < 0) 
			{
				return default(Rect);
			}
			return new Rect (gridsRect.x + cellSize.x * x, gridsRect.y + cellSize.y * y, cellSize.x, cellSize.y);
		}

		public Grid GetGrid(int x,int y)
		{
			if (x >= maxX || x < 0 || y >= maxY || y < 0) 
			{
				return null;
			}
			return gridList[x,y];
		}
		public Grid GetGrid(Vector2 pos)
		{
			int x = GetXIndex(pos.x);
			int y = GetYIndex(pos.y);
			return GetGrid(x,y);
		}

		public int GetXIndex(float x)
		{
			return (int)((x-gridsRect.x) / cellSize.x);
		}

		public int GetYIndex(float y)
		{
			return (int)((y-gridsRect.y) / cellSize.y);
		}
	}
}
