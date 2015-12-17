
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
			return new VirtualCurrency[]{VIRTUAL_MONEY_PROFILE_0
										/*VIRTUAL_MONEY_PROFILE_1,
										VIRTUAL_MONEY_PROFILE_2,
										VIRTUAL_MONEY_PROFILE_3,
										VIRTUAL_MONEY_PROFILE_4,
										VIRTUAL_MONEY_PROFILE_5,
										VIRTUAL_MONEY_PROFILE_6,
										VIRTUAL_MONEY_PROFILE_7,
										VIRTUAL_MONEY_PROFILE_8,
										VIRTUAL_MONEY_PROFILE_9*/
										
			};
		}

		public const string VIRTUAL_MONEY_PROFILE_0_ID    	= prefix+"virtual_money_p0";
		/*public const string VIRTUAL_MONEY_PROFILE_1_ID      = prefix+"virtual_money_p1";
		public const string VIRTUAL_MONEY_PROFILE_2_ID      = prefix+"virtual_money_p2";
		public const string VIRTUAL_MONEY_PROFILE_3_ID      = prefix+"virtual_money_p3";
		public const string VIRTUAL_MONEY_PROFILE_4_ID      = prefix+"virtual_money_p4";
		public const string VIRTUAL_MONEY_PROFILE_5_ID      = prefix+"virtual_money_p5";
		public const string VIRTUAL_MONEY_PROFILE_6_ID      = prefix+"virtual_money_p6";
		public const string VIRTUAL_MONEY_PROFILE_7_ID      = prefix+"virtual_money_p7";
		public const string VIRTUAL_MONEY_PROFILE_8_ID      = prefix+"virtual_money_p8";
		public const string VIRTUAL_MONEY_PROFILE_9_ID      = prefix+"virtual_money_p9";*/


		const string virtual_money_name = "Coins";
		const string virtual_money_description = "";

		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_0 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_0_ID						// item id
			);
	/*	
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_1 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_1_ID						// item id
			);
		
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_2 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_2_ID						// item id
			);
		
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_3 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_3_ID						// item id
			);

		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_4 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_4_ID						// item id
			);

		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_5 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_5_ID						// item id
			);

		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_6 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_6_ID						// item id
			);
		
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_7 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_7_ID						// item id
			);
		
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_8 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_8_ID						// item id
			);
		
		public static VirtualCurrency VIRTUAL_MONEY_PROFILE_9 = new VirtualCurrency(
			virtual_money_name,								// name
			virtual_money_description,						// description
			VIRTUAL_MONEY_PROFILE_9_ID						// item id
			);
		
		*/
		
		
		//if you don't need this, leave it empty, BUT NOT delete it!
		public VirtualCurrencyPack[] GetCurrencyPacks()//buy virtual money with real money
		{
			return new VirtualCurrencyPack[]{VIRTUAL_MONEY_PROFILE_0_PACK_1000,VIRTUAL_MONEY_PROFILE_0_PACK_2500,VIRTUAL_MONEY_PROFILE_0_PACK_6000,VIRTUAL_MONEY_PROFILE_0_PACK_12000,VIRTUAL_MONEY_PROFILE_0_PACK_24000,VIRTUAL_MONEY_PROFILE_0_PACK_48000
				/*VIRTUAL_MONEY_PROFILE_1_PACK_1000,VIRTUAL_MONEY_PROFILE_1_PACK_2500,VIRTUAL_MONEY_PROFILE_1_PACK_6000,VIRTUAL_MONEY_PROFILE_1_PACK_12000,VIRTUAL_MONEY_PROFILE_1_PACK_24000,VIRTUAL_MONEY_PROFILE_1_PACK_48000,
				VIRTUAL_MONEY_PROFILE_2_PACK_1000,VIRTUAL_MONEY_PROFILE_2_PACK_2500,VIRTUAL_MONEY_PROFILE_2_PACK_6000,VIRTUAL_MONEY_PROFILE_2_PACK_12000,VIRTUAL_MONEY_PROFILE_2_PACK_24000,VIRTUAL_MONEY_PROFILE_2_PACK_48000,
				VIRTUAL_MONEY_PROFILE_3_PACK_1000,VIRTUAL_MONEY_PROFILE_3_PACK_2500,VIRTUAL_MONEY_PROFILE_3_PACK_6000,VIRTUAL_MONEY_PROFILE_3_PACK_12000,VIRTUAL_MONEY_PROFILE_3_PACK_24000,VIRTUAL_MONEY_PROFILE_3_PACK_48000,
				VIRTUAL_MONEY_PROFILE_4_PACK_1000,VIRTUAL_MONEY_PROFILE_4_PACK_2500,VIRTUAL_MONEY_PROFILE_4_PACK_6000,VIRTUAL_MONEY_PROFILE_4_PACK_12000,VIRTUAL_MONEY_PROFILE_4_PACK_24000,VIRTUAL_MONEY_PROFILE_4_PACK_48000,
				VIRTUAL_MONEY_PROFILE_5_PACK_1000,VIRTUAL_MONEY_PROFILE_5_PACK_2500,VIRTUAL_MONEY_PROFILE_5_PACK_6000,VIRTUAL_MONEY_PROFILE_5_PACK_12000,VIRTUAL_MONEY_PROFILE_5_PACK_24000,VIRTUAL_MONEY_PROFILE_5_PACK_48000,
				VIRTUAL_MONEY_PROFILE_6_PACK_1000,VIRTUAL_MONEY_PROFILE_6_PACK_2500,VIRTUAL_MONEY_PROFILE_6_PACK_6000,VIRTUAL_MONEY_PROFILE_6_PACK_12000,VIRTUAL_MONEY_PROFILE_6_PACK_24000,VIRTUAL_MONEY_PROFILE_6_PACK_48000,
				VIRTUAL_MONEY_PROFILE_7_PACK_1000,VIRTUAL_MONEY_PROFILE_7_PACK_2500,VIRTUAL_MONEY_PROFILE_7_PACK_6000,VIRTUAL_MONEY_PROFILE_7_PACK_12000,VIRTUAL_MONEY_PROFILE_7_PACK_24000,VIRTUAL_MONEY_PROFILE_7_PACK_48000,
				VIRTUAL_MONEY_PROFILE_8_PACK_1000,VIRTUAL_MONEY_PROFILE_8_PACK_2500,VIRTUAL_MONEY_PROFILE_8_PACK_6000,VIRTUAL_MONEY_PROFILE_8_PACK_12000,VIRTUAL_MONEY_PROFILE_8_PACK_24000,VIRTUAL_MONEY_PROFILE_8_PACK_48000,
				VIRTUAL_MONEY_PROFILE_9_PACK_1000,VIRTUAL_MONEY_PROFILE_9_PACK_2500,VIRTUAL_MONEY_PROFILE_9_PACK_6000,VIRTUAL_MONEY_PROFILE_9_PACK_12000,VIRTUAL_MONEY_PROFILE_9_PACK_24000,VIRTUAL_MONEY_PROFILE_9_PACK_48000*/
											
											};
		}

		const string pack1000_name = "Coins";
		const string pack1000_description = "1000 coins to unlock items.";
		const int pack1000_quantity = 1000;
		const double pack1000_cost = 0.99;

		const string pack2500_name = "coin pack";
		const string pack2500_description = "2500 coins! saving of 10%";
		const int pack2500_quantity = 2500;
		const double pack2500_cost = 2.99;

		const string pack6000_name = "big coin pack";
		const string pack6000_description = "6000 coins! big saving of 20%";
		const int pack6000_quantity = 50;
		const double pack6000_cost = 5.99;

		const string pack12000_name = "huge coin pack";
		const string pack12000_description = "12000 coins! huge saving of 30% ";
		const int pack12000_quantity = 50;
		const double pack12000_cost = 9.99;

		const string pack24000_name = "Rich coin pack";
		const string pack24000_description = "24000 coins! huge saving of 40%";
		const int pack24000_quantity = 50;
		const double pack24000_cost = 14.99;

		const string pack48000_name = "big coin pack";
		const string pack48000_description = "48000 coins! huge saving of 50%";
		const int pack48000_quantity = 50;
		const double pack48000_cost = 20.99;

		//profile 0
	/*	public const string VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID      = prefix+"virtual_money_p0_pack_1000";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID      = prefix+"virtual_money_p0_pack_2500";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID      = prefix+"virtual_money_p0_pack_6000";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID      = prefix+"virtual_money_p0_pack_12000";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID      = prefix+"virtual_money_p0_pack_24000";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID      = prefix+"virtual_money_p0_pack_48000";
		
		*/
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID      = "coins";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID      = "coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_6000_ID      = "big_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_12000_ID      = "huge_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_24000_ID      = "rich_coin_pack";
		public const string VIRTUAL_MONEY_PROFILE_0_PACK_48000_ID      = "millionaire_coin_pack";

		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_1000 = new VirtualCurrencyPack(
			pack1000_name,                                   	// name
			pack1000_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID,                     // item id
			pack1000_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_1000_ID, pack1000_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_0_PACK_2500 = new VirtualCurrencyPack(
			pack2500_name,                                   	// name
			pack2500_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID,                     // item id
			pack2500_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_0_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_0_PACK_2500_ID, pack2500_cost)
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
		/*
		//profile 1
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_1000_ID      = prefix+"virtual_money_p1_pack_1000";
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_2500_ID      = prefix+"virtual_money_p1_pack_2500";
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_6000_ID      = prefix+"virtual_money_p1_pack_6000";
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_12000_ID      = prefix+"virtual_money_p1_pack_12000";
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_24000_ID      = prefix+"virtual_money_p1_pack_24000";
		public const string VIRTUAL_MONEY_PROFILE_1_PACK_48000_ID      = prefix+"virtual_money_p1_pack_48000";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_1_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 	// description
			VIRTUAL_MONEY_PROFILE_1_PACK_10_ID,             // item id
			pack10_quantity,								// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_1_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_1_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_1_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 	// description
			VIRTUAL_MONEY_PROFILE_1_PACK_20_ID,             // item id
			pack20_quantity,								// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_1_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_1_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_1_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 	// description
			VIRTUAL_MONEY_PROFILE_1_PACK_50_ID,             // item id
			pack50_quantity,								// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_1_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_1_PACK_50_ID, pack50_cost)
			);
		//profile 2
		public const string VIRTUAL_MONEY_PROFILE_2_PACK_10_ID      = prefix+"virtual_money_p2_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_2_PACK_20_ID      = prefix+"virtual_money_p2_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_2_PACK_50_ID      = prefix+"virtual_money_p2_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_2_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_2_PACK_10_ID,                     // item id
			pack10_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_2_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_2_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_2_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_2_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_2_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_2_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_2_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_2_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_2_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_2_PACK_50_ID, pack50_cost)
			);
		//profile 3
		public const string VIRTUAL_MONEY_PROFILE_3_PACK_10_ID      = prefix+"virtual_money_p3_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_3_PACK_20_ID      = prefix+"virtual_money_p3_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_3_PACK_50_ID      = prefix+"virtual_money_p3_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_3_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_3_PACK_10_ID,                     // item id
			pack10_quantity,											// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_3_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_3_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_3_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_3_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_3_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_3_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_3_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_3_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_3_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_3_PACK_50_ID, pack50_cost)
			);
		//profile 4
		public const string VIRTUAL_MONEY_PROFILE_4_PACK_10_ID      = prefix+"virtual_money_p4_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_4_PACK_20_ID      = prefix+"virtual_money_p4_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_4_PACK_50_ID      = prefix+"virtual_money_p4_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_4_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_4_PACK_10_ID,                     // item id
			pack10_quantity,											// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_4_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_4_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_4_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_4_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_4_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_4_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_4_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_4_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_4_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_4_PACK_50_ID, pack50_cost)
			);
		//profile 5
		public const string VIRTUAL_MONEY_PROFILE_5_PACK_10_ID      = prefix+"virtual_money_p5_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_5_PACK_20_ID      = prefix+"virtual_money_p5_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_5_PACK_50_ID      = prefix+"virtual_money_p5_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_5_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                     	 		// description
			VIRTUAL_MONEY_PROFILE_5_PACK_10_ID,                     // item id
			pack10_quantity,											// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_5_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_5_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_5_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_5_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_5_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_5_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_5_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_5_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_5_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_5_PACK_50_ID, pack50_cost)
			);
		//profile 6
		public const string VIRTUAL_MONEY_PROFILE_6_PACK_10_ID      = prefix+"virtual_money_p6_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_6_PACK_20_ID      = prefix+"virtual_money_p6_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_6_PACK_50_ID      = prefix+"virtual_money_p6_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_6_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_6_PACK_10_ID,                     // item id
			pack10_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_6_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_6_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_6_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_6_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_6_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_6_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_6_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_6_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_6_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_6_PACK_50_ID, pack50_cost)
			);
		//profile 7
		public const string VIRTUAL_MONEY_PROFILE_7_PACK_10_ID      = prefix+"virtual_money_p7_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_7_PACK_20_ID      = prefix+"virtual_money_p7_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_7_PACK_50_ID      = prefix+"virtual_money_p7_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_7_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                   	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_7_PACK_10_ID,                     // item id
			pack10_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_7_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_7_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_7_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_7_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_7_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_7_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_7_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_7_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_7_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_7_PACK_50_ID, pack50_cost)
			);
		//profile 8
		public const string VIRTUAL_MONEY_PROFILE_8_PACK_10_ID      = prefix+"virtual_money_p8_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_8_PACK_20_ID      = prefix+"virtual_money_p8_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_8_PACK_50_ID      = prefix+"virtual_money_p8_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_8_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                 	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_8_PACK_10_ID,                     // item id
			pack10_quantity,											// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_8_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_8_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_8_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_8_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_8_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_8_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_8_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_8_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_8_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_8_PACK_50_ID, pack50_cost)
			);
		//profile 9
		public const string VIRTUAL_MONEY_PROFILE_9_PACK_10_ID      = prefix+"virtual_money_p9_pack_10";
		public const string VIRTUAL_MONEY_PROFILE_9_PACK_20_ID      = prefix+"virtual_money_p9_pack_20";
		public const string VIRTUAL_MONEY_PROFILE_9_PACK_50_ID      = prefix+"virtual_money_p9_pack_50";
		
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_9_PACK_10 = new VirtualCurrencyPack(
			pack10_name,                                 	// name
			pack10_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_9_PACK_10_ID,                     // item id
			pack10_quantity,											// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_9_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_9_PACK_10_ID, pack10_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_9_PACK_20 = new VirtualCurrencyPack(
			pack20_name,                                   	// name
			pack20_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_9_PACK_20_ID,                     // item id
			pack20_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_9_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_9_PACK_20_ID, pack20_cost)
			);
		public static VirtualCurrencyPack VIRTUAL_MONEY_PROFILE_9_PACK_50 = new VirtualCurrencyPack(
			pack50_name,                                   	// name
			pack50_description,                      	 		// description
			VIRTUAL_MONEY_PROFILE_9_PACK_50_ID,                     // item id
			pack50_quantity,												// number of currencies in the pack
			VIRTUAL_MONEY_PROFILE_9_ID,            			// the currency associated with this pack
			new PurchaseWithMarket(VIRTUAL_MONEY_PROFILE_9_PACK_50_ID, pack50_cost)
			);
		*/

		public static VirtualGood NO_ADS = new LifetimeVG(
			"No Ads", 														// name
			"No More Ads!",				 									// description
			"no_ads",														// item id
			new PurchaseWithMarket("no_ads", 1.99));	// the way this virtual good is purchased

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
			"healthx5",                                        		// item id
			new PurchaseWithVirtualItem(CURRENCY_ID, 1300));

		public static VirtualGood bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Bike",                                                   // Name
			"cross Bike",             // Description
			"bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 350)   // Purchase type
			);
		public static VirtualGood bike = new EquippableVG(
			EquippableVG.EquippingModel.CATEGORY,                       // Equipping model
			"Bike",                                                   // Name
			"cross Bike",             // Description
			"bike",                                              // Item ID
			new PurchaseWithVirtualItem(CURRENCY_ID, 350)   // Purchase type
			);
		#endregion
		
		//if you don't need this, leave it empty, BUT NOT delete it!
		public VirtualGood[] GetGoods()//consumable items
		{
			return new VirtualGood[]{};//buy one item
		}


		
		//if you don't need this, leave it empty, BUT NOT delete it!
		public VirtualCategory[] GetCategories()
		{
			return new VirtualCategory[]{};
		}
		
		//if you don't need this, leave it empty, BUT NOT delete it!
		public LifetimeVG[] GetNotConsumableItems()//
		{
			return new LifetimeVG[]{};//NO_ADS_NONCONS
		}

		
		public UpgradeVG[] GetIncrementalItems()
		{
			return new UpgradeVG[]{};
		}
		
		
		
	}
}
