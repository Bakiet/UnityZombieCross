/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla;
using Soomla.Store;


namespace SIS
{
    /// <summary>
    /// implementation of SOOMLA's IStoreAssets interface, which returns the list
    /// of all available virtual products specified in the IAP Settings editor.
    /// No need to modify anything here!
    /// </summary>
    public class IAPStoreAssets : IStoreAssets
    {
        private IAPManager script;
        private List<VirtualCurrency> currencies = new List<VirtualCurrency>();
        private List<VirtualGood> goods = new List<VirtualGood>();
        private List<VirtualCurrencyPack> currencyPacks = new List<VirtualCurrencyPack>();
        private List<VirtualCategory> categories = new List<VirtualCategory>();


        /// <summary>
        /// created by the IAPManager
        /// </summary>
        public IAPStoreAssets(IAPManager script)
        {
            this.script = script;
            Init();
        }


        //set up virtual items
        void Init()
        {
            CreateCurrencies();
            CreateGoods();
            CreateCategories();
        }


        //get currencies from IAPManager
        void CreateCurrencies()
        {
            for (int i = 0; i < script.currency.Count; i++)
            {
                IAPCurrency currency = script.currency[i];
                currencies.Add(new VirtualCurrency(currency.name, "", currency.name));
            }
        }


        //get products from IAPManager
        void CreateGoods()
        {
            //market items
            for (int i = 0; i < script.IAPs.Count; i++)
            {
                for (int j = 0; j < script.IAPs[i].items.Count; j++)
                {
                    IAPObject obj = script.IAPs[i].items[j];
                    if (obj.type == IAPType.VirtualCurrencyPack)
                        currencyPacks.Add(CreateCurrencyPack(obj, true));
                    else
                        goods.Add(CreateGood(obj, true));
                }
            }

            //content items
            for (int i = 0; i < script.IGCs.Count; i++)
            {
                for (int j = 0; j < script.IGCs[i].items.Count; j++)
                {
                    IAPObject obj = script.IGCs[i].items[j];
                    if (obj.type == IAPType.VirtualCurrencyPack)
                        currencyPacks.Add(CreateCurrencyPack(obj, false));
                    else
                        goods.Add(CreateGood(obj, false));
                }
            }
        }


        //each VirtualGood gets created seperately
        VirtualGood CreateGood(IAPObject obj, bool market)
        {
            PurchaseType purchaseType = null;
            if (market)
                purchaseType = new PurchaseWithMarket(obj.GetIdentifier(), 0.00);
            else
                purchaseType = new PurchaseWithVirtualItem(obj.virtualPrice.name, obj.virtualPrice.amount);

            switch (obj.type)
            {
                case IAPType.SingleUseVG:
                    return new SingleUseVG(obj.title, obj.description, obj.id, purchaseType);
                case IAPType.SingleUsePackVG:
                    return new SingleUsePackVG(obj.specific, obj.amount, obj.title, obj.description, obj.id, purchaseType);
                case IAPType.LifetimeVG:
                    return new LifetimeVG(obj.title, obj.description, obj.id, purchaseType);
                case IAPType.EquippableVG:
                    EquippableVG.EquippingModel equipModel = EquippableVG.EquippingModel.LOCAL;
                    if (obj.specific == EquippableVG.EquippingModel.CATEGORY.ToString()) equipModel = EquippableVG.EquippingModel.CATEGORY;
                    else if (obj.specific == EquippableVG.EquippingModel.GLOBAL.ToString()) equipModel = EquippableVG.EquippingModel.GLOBAL;
                    return new EquippableVG(equipModel, obj.title, obj.description, obj.id, purchaseType);
                case IAPType.UpgradeVG:
                    string[] props = obj.specific.Split(';');
                    return new UpgradeVG(props[0], string.IsNullOrEmpty(props[2]) ? null : props[2], string.IsNullOrEmpty(props[1]) ? null : props[1],
                                         obj.title, obj.description, obj.id, purchaseType);
                default: return null;
            }
        }


        //each CurrencyPack gets created seperately
        VirtualCurrencyPack CreateCurrencyPack(IAPObject obj, bool market)
        {
            PurchaseType purchaseType = null;
            if(market)
                purchaseType = new PurchaseWithMarket(obj.GetIdentifier(), 0.00);
            else
                purchaseType = new PurchaseWithVirtualItem(obj.virtualPrice.name, obj.virtualPrice.amount);

            return new VirtualCurrencyPack(obj.title, obj.description, obj.id, obj.amount,
                                           obj.specific, purchaseType);
        }


        //get categories from IAPManager
        void CreateCategories()
        {
            //market items
            for (int i = 0; i < script.IAPs.Count; i++)
            {
                string catName = script.IAPs[i].name;
                List<string> itemList = new List<string>();

                for (int j = 0; j < script.IAPs[i].items.Count; j++)
                    itemList.Add(script.IAPs[i].items[j].id);

                categories.Add(new VirtualCategory(catName, itemList));
            }

            //content items
            for (int i = 0; i < script.IGCs.Count; i++)
            {
                string catName = script.IGCs[i].name;
                List<string> itemList = new List<string>();

                for (int j = 0; j < script.IGCs[i].items.Count; j++)
                    itemList.Add(script.IGCs[i].items[j].id);

                categories.Add(new VirtualCategory(catName, itemList));
            }
        }


        /// <summary>
        /// parent implementations.
        /// </summary>
        public int GetVersion() { return 0; }
        public VirtualCurrency[] GetCurrencies() { return currencies.ToArray(); }
        public VirtualGood[] GetGoods() { return goods.ToArray(); }
        public VirtualCurrencyPack[] GetCurrencyPacks() { return currencyPacks.ToArray(); }
        public VirtualCategory[] GetCategories() { return categories.ToArray(); }
    }
}
