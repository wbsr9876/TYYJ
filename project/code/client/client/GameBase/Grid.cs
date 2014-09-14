using System;
using UnityEngine;

namespace GameBase
{
	public class Grid
	{
		private int posX;

		public int PosX 
		{
			get 
			{
				return posX;
			}
		}

		private int posY;

		public int PosY 
		{
			get 
			{
				return posY;
			}
		}

		private Rect rect;
		private UnitProperty inner;

		public UnitProperty Inner 
		{
			get 
			{
				return inner;
			}
			set 
			{
				inner = value;
			}
		}

		public Rect Rect 
		{
			get 
			{
				return rect;
			}
		}

		public Grid()
		{
		}
		public Grid (int x,int y,Rect gridRect)
		{
			posX = x;
			posY = y;
			rect = gridRect;
		}
	}
}

