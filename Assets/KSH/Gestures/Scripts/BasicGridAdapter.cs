using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Other.Extensions;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;

// You should modify the namespace to your own or - if you're sure there won't ever be conflicts - remove it altogether
namespace Kmr.Grids
{
	
	public class BasicGridAdapter : GridAdapter<GridParams, MyGridItemViewsHolder>
	{
		
		public SimpleDataHelper<MainGridItemModel> Data { get; private set; }


		#region GridAdapter implementation
		protected override void Start()
		{
			Data = new SimpleDataHelper<MainGridItemModel>(this);

			
		}

		
		protected override void UpdateCellViewsHolder(MyGridItemViewsHolder newOrRecycled)
		{
			
			MainGridItemModel model = Data[newOrRecycled.ItemIndex];
			newOrRecycled.menuItem.Show(model.listItem);

		}

		
		#endregion

		
		#region data manipulation

		
		#endregion

	}


	// Class containing the data associated with an item
	public class MainGridItemModel
	{
		
		public ListItem listItem;
		
	}


	
	public class MyGridItemViewsHolder : CellViewsHolder
	{
		
		public BasicGridItem menuItem;
		


		// Retrieving the views from the item's root GameObject
		public override void CollectViews()
		{
			base.CollectViews();

			menuItem = root.GetComponent<BasicGridItem>();
			
		}

	}
}
