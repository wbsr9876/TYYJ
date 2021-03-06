/*********************************************************************
*
*      Copyright (C) 2004 Andrew Khan
*
* This library is free software; you can redistribute it and/or
* modify it under the terms of the GNU Lesser General Public
* License as published by the Free Software Foundation; either
* version 2.1 of the License, or (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
* Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public
* License along with this library; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
***************************************************************************/

// Port to C# 
// Chris Laforet
// Wachovia, a Wells-Fargo Company
// Feb 2010


using CSharpJExcel.Jxl.Biff;


namespace CSharpJExcel.Jxl
	{
	/**
	 * Container for any additional cell features
	 */
	public class CellFeatures : BaseCellFeatures
		{
		/**
		 * Constructor
		 */
		public CellFeatures()
			: base()
			{
			}

		/**
		 * Copy constructor
		 *
		 * @param cf cell to copy
		 */
		protected CellFeatures(CellFeatures cf)
			: base(cf)
			{
			}

		/**
		 * Accessor for the cell comment
		 *
		 * @return the cell comment, or NULL if this cell doesn't have
		 *         a comment associated with it
		 */
		public override string getComment()
			{
			return base.getComment();
			}

		/**
		 * Gets the data validation list
		 *
		 * @return the data validation list
		 */
		public override string getDataValidationList()
			{
			return base.getDataValidationList();
			}

		/**
		  * Gets the range of cells to which the data validation applies.  If the
		  * validation applies to just this cell, this will be reflected in the 
		  * returned range
		  *
		  * @return the range to which the same validation extends, or NULL if this
		  *         cell doesn't have a validation
		  */
		public override Range getSharedDataValidationRange()
			{
			return base.getSharedDataValidationRange();
			}
		}
	}
