﻿using ExBuddy.Offsets;

namespace ExBuddy.Helpers
{
	using System;
	using System.Linq;

	using ExBuddy.OrderBotTags.Behaviors.Objects;

	using ff14bot;

	public static class Memory
	{
		public static class Bait
		{
			public static uint SelectedBaitItemId
			{
				get
				{
					return Core.Memory.Read<uint>(FishingOffsets.SelectedBaitItemIdPtr);
				}
			}
		}

		public static class Gathering
		{
			public static byte Chain
			{
				get
				{
					return Core.Memory.Read<byte>(GatheringOffsets.GatheringBasePtr + GatheringOffsets.Chain);
				}
			}

		    

            public static byte HqChain
			{
				get
				{
					return Core.Memory.Read<byte>(GatheringOffsets.GatheringBasePtr + GatheringOffsets.HqChain);
				}
			}
		}

		public static class Request
		{
			public static uint ItemId1
			{
				get
				{
					return Core.Memory.NoCacheRead<uint>(RequestOffsets.ItemBasePtr);
				}
			}

			public static uint ItemId2
			{
				get
				{
					return Core.Memory.NoCacheRead<uint>(RequestOffsets.ItemBasePtr + RequestOffsets.Item2Offset);
				}
			}

			public static uint ItemId3
			{
				get
				{
					return Core.Memory.NoCacheRead<uint>(RequestOffsets.ItemBasePtr + RequestOffsets.Item3Offset);
				}
			}

			public static uint[] ItemsToTurnIn
			{
				get
				{
					return new[] { ItemId1, ItemId2, ItemId3 }.Where(i => i > 0).ToArray();
				}
			}
		}

		public static class Scrips
		{

			public static int BlueCrafter
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr);
				}
			}

			public static int BlueGatherer
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.BlueGatherer);
				}
			}

			public static int RedCrafter
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.RedCrafter);
				}
			}

			public static int RedGatherer
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.RedGatherer);
				}
			}

			public static int CenturioSeals
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.CenturioSeals);
				}
			}

			public static int WeeklyRedCrafter
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.WeeklyRedCrafter);
				}
			}

			public static int WeeklyRedGatherer
			{
				get
				{
					return Core.Memory.Read<int>(ScripsOffsets.BasePtr + ScripsOffsets.WeeklyRedGatherer);
				}
			}

			public static int GetRemainingScripsByShopType(ShopType shopType)
			{
				switch (shopType)
				{
					case ShopType.BlueCrafter:
						return BlueCrafter;
					case ShopType.RedCrafter:
						return RedCrafter;
					case ShopType.BlueGatherer:
						return BlueGatherer;
					case ShopType.RedGatherer:
						return RedGatherer;
				}

				return 0;
			}
		}
	}
}