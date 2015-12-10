/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Soomla;
using Soomla.Store;

namespace SIS
{
    /// <summary>
    /// IAP Settings editor.
    /// The one-stop solution for managing cross-platform IAP data.
    /// Found under Window > Simple IAP System > IAP Settings
    /// </summary>
    public class IAPEditor : EditorWindow
    {
        //shop reference
        [SerializeField]
        ShopManager shop;
        //manager reference
        [SerializeField]
        IAPManager script;
        //prefab object
        [SerializeField]
        private static Object IAPPrefab;
        //window reference
        private static IAPEditor iapEditor;
        //requirement wizard reference
        private static RequirementEditor reqEditor;
        //keep track of switching scenes for reinitialization
        private static string currentScene = "";

        //first toolbar for displaying IAP types
        int toolbar = 0;
        string[] toolbarStrings = new string[] { "In App Purchases", "In Game Content" };
        //available currency names for selection
        string[] currencyNames;

        //inspector scrollbar x/y position for each tab
        Vector2 scrollPosIAP;
        Vector2 scrollPosIGC;


        //add menu named "IAP Settings" to the window menu
        [MenuItem("Window/Simple IAP System/IAP Settings")]
        static void Init()
        {
            //get existing open window or if none, make a new one
            iapEditor = (IAPEditor)EditorWindow.GetWindowWithRect(typeof(IAPEditor), new Rect(0, 0, 1024, 512), false, "IAP Settings");
            //automatically repaint whenever the scene has changed (for caution)
            iapEditor.autoRepaintOnSceneChange = true;
        }


        //when the window gets opened
        void OnEnable()
        {
            //reconnect reference
            if (iapEditor == null) iapEditor = this;

            //get reference to the shop and cache it
            shop = GameObject.FindObjectOfType(typeof(ShopManager)) as ShopManager;

            script = FindIAPManager();

            //could not get prefab, non-existent?
            if (script == null)
                return;

            if (shop)
                RemoveContainerConnections();
        }


        //refresh on new scenes
        void OnHierarchyChange()
        {
            if (string.IsNullOrEmpty(currentScene) || currentScene != EditorApplication.currentScene)
            {
                OnEnable();
                Repaint();
            }
        }


        //locate IAP Manager prefab in the project
        public static IAPManager FindIAPManager()
        {
            GameObject obj = Resources.Load("IAP Manager") as GameObject;

            if (obj != null && PrefabUtility.GetPrefabType(obj) == PrefabType.Prefab)
            {
                //try to get IAP Manager component and return it
                IAPManager iap = obj.GetComponent(typeof(IAPManager)) as IAPManager;
                if (iap != null)
                {
                    IAPPrefab = obj;
                    return iap;
                }
            }

            return null;
        }


        //remove empty IAPGroup references in the scene
        void RemoveContainerConnections()
        {
            //get all container objects from the Shop Manager,
            //then populate a list with all IAPGroups
            List<Container> containers = new List<Container>();
            containers.AddRange(shop.containers);
            List<IAPGroup> allGroups = new List<IAPGroup>();
            allGroups.AddRange(script.IAPs);
            allGroups.AddRange(script.IGCs);

            //loop over lists and compare them
            for (int i = 0; i < containers.Count; i++)
            {
                //if we found an IAPGroup in the Shop Manager component
                //that does not exist anymore, remove it from the scene containers
                IAPGroup g = allGroups.Find(x => x.id == containers[i].id);
                if (g == null)
                {
                    shop.containers.Remove(shop.containers.Find(x => x.id == containers[i].id));
                }
            }
            containers.Clear();
        }


        //close windows and save changes on exit
        void OnDestroy()
        {
            if (reqEditor) reqEditor.Close();
            SavePrefab();
        }


        void OnGUI()
        {
            if (script == null)
            {
                EditorGUILayout.LabelField("Couldn't find an IAP Manager prefab in the project! " +
                                 "Is it located in the Resources folder?");
                return;
            }

            //set the targeted script modified by the GUI for handling undo
            List<Object> objs = new List<Object>() { script };
            if (shop != null) objs.Add(shop);
            Object[] undo = objs.ToArray();
			Undo.RecordObjects(undo, "ChangedSettings");
 
            //display toolbar at the top, followed by a horizontal line
            toolbar = GUILayout.Toolbar(toolbar, toolbarStrings);
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

            //get all currency names
            if (script.currency.Count > 0)
                currencyNames = GetCurrencyNames();

            //handle toolbar selection
            switch (toolbar)
            {
                //first tab selected
                case 0:
                    DrawIAP(script.IAPs);
                    break;
                //second tab selected
                case 1:
                    DrawIGC(script.IGCs);
                    break;
            }

            //track change as well as undo
            TrackChange();
        }


        //draws the in app purchase editor
        void DrawIAP(List<IAPGroup> list)
        {
            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.yellow;

            //draw yellow button for adding a new IAP group
            if (GUILayout.Button("Add new Category"))
            {
                //create new group, give it a generic name based on
                //the current unix time and add it to the list of groups
                IAPGroup newGroup = new IAPGroup();
                string timestamp = GenerateUnixTime();
                newGroup.name = "Grp " + timestamp;
                newGroup.id = timestamp;
                list.Add(newGroup);
                return;
            }

            GUI.backgroundColor = Color.white;
            EditorGUILayout.EndHorizontal();

            //begin a scrolling view inside this tab, pass in current Vector2 scroll position 
            scrollPosIAP = EditorGUILayout.BeginScrollView(scrollPosIAP, GUILayout.Height(462));
            GUILayout.Space(20);

            //loop over IAP groups
            for (int i = 0; i < list.Count; i++)
            {
                //cache group
                IAPGroup group = list[i];
                //populate shop container variables if ShopManager is present
                Container shopGroup = null;
                if (shop)
                {
                    shopGroup = shop.GetContainer(group.id);
                    if (shopGroup == null)
                    {
                        shopGroup = new Container();
                        shopGroup.id = group.id;
                        shop.containers.Add(shopGroup);
                    }
                }

                EditorGUILayout.BeginHorizontal();
                GUI.backgroundColor = Color.yellow;
                //button for adding a new IAPObject (product) to this group
                if (GUILayout.Button("New Object", GUILayout.Width(120)))
                {
                    IAPObject newObj = new IAPObject();
                    //add platform dependent ids to the local list
                    int platforms = System.Enum.GetValues(typeof(IAPPlatform)).Length;
                    for (int j = 0; j < platforms; j++)
                        newObj.localId.Add(new IAPIdentifier());

                    group.items.Add(newObj);
                    break;
                }

                //draw group properties
                GUI.backgroundColor = Color.white;
                EditorGUILayout.LabelField("Category:", GUILayout.Width(60));
                group.name = EditorGUILayout.TextField(group.name, GUILayout.Width(90));
                GUILayout.FlexibleSpace();

                if (!shop)
                    EditorGUILayout.LabelField("No ShopManager prefab found in this scene!", GUILayout.Width(300));
                else
                {
                    EditorGUILayout.LabelField("Prefab:", GUILayout.Width(45));
                    shopGroup.prefab = (GameObject)EditorGUILayout.ObjectField(shopGroup.prefab, typeof(GameObject), false, GUILayout.Width(100));
                    GUILayout.Space(10);
                    EditorGUILayout.LabelField("Parent:", GUILayout.Width(45));
                    shopGroup.parent = (Transform)EditorGUILayout.ObjectField(shopGroup.parent, typeof(Transform), true, GUILayout.Width(100));
                }
                
                GUILayout.FlexibleSpace();

                //button width for up & down buttons. These should always be at the same width,
                //so if there's only one button (e.g. if there's only one group), the width must be extended
                int groupUpWidth = 22;
                int groupDownWidth = 22;
                if (i == 0) groupDownWidth = 48;
                if (i == list.Count - 1) groupUpWidth = 48;

                //draw up & down buttons for re-ordering groups
                //this will simply switch references in the list
                //hotControl and keyboardControl unsets current mouse focus
                if (i > 0 && GUILayout.Button("▲", GUILayout.Width(groupUpWidth)))
                {
                    list[i] = list[i - 1];
                    list[i - 1] = group;
                    EditorGUIUtility.hotControl = 0;
                    EditorGUIUtility.keyboardControl = 0;
                }
                if (i < list.Count - 1 && GUILayout.Button("▼", GUILayout.Width(groupDownWidth)))
                {
                    list[i] = list[i + 1];
                    list[i + 1] = group;
                    EditorGUIUtility.hotControl = 0;
                    EditorGUIUtility.keyboardControl = 0;
                }

                //button for removing a group including items
                GUI.backgroundColor = Color.gray;
                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    if(shop) shop.containers.Remove(shopGroup);
                    list.RemoveAt(i);
                    break;
                }
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
                GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

                //draw header information for each item property
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(58);
                EditorGUILayout.LabelField("ID:", GUILayout.Width(100));
                EditorGUILayout.LabelField("Icon:", GUILayout.Width(65));
                EditorGUILayout.LabelField("Type:", GUILayout.Width(80));
                EditorGUILayout.LabelField("Fetch:", GUILayout.Width(100));
                EditorGUILayout.LabelField("Title:", GUILayout.Width(145));
                if (group.items.Count == 1) GUILayout.Space(50);
                EditorGUILayout.LabelField("Description:", GUILayout.Width(150));
                EditorGUILayout.LabelField("Specific Settings:", GUILayout.Width(135));
                EditorGUILayout.LabelField("Price:", GUILayout.Width(100));
                EditorGUILayout.EndHorizontal();

                //loop over items in this group
                for (int j = 0; j < group.items.Count; j++)
                {
                    //cache item reference
                    IAPObject obj = group.items[j];

                    EditorGUILayout.BeginHorizontal();

                    obj.platformFoldout = EditorGUILayout.Foldout(obj.platformFoldout, "");
                    IAPType selectedType = obj.type;

                    //draw IAPObject (item/product) properties
                    obj.id = EditorGUILayout.TextField(obj.id, GUILayout.Width(100));
                    obj.icon = EditorGUILayout.ObjectField(obj.icon, typeof(Sprite), false, GUILayout.Width(65)) as Sprite;
                    obj.type = (IAPType)EditorGUILayout.EnumPopup(obj.type, GUILayout.Width(90));
                    obj.fetch = EditorGUILayout.Toggle(obj.fetch, GUILayout.Width(20));
                    obj.title = EditorGUILayout.TextField(obj.title);
                    obj.description = EditorGUILayout.TextField(obj.description);

                    if (obj.type != selectedType)
                    {
                        obj.specific = "";
                        obj.amount = 0;
                    }

                    DrawTypeSettings(obj);

                    obj.realPrice = EditorGUILayout.TextField(obj.realPrice, GUILayout.Width(60));

                    //button for adding a requirement to this item
                    if (!string.IsNullOrEmpty(obj.req.entry))
                        GUI.backgroundColor = Color.yellow;
                    if (GUILayout.Button("R", GUILayout.Width(20)))
                    {
                        reqEditor = (RequirementEditor)EditorWindow.GetWindowWithRect(typeof(RequirementEditor), new Rect(0, 0, 300, 150), false, "Requirement");
                        reqEditor.obj = obj;
                    }

                    GUI.backgroundColor = Color.white;
                    //do the same here as with the group up & down buttons
                    //(see above)
                    int buttonUpWidth = 22;
                    int buttonDownWidth = 22;
                    if (j == 0) buttonDownWidth = 48;
                    if (j == group.items.Count - 1) buttonUpWidth = 48;

                    //draw up & down buttons for re-ordering items in a group
                    //this will simply switch references in the list
                    if (j > 0 && GUILayout.Button("▲", GUILayout.Width(buttonUpWidth)))
                    {
                        group.items[j] = group.items[j - 1];
                        group.items[j - 1] = obj;
                        EditorGUIUtility.hotControl = 0;
                        EditorGUIUtility.keyboardControl = 0;
                    }
                    if (j < group.items.Count - 1 && GUILayout.Button("▼", GUILayout.Width(buttonDownWidth)))
                    {
                        group.items[j] = group.items[j + 1];
                        group.items[j + 1] = obj;
                        EditorGUIUtility.hotControl = 0;
                        EditorGUIUtility.keyboardControl = 0;
                    }

                    //button for removing an item of the group
                    GUI.backgroundColor = Color.gray;
                    if (GUILayout.Button("X"))
                    {
                        group.items.RemoveAt(j);
                        break;
                    }
                    GUI.backgroundColor = Color.white;
                    EditorGUILayout.EndHorizontal();

                    //draw platform override foldout
                    if (obj.platformFoldout)
                    {
                        EditorGUILayout.LabelField("Platform ID Overrides");
                        for (int k = 0; k < obj.localId.Count; k++)
                        {
                            EditorGUILayout.BeginHorizontal();
                            GUILayout.Space(40);
                            obj.localId[k].overridden = EditorGUILayout.BeginToggleGroup("", obj.localId[k].overridden);
                            EditorGUILayout.BeginHorizontal();
                            obj.localId[k].id = EditorGUILayout.TextField(obj.localId[k].id, GUILayout.Width(120));
                            EditorGUILayout.LabelField(((IAPPlatform)k).ToString());
                            EditorGUILayout.EndHorizontal();
                            EditorGUILayout.EndToggleGroup();
                            EditorGUILayout.EndHorizontal();
                        }
                    }
                }
                GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
                GUILayout.Space(30);
            }

            //ends the scrollview defined above
            EditorGUILayout.EndScrollView();
        }


        //draws the in game content editor
        void DrawIGC(List<IAPGroup> list)
        {
            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.yellow;

            //draw currencies up to a maximum of 9
            //(there is no limitation, but 9 currencies do fit in the window nicely,
            //and there really shouldnt be a reason to have 9+ different currencies)
            if (script.currency.Count < 9)
            {
                //button for adding a new currency
                if (GUILayout.Button("Add Currency"))
                {
                    //create new currency, then loop over items
                    //and add a new currency slot for each of them 
                    IAPCurrency currency = new IAPCurrency();
                    script.currency.Add(currency);
                    return;
                }
            }
            else
            {
                //for more than 9 currencies,
                //we show a transparent button with no functionality
                GUI.backgroundColor = new Color(1, 0.9f, 0, 0.4f);
                if (GUILayout.Button("Add Currency"))
                { }
            }

            GUI.backgroundColor = Color.yellow;
            //draw yellow button for adding a new IAP group
            if (GUILayout.Button("Add new Category"))
            {
                //create new group, give it a generic name based on
                //the current system time and add it to the list of groups
                IAPGroup newGroup = new IAPGroup();
                string timestamp = GenerateUnixTime();
                newGroup.name = "Grp " + timestamp;
                newGroup.id = timestamp;
                list.Add(newGroup);
                return;
            }

            GUI.backgroundColor = Color.white;
            EditorGUILayout.EndHorizontal();

            //begin a scrolling view inside tab, pass in current Vector2 scroll position 
            scrollPosIGC = EditorGUILayout.BeginScrollView(scrollPosIGC, GUILayout.Height(462));
            GUILayout.Space(10);

            //only draw a box behind currencies if there are any
            if (script.currency.Count > 0)
            {
                EditorGUILayout.LabelField("Currencies:", EditorStyles.boldLabel);
                GUILayout.Space(10);
                GUI.Box(new Rect(10, 35, script.currency.Count * 110, 65), "");
            }

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            //loop through currencies
            for (int i = 0; i < script.currency.Count; i++)
            {
                IAPCurrency current = script.currency[i];
                EditorGUILayout.BeginVertical();
                //draw currency properties,
                //such as name and amount
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name", GUILayout.Width(44));
                current.name = EditorGUILayout.TextField(current.name, GUILayout.Width(54));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Default", GUILayout.Width(44));
                script.currency[i].amount = EditorGUILayout.IntField(script.currency[i].amount, GUILayout.Width(54));
                EditorGUILayout.EndHorizontal();

                //button for deleting a currency
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(52);
                GUI.backgroundColor = Color.gray;
                if (GUILayout.Button("X", GUILayout.Width(54)))
                {
                    //ask again before deleting the currency,
                    //as deleting it could cause angry customers!
                    //it's probably better not to remove currencies in production versions
                    if (EditorUtility.DisplayDialog("Delete Currency?",
                        "Existing users might lose their funds associated with this currency when updating.",
                        "Continue", "Abort"))
                    {
                        //then remove the currency
                        script.currency.RemoveAt(i);
                        break;
                    }
                }
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(30);

            //loop over IAP groups
            for (int i = 0; i < list.Count; i++)
            {
                //cache group
                IAPGroup group = list[i];
                Container shopGroup = null;
                if (shop)
                {
                    shopGroup = shop.GetContainer(group.id);
                    if (shopGroup == null)
                    {
                        shopGroup = new Container();
                        shopGroup.id = group.id;
                        shop.containers.Add(shopGroup);
                    }
                }

                EditorGUILayout.BeginHorizontal();
                GUI.backgroundColor = Color.yellow;
                //button for adding a new IAPObject (product) to this group
                if (GUILayout.Button("New Object", GUILayout.Width(120)))
                {
                    IAPObject obj = new IAPObject();
                    group.items.Add(obj);
                    break;
                }
                GUI.backgroundColor = Color.white;

                //draw group properties
                EditorGUILayout.LabelField("Category:", GUILayout.Width(60));
                group.name = EditorGUILayout.TextField(group.name, GUILayout.Width(90));
                GUILayout.FlexibleSpace();

                if (!shop)
                    EditorGUILayout.LabelField("No ShopManager prefab found in this scene!", GUILayout.Width(300));
                else
                {
                    EditorGUILayout.LabelField("Prefab:", GUILayout.Width(45));
                    shopGroup.prefab = (GameObject)EditorGUILayout.ObjectField(shopGroup.prefab, typeof(GameObject), false, GUILayout.Width(100));
                    GUILayout.Space(10);
                    EditorGUILayout.LabelField("Parent:", GUILayout.Width(45));
                    shopGroup.parent = (Transform)EditorGUILayout.ObjectField(shopGroup.parent, typeof(Transform), true, GUILayout.Width(100));
                }

                GUILayout.FlexibleSpace();

                //same as in DrawIAP(),
                //move group up & down buttons
                int groupUpWidth = 22;
                int groupDownWidth = 22;
                if (i == 0) groupDownWidth = 48;
                if (i == list.Count - 1) groupUpWidth = 48;

                if (i > 0 && GUILayout.Button("▲", GUILayout.Width(groupUpWidth)))
                {
                    list[i] = list[i - 1];
                    list[i - 1] = group;
                    EditorGUIUtility.hotControl = 0;
                    EditorGUIUtility.keyboardControl = 0;
                }
                if (i < list.Count - 1 && GUILayout.Button("▼", GUILayout.Width(groupDownWidth)))
                {
                    list[i] = list[i + 1];
                    list[i + 1] = group;
                    EditorGUIUtility.hotControl = 0;
                    EditorGUIUtility.keyboardControl = 0;
                }

                //button for removing a group including items
                GUI.backgroundColor = Color.gray;
                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    if(shop) shop.containers.Remove(shopGroup);
                    list.RemoveAt(i);
                    break;
                }
                GUI.backgroundColor = Color.white;
                EditorGUILayout.EndHorizontal();
                GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

                //draw header information for each item property
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("ID:", GUILayout.Width(120));
                EditorGUILayout.LabelField("Icon:", GUILayout.Width(65));
                EditorGUILayout.LabelField("Type:", GUILayout.Width(165));
                EditorGUILayout.LabelField("Title:", GUILayout.Width(122));
                if (group.items.Count == 1) GUILayout.Space(50);
                EditorGUILayout.LabelField("Description:", GUILayout.Width(150));
                EditorGUILayout.LabelField("Specific Settings:", GUILayout.Width(135));
                EditorGUILayout.LabelField("Price:", GUILayout.Width(100));
                EditorGUILayout.EndHorizontal();

                //loop over items in this group
                for (int j = 0; j < group.items.Count; j++)
                {
                    //cache item reference
                    IAPObject obj = group.items[j];
                    EditorGUILayout.BeginHorizontal();
                    IAPType selectedType = obj.type;

                    //draw IAPObject (item/product) properties
                    obj.id = EditorGUILayout.TextField(obj.id, GUILayout.Width(120));
                    obj.icon = EditorGUILayout.ObjectField(obj.icon, typeof(Sprite), false, GUILayout.Width(65)) as Sprite;
                    obj.type = (IAPType)EditorGUILayout.EnumPopup(obj.type, GUILayout.Width(110));
                    obj.title = EditorGUILayout.TextField(obj.title);
                    obj.description = EditorGUILayout.TextField(obj.description);

                    if (obj.type != selectedType)
                    {
                        obj.specific = "";
                        obj.amount = 0;
                    }

                    DrawTypeSettings(obj);

                    //price field
                    int priceIndex = 0;
                    for (int k = 0; k < currencyNames.Length; k++)
                    {
                        if (obj.virtualPrice.name == currencyNames[k])
                            priceIndex = k;
                    }
                    priceIndex = EditorGUILayout.Popup(priceIndex, currencyNames, GUILayout.Width(60));
                    obj.virtualPrice.name = currencyNames[priceIndex];
                    obj.virtualPrice.amount = EditorGUILayout.IntField(obj.virtualPrice.amount, GUILayout.Width(60));

                    //same as in DrawIAP(), requirement button
                    if (!string.IsNullOrEmpty(obj.req.entry))
                        GUI.backgroundColor = Color.yellow;
                    if (GUILayout.Button("R", GUILayout.Width(20)))
                    {
                        reqEditor = (RequirementEditor)EditorWindow.GetWindowWithRect(typeof(RequirementEditor), new Rect(0, 0, 300, 150), false, "Requirement");
                        reqEditor.obj = obj;
                    }

                    GUI.backgroundColor = Color.white;
                    //same as in DrawIAP(), move item up & down buttons
                    int buttonUpWidth = 22;
                    int buttonDownWidth = 22;
                    if (j == 0) buttonDownWidth = 48;
                    if (j == group.items.Count - 1) buttonUpWidth = 48;

                    if (j > 0 && GUILayout.Button("▲", GUILayout.Width(buttonUpWidth)))
                    {
                        group.items[j] = group.items[j - 1];
                        group.items[j - 1] = obj;
                        EditorGUIUtility.hotControl = 0;
                        EditorGUIUtility.keyboardControl = 0;
                    }
                    if (j < group.items.Count - 1 && GUILayout.Button("▼", GUILayout.Width(buttonDownWidth)))
                    {
                        group.items[j] = group.items[j + 1];
                        group.items[j + 1] = obj;
                        EditorGUIUtility.hotControl = 0;
                        EditorGUIUtility.keyboardControl = 0;
                    }

                    //button for removing an item of the group
                    GUI.backgroundColor = Color.gray;
                    if (GUILayout.Button("X"))
                    {
                        group.items.RemoveAt(j);
                        break;
                    }
                    GUI.backgroundColor = Color.white;
                    EditorGUILayout.EndHorizontal();
                }
                GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
                GUILayout.Space(30);
            }

            //ends the scrollview defined above
            EditorGUILayout.EndScrollView();
        }


        //draw specific settings for the selected type
        void DrawTypeSettings(IAPObject obj)
        {
            switch (obj.type)
            {
                case IAPType.VirtualCurrencyPack:
                    int currencyIndex = 0;
                    for (int k = 0; k < currencyNames.Length; k++)
                    {
                        if (obj.specific == currencyNames[k])
                            currencyIndex = k;
                    }
                    currencyIndex = EditorGUILayout.Popup(currencyIndex, currencyNames, GUILayout.Width(100));
                    obj.specific = currencyNames[currencyIndex];
                    obj.amount = EditorGUILayout.IntField(obj.amount, GUILayout.Width(60));
                    break;
                case IAPType.SingleUsePackVG:
                    if (string.IsNullOrEmpty(obj.specific)) obj.specific = "[GOOD ID]";
                    obj.specific = EditorGUILayout.TextField(obj.specific, GUILayout.Width(100));
                    obj.amount = EditorGUILayout.IntField(obj.amount, GUILayout.Width(60)); ;
                    break;
                case IAPType.UpgradeVG:
                    if (string.IsNullOrEmpty(obj.specific)) obj.specific = "[ID];[PREV];[NEXT]";
                    string[] props = obj.specific.Split(';');
                    for (int k = 0; k < props.Length; k++)
                        props[k] = EditorGUILayout.TextField(props[k], GUILayout.Width(52));
                    obj.specific = props[0] + ";" + props[1] + ";" + props[2];
                    break;
                case IAPType.EquippableVG:
                    string[] equippingModel = new string[] { EquippableVG.EquippingModel.LOCAL.ToString(),
                                                                     EquippableVG.EquippingModel.CATEGORY.ToString(),
                                                                     EquippableVG.EquippingModel.GLOBAL.ToString() };
                    int equippingIndex = 0;
                    for (int k = 0; k < equippingModel.Length; k++)
                    {
                        if (obj.specific == equippingModel[k])
                            equippingIndex = k;
                    }

                    equippingIndex = EditorGUILayout.Popup(equippingIndex, equippingModel, GUILayout.Width(164));
                    obj.specific = equippingModel[equippingIndex];
                    break;
                default:
                    EditorGUILayout.LabelField("--------------------------------", GUILayout.Width(164));
                    break;
            }
        }


        //returns an array that holds all currency names
        string[] GetCurrencyNames()
        {
            //get list of currencies
            List<IAPCurrency> list = script.currency;
            //create new array with the same size, then loop
            //over currencies and populate array with their names
            string[] curs = new string[list.Count];
            for (int i = 0; i < curs.Length; i++)
                curs[i] = list[i].name;
            //return names array
            return curs;
        }


        string GenerateUnixTime()
        {
            var epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            return (System.DateTime.UtcNow - epochStart).TotalSeconds.ToString() + Random.Range(0, 1000);
        }


        private static void SavePrefab()
        {
            if (!IAPPrefab) return;

            GameObject go = PrefabUtility.InstantiatePrefab(IAPPrefab) as GameObject;
            PrefabUtility.ReplacePrefab(go, IAPPrefab);
            DestroyImmediate(go);
        }


        void TrackChange()
        {
            //if we typed in other values in the editor window,
            //we need to repaint it in order to display the new values
            if (GUI.changed)
            {
                //we have to tell Unity that a value of our script has changed
                //http://unity3d.com/support/documentation/ScriptReference/EditorUtility.SetDirty.html
                if (shop) EditorUtility.SetDirty(shop);

                //repaint editor GUI window
                Repaint();
            }
        }


        //track project save state and save changes to prefab on project save
        public class IAPModificationProcessor : UnityEditor.AssetModificationProcessor
        {
            public static string[] OnWillSaveAssets(string[] paths)
            {
                if (IAPEditor.iapEditor)
                    IAPEditor.SavePrefab();
                return paths;
            }
        }
    }
}