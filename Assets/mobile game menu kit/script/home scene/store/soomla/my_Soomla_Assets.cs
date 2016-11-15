
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store
{
	public class my_Soomla_Assets : IStoreAssets{
		
		public int GetVersion()
		{
			return 1;
		}
		
		#region virtual currency


		public const string prefix = "unity.zombiecross";

		public const string CURRENCY_ID      = "Coins";

		//if you don't need this, leave it empty, BUT NOT delete it!
		public  VirtualCurrency[] GetCurrencies()//virtual money
		{
			return new VirtualCurrency[]{VIRTUAL_MONEY_PROFILE_0};
		}

		public const string VIRTUAL_MONEY_PROFILE_0_ID    	= CURRENCY_ID;


		const string virtual_money_name = "Coins";
		const string virtual_money_description = "";

		public const string TEST_ID = "android.test.purchased";

		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_0 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_0_ID						// item id
			);

		
		//if you don't need this, leave it empty, BUT NOT delete it!
		public VirtualCurrencyPack[] GetCurrencyPacks()//buy virtual money with real money
		{
			return new VirtualCurrencyPack[]{VIRTUAL_MONEY_PROFILE_0_PACK_1000,VIRTUAL_MONEY_PROFILE_0_PACK_2500,VIRTUAL_MONEY_PROFILE_0_PACK_6000,VIRTUAL_MONEY_PROFILE_0_PACK_12000,VIRTUAL_MONEY_PROFILE_0_PACK_24000,VIRTUAL_MONEY_PROFILE_0_PACK_48000};
		}

		const string pack1000_name = "coins";
		const string pack1000_description = "1000 coins to unlock items.";
		const int pack1000_quantity = 1000;
		const double pack1000_cost = 1.99;

		const string pack2500_name = "coin pack";
		const string pack2500_description = "2500 coins! saving of 10%";
		const int pack2500_quantity = 2500;
		const double pack2500_cost = 2.99;

		const string pack6000_name = "big coin pack";
		const string pack6000_description = "6000 coins! big saving of 20%";
		const int pack6000_quantity = 6000;
		const double pack6000_cost = 5.99;

		const string pack12000_name = "huge coin pack";
		const string pack12000_description = "12000 coins! huge saving of 30%";
		const int pack12000_quantity = 12000;
		const double pack12000_cost = 9.99;

		const string pack24000_name = "rich coin pack";
		const string pack24000_description = "24000 coins! huge saving of 40%";
		const int pack24000_quantity = 24000;
		const double pack24000_cost = 14.99;

		const string pack48000_name = "millionaire coin pack";
		const string pack48000_description = "48000 coins! huge saving of 50%";
		const int pack48000_quantity = 48000;
		const double pack48000_cost = 20.99;


		public const string VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID      = "coins";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID      = "coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID      = "big_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID      = "huge_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID      = "rich_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID      = "millionaire_coin_pack";

		public const string VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID_TEST      = "android.test.purchased";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID_TEST      = "android.test.purchased";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID_TEST      = "android.test.purchased";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID_TEST      = "android.test.purchased";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID_TEST      = "android.test.purchased";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID_TEST      = "android.test.purchased";

	

		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_1000 = new VirtualCurrencyPack(
			pack1000_name,                                   	// name
			pack1000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID,                     // item id
			pack1000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID, pack1000_cost)
			//new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID_TEST, pack1000_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_2500 = new VirtualCurrencyPack(
			pack2500_name,                                   	// name
			pack2500_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID,                     // item id
			pack2500_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID, pack2500_cost)
			//new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID_TEST, pack2500_cost)			
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_6000 = new VirtualCurrencyPack(
			pack6000_name,                                   	// name
			pack6000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID,                     // item id
			pack6000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID, pack6000_cost)
			);

		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_12000 = new VirtualCurrencyPack(
			pack12000_name,                                   	// name
			pack12000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID,                     // item id
			pack12000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID, pack12000_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_24000 = new VirtualCurrencyPack(
			pack24000_name,                                   	// name
			pack24000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID,                     // item id
			pack24000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID, pack24000_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_48000 = new VirtualCurrencyPack(
			pack48000_name,                                   	// name
			pack48000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID,                     // item id
			pack48000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID, pack48000_cost)
			);

		public static VirtualGood NO_ADS = new LifetimeVG(
			"No Ads", 														// name
			"No More Ads!",				 									// description
			"no_ads",														// item id
			new PurchaseWithMarket("no_ads", 1.99));// the way this virtual good is purchased
		/*
		public static NotConsumableItem NO_ADS = new NotConsumableItem(
			"No Ads", 														// name
			"No More Ads!",				 									// description
			"no_ads",														// item id
			new PurchaseWithMarket("no_ads", 1.99));// the way this virtual good is purchased
		*/

		public static VirtualGood token = new SingleUseVG(
			"Continue Token",                                        		// name
			"1 Continue",   	// description
			"token",                                        		// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 50));

		public static VirtualGood health = new SingleUseVG(
			"health",                                        		// name
			"A pack of 5 lives",   	// description
			"health",                                        		// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 500));  // the way this virtual good is purchased

		public static VirtualGood healthx2 = new SingleUseVG(
			"healthx2",                                        		// name
			"A pack of 10 lives",   	// description
			"healthx2",                                        		// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 800));  // the way this virtual good is purchased

		public static VirtualGood healthx3 = new SingleUseVG(
			"healthx3",                                        		// name
			"A pack of 15 lives",   	// description
			"healthx3",                                        		// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 1300));

		public static VirtualGood bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Bike",                                                   // Name
			"Motocross Bike",             // Description
			"bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 0)   // Purchase type
			);
		public static VirtualGood super_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Bike",                                                   // Name
			"More special Bike",             // Description
			"super_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 1000)   // Purchase type
			);

		public static VirtualGood party_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Party Bike",                                                   // Name
			"Go to the Party in your Bike",             // Description
			"party_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 2000)   // Purchase type
			);
		public static VirtualGood nightmare_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Nightmare Bike",                                                   // Name
			"Scare all zombies",             // Description
			"nightmare_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 3000)   // Purchase type
			);
		public static VirtualGood monster_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Monster Bike",                                                   // Name
			"Strong and good kill",             // Description
			"monster_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 5500)   // Purchase type
			);
		public static VirtualGood neon_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Neon Bike",                                                   // Name
			"Lighting everywhere",             // Description
			"neon_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 8900)   // Purchase type
			);
		public static VirtualGood hell_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Hell Bike",                                                   // Name
			"Go to the Hell",             // Description
			"hell_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 10700)   // Purchase type
			);


		public static VirtualGood blue_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Blue Bike",                                                   // Name
			"",             // Description
			"blue_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 300)   // Purchase type
			);

		public static VirtualGood peace_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Peace Bike",                                                   // Name
			"",             // Description
			"peace_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 300)   // Purchase type
			);
		public static VirtualGood summer_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Summer Bike",                                                   // Name
			"",             // Description
			"summer_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 300)   // Purchase type
			);
		public static VirtualGood sunshine_bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Sunshine Bike",                                                   // Name
			"",             // Description
			"sunshine_bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 300)   // Purchase type
			);

		public static VirtualGood bike_upgrade = new LifetimeVG(
			"Upgrade Bike", 														// name
			"gain a speed, acc, brake boost at bike. next upgrade: 10 points",				 									// description
			"bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood super_bike_upgrade = new LifetimeVG(
			"Upgrade Super", 														// name
			"gain a speed, acc, brake boost at super super bike. next upgrade: 10 points",				 									// description
			"super_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood party_bike_upgrade = new LifetimeVG(
			"Upgrade Party", 														// name
			"gain a speed, acc, brake boost at party bike. next upgrade: 10 points",				 									// description
			"party_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood nightmare_bike_upgrade = new LifetimeVG(
			"Upgrade Nightmare", 														// name
			"gain a speed, acc, brake boost at nightmare bike. next upgrade: 10 points",				 									// description
			"nightmare_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood monster_bike_upgrade = new LifetimeVG(
			"Upgrade Monster", 														// name
			"gain a speed, acc, brake boost at monster bike. next upgrade: 10 points",				 									// description
			"monster_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood neon_bike_upgrade = new LifetimeVG(
			"Upgrade Neon", 														// name
			"gain a speed, acc, brake boost at neon bike. next upgrade: 10 points",				 									// description
			"neon_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));
		public static VirtualGood hell_bike_upgrade = new LifetimeVG(
			"Upgrade Hell", 														// name
			"gain a speed, acc, brake boost at hell bike. next upgrade: 10 points",				 									// description
			"hell_bike_upgrade",														// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 100));



		public static VirtualGood super_bike_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Super Bike Effect",                                                   // Name
			"set good lights",             // Description
			"super_bike_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 2000)   // Purchase type
			);
		public static VirtualGood party_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Party Effect",                                                   // Name
			"set special moments",             // Description
			"party_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 4000)   // Purchase type
			);
		public static VirtualGood nightmare_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Nightmare Effect",                                                   // Name
			"set death in your bike",             // Description
			"nightmare_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 6000)   // Purchase type
			);
		public static VirtualGood monster_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Monster Effect",                                                   // Name
			"set vomit zombie",             // Description
			"monster_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 6800)   // Purchase type
			);
		public static VirtualGood neon_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Neon Effect",                                                   // Name
			"set Light neon",             // Description
			"neon_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 11000)   // Purchase type
			);
		public static VirtualGood hell_effect = new EquippableVG(
			EquippableVG.EquippingModel.LOCAL,                       // Equipping model
			"Hell Effect",                                                   // Name
			"set fire to go hell",             // Description
			"hell_effect",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 21400)   // Purchase type
			);



		
		// Create 2 UpgradeVGs that represent 2 levels for the Strength attribute.
		public static VirtualGood bike_upgrade_level_1 = new UpgradeVG(
			"bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"bike_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade Level 1",                                 // Name
			"",       // Description
			"bike_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood bike_upgrade_level_2 = new UpgradeVG(
			"bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"bike_upgrade_level_3",         // Item ID of the next upgrade good
			"bike_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade Level 2",                                 // Name
			"",     // Description
			"bike_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood bike_upgrade_level_3 = new UpgradeVG(
			"bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"bike_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade Level 3",                                 // Name
			"",     // Description
			"bike_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);


		public static VirtualGood super_upgrade_level_1 = new UpgradeVG(
			"super_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"super_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade Super Level 1",                                 // Name
			"",       // Description
			"super_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood super_upgrade_level_2 = new UpgradeVG(
			"super_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"bike_upgrade_level_3",         // Item ID of the next upgrade good
			"bike_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade Super Level 2",                                 // Name
			"",     // Description
			"bike_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood super_upgrade_level_3 = new UpgradeVG(
			"super_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"super_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade Super Level 3",                                 // Name
			"",     // Description
			"super_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);

		public static VirtualGood party_upgrade_level_1 = new UpgradeVG(
			"party_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"party_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade party Level 1",                                 // Name
			"",       // Description
			"party_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood party_upgrade_level_2 = new UpgradeVG(
			"party_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"party_upgrade_level_3",         // Item ID of the next upgrade good
			"party_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade party Level 2",                                 // Name
			"",     // Description
			"party_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood party_upgrade_level_3 = new UpgradeVG(
			"party_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"party_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade party Level 3",                                 // Name
			"",     // Description
			"party_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);

		public static VirtualGood nightmare_upgrade_level_1 = new UpgradeVG(
			"nightmare_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"nightmare_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade nightmare Level 1",                                 // Name
			"",       // Description
			"nightmare_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood nightmare_upgrade_level_2 = new UpgradeVG(
			"nightmare_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"nightmare_upgrade_level_3",         // Item ID of the next upgrade good
			"nightmare_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade nightmare Level 2",                                 // Name
			"",     // Description
			"nightmare_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood nightmare_upgrade_level_3 = new UpgradeVG(
			"nightmare_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"nightmare_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade nightmare Level 3",                                 // Name
			"",     // Description
			"nightmare_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 1)   // Purchase type
			);

		public static VirtualGood monster_upgrade_level_1 = new UpgradeVG(
			"monster_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"monster_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade monster Level 1",                                 // Name
			"",       // Description
			"monster_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood monster_upgrade_level_2 = new UpgradeVG(
			"monster_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"monster_upgrade_level_3",         // Item ID of the next upgrade good
			"monster_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade monster Level 2",                                 // Name
			"",     // Description
			"monster_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood monster_upgrade_level_3 = new UpgradeVG(
			"monster_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"monster_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade monster Level 3",                                 // Name
			"",     // Description
			"monster_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);

		public static VirtualGood neon_upgrade_level_1 = new UpgradeVG(
			"neon_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"neon_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade neon Level 1",                                 // Name
			"",       // Description
			"neon_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood neon_upgrade_level_2 = new UpgradeVG(
			"neon_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"neon_upgrade_level_3",         // Item ID of the next upgrade good
			"neon_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade neon Level 2",                                 // Name
			"",     // Description
			"neon_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood neon_upgrade_level_3 = new UpgradeVG(
			"neon_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"neon_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade neon Level 3",                                 // Name
			"",     // Description
			"neon_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);

		public static VirtualGood hell_upgrade_level_1 = new UpgradeVG(
			"hell_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"hell_upgrade_level_2",         // Item ID of the next upgrade good
			null,                         // Item ID of the previous upgrade good
			"Upgrade hell Level 1",                                 // Name
			"",       // Description
			"hell_upgrade_level_1",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)    // Purchase type
			);
		
		public static VirtualGood hell_upgrade_level_2 = new UpgradeVG(
			"hell_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			"hell_upgrade_level_3",         // Item ID of the next upgrade good
			"hell_upgrade_level_1",         // Item ID of the previous upgrade good
			"Upgrade hell Level 2",                                 // Name
			"",     // Description
			"hell_upgrade_level_2",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);
		public static VirtualGood hell_upgrade_level_3 = new UpgradeVG(
			"hell_bike_upgrade",                   // Item ID of the associated good that is being upgraded
			null,         // Item ID of the next upgrade good
			"hell_upgrade_level_2",         // Item ID of the previous upgrade good
			"Upgrade hell Level 3",                                 // Name
			"",     // Description
			"hell_upgrade_level_3",                                       // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 100)   // Purchase type
			);



		#endregion
		
		//if you don't need this, leave it empty, BUT NOT delete it!


		public VirtualGood[] GetGoods() {
			return new VirtualGood[] {NO_ADS,health, healthx2,healthx3,hell_bike_upgrade,monster_bike_upgrade,neon_bike_upgrade,monster_bike_upgrade,nightmare_bike_upgrade,party_bike_upgrade,super_bike_upgrade,bike_upgrade_level_1,bike_upgrade_level_2,bike_upgrade_level_3,super_upgrade_level_1,super_upgrade_level_2,super_upgrade_level_3,party_upgrade_level_1,party_upgrade_level_2,party_upgrade_level_3,nightmare_upgrade_level_1,nightmare_upgrade_level_2,nightmare_upgrade_level_3,monster_upgrade_level_1,monster_upgrade_level_2,monster_upgrade_level_3,neon_upgrade_level_1,neon_upgrade_level_2,neon_upgrade_level_3,hell_upgrade_level_1,hell_upgrade_level_2,hell_upgrade_level_3};
			//return new VirtualGood[] {};
		}

		//if you don't need this, leave it empty, BUT NOT delete it!

		public LifetimeVG[] GetNotConsumableItems()//
		{
			return new LifetimeVG[]{};//NO_ADS_NONCONS
		}
		/*
		public NotConsumableItem[] GetNotConsumableItems()//
		{
			return new NotConsumableItem[]{NO_ADS};//NO_ADS_NONCONS
		}
		*/

		public UpgradeVG[] GetIncrementalItems()
		{
			return new UpgradeVG[]{};
		}

		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{GENERAL_CATEGORY};
		}

		public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory(
			"General", new List<string>(new string[] { "bike", "super_bike", "party_bike", "nightmare_bike","monster_bike","neon_bike","hell_bike","blue_bike","peace_bike","sunshine_bike","summer_bike" })
			//"General", new List<string>(new string[] {})
			);
		
	}
}
