
#region Using shit

using ExitGames.Client.Photon;
using MelonLoader;
using ReMod.Core;
using ReMod.Core.Managers;
using ReMod.Core.UI.ActionMenu;
using ReMod.Core.UI.ActionMenu;
using ReMod.Core.UI.MainMenu;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.Unity;
using ReMod.Core.VRChat;
using RemodCore_Templte.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Transmtn;
using Transmtn.DTO;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using VRC;
using VRC.Animation;
using VRC.Core;
using VRC.DataModel;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Menus;
#endregion


namespace VSinksModMenu
{

    //!NOTE!
    //You do need to Rename the namespace 
    //if you want other mods made with this template to work lol 
    //Right clk it than press "Rename" than check all include all strings

    //Also when a new Remod.Core comes out make sure to delete the old Remod.Core ref
    //and add the new one lol<3

    //This isn't really for you to use always its also for you to learn from lol 

    /// Note from Ikari lol :
    /// To change the name of the Dll On the top right in the Solution Explorer Right click on ReMod.Core.template New and click Properties
    /// Then change the assambly name to what u want it to be and its done 


    class Main : MelonMod
    {

        #region Wait for UI

        public override void OnApplicationStart() //You Dont need to mess with this
        {
            ClassInjector.RegisterTypeInIl2Cpp<EnableDisableListener>();
            MelonCoroutines.Start(WaitForUI());
        }

        private IEnumerator WaitForUI()
        {
            yield return MenuEx.WaitForUInPatch();
            UserInterface = MenuEx.userInterface;
            MenuStart(); //Start's the menu<3
        }

        public override void OnUpdate() // This is Like a Loop 
        {
          
            //  MelonLogger.Msg("Ikari Is Cool");  //Example If i were to do this it would Print into the console Ikari Is Cool over and over
        }



        #endregion

        #region Objects/Ui

        // This is where "You" put your Ui and game objects<3

        public static GameObject UserInterface;

        public static UiManager _Ui; // Your Uimanager 

        public static ReMenuPage VSinksPage1; //This is your page 

        public static ReCategoryPage TweaksMenu;//This is your Category page

        public static ReMenuPage TestPage_Target;//Target Page

        public static ActionMenuPage Menu_Action; //Action menu

        #endregion

        public static string Color = "#ae0dff"; //Change #f8f8ff to your hex to change the color

        public static void MenuStart() //Put your ui things in here<3
        {
            //So with all the null shit inside the buttons and page's and what not
            //That's like to say its empty or nothing is there 
            //That's all for icons
            //you can either Use files, base64 or my way of making icons lol and loading them<3

            UserInterface.transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().overrideSprite = Icons_For_Dummys.CreateSprite(Icons.QM_Background);

            MelonLogger.Msg("Initializing UI...");

            //To open the box below click the + symbol on the left 

            #region Tab And Button
            _Ui = new UiManager("VSink Tweaks", Icons_For_Dummys.CreateSprite(Icons.Tab), true, true, false, false, Color); //This start's your menu everything else gos under this<3

            //Ctrl Click on the "Icons.Tab" to see how to use it lol <


            #endregion

            MelonLogger.Msg("Initializing Pages");

            #region Page's 





            #endregion

            MelonLogger.Msg("Initializing LaunchPad");

            #region LaunchPad

            _Ui.LaunchPad.AddButton("GPU 4", "Set GPU Level to 4", () => // Adds a Button to the Front Page of the Quick Menu (Which is called launchPad)
            {
                    OVRPlugin.gpuLevel = 4;
                    MelonLogger.Msg("Set GPU Levels to 4");
            }, null, Color);

            _Ui.LaunchPad.AddButton("CPU 4", "Set CPU Level to 4", () => // Adds a Button to the Front Page of the Quick Menu (Which is called launchPad)
            {
                OVRPlugin.cpuLevel = 4;
                MelonLogger.Msg("Set CPU Levels to 4");
            }, null, Color);

            _Ui.LaunchPad.AddButton("90 fps", "Sets fps max to 90", () => // Adds a Button to the Front Page of the Quick Menu (Which is called launchPad)
            {
                OVRPlugin.systemDisplayFrequency = 90;
                MelonLogger.Msg("Set to 90hz");
            }, null, Color);

            _Ui.LaunchPad.AddButton("72 fps", "Sets fps max to 72 (Reccomended)", () => // Adds a Button to the Front Page of the Quick Menu (Which is called launchPad)
            {
                OVRPlugin.systemDisplayFrequency = 72;
                MelonLogger.Msg("Set to 72hz");
            }, null, Color);


            #endregion


            MelonLogger.Msg("Initializing Menu");

            #region Cat
            TweaksMenu = _Ui.MainMenu.AddCategoryPage("Change Settings Manually", "Thank VSink", null, Color);


            var VSinkTweaksCPU = TweaksMenu.AddCategory("CPU Levels 2-4", Color); //This is your category inside of your cat page lol

            VSinkTweaksCPU.AddButton("CPU 4", "CPU Power set to 4", () =>
            {
                OVRPlugin.cpuLevel = 4;
                MelonLogger.Msg("Set CPU Levels to 4");
            }, null, Color);

            VSinkTweaksCPU.AddButton("CPU 3", "CPU Power set to 4", () =>
            {
                OVRPlugin.cpuLevel = 3;
                MelonLogger.Msg("Set CPU Levels to 3");
            }, null, Color);

            VSinkTweaksCPU.AddButton("CPU 2", "CPU Power set to 2", () =>
            {
                OVRPlugin.cpuLevel = 2;
                MelonLogger.Msg("Set CPU Levels to 2");
            }, null, Color);

            var VSinkTweeksMenuGPU = TweaksMenu.AddCategory("GPU Levels 2-4", Color); //This is your category inside of your cat page lol

            VSinkTweeksMenuGPU.AddButton("GPU 4", "GPU Power set to 4", () =>
            {
                OVRPlugin.gpuLevel = 4;
                MelonLogger.Msg("Set GPU Levels to 4");
            }, null, Color);

            VSinkTweeksMenuGPU.AddButton("GPU 3", "GPU Power set to 4", () =>
            {
                OVRPlugin.gpuLevel = 3;
                MelonLogger.Msg("Set GPU Levels to 3");
            }, null, Color);

            VSinkTweeksMenuGPU.AddButton("GPU 2", "GPU Power set to 2", () =>
            {
                OVRPlugin.gpuLevel = 2;
                MelonLogger.Msg("Set GPU Levels to 2");
            }, null, Color);

            var VSinkTweeksMenuFPS = TweaksMenu.AddCategory("Change your FPS Limit", Color); //This is your category inside of your cat page lol

            VSinkTweeksMenuFPS.AddButton("120", "Good luck reaching that high of fps in this game", () =>
            {
                OVRPlugin.systemDisplayFrequency = 120;
                MelonLogger.Msg("Set to 120hz");
            }, null, Color);

            VSinkTweeksMenuFPS.AddButton("90", "Good luck reaching that high of fps in this game", () =>
            {
                OVRPlugin.systemDisplayFrequency = 90;
                MelonLogger.Msg("Set to 90hz");
            }, null, Color);

            VSinkTweeksMenuFPS.AddButton("72", "Use a very optimized world without a mirror", () =>
            {
                OVRPlugin.systemDisplayFrequency = 72;
                MelonLogger.Msg("Set to 72hz");
            }, null, Color);

            VSinkTweeksMenuFPS.AddButton("60", "I think this is the default", () =>
            {
                OVRPlugin.systemDisplayFrequency = 60;
                MelonLogger.Msg("Set to 60hz");
            }, null, Color);

            TweaksMenu = _Ui.MainMenu.AddCategoryPage("Presets", "Thank VSink", null, Color);

            var VSinkTweeksPresets = TweaksMenu.AddCategory("Change your FPS Limit", Color); //This is your category inside of your cat page lol

            VSinkTweeksPresets.AddButton("Defaults", "The Defaults for VRChat", () =>
            {
                OVRPlugin.systemDisplayFrequency = 72;
                MelonLogger.Msg("Set to 72hz");
                OVRPlugin.gpuLevel = 2;
                MelonLogger.Msg("Set GPU Levels to 2");
                OVRPlugin.cpuLevel = 2;
                MelonLogger.Msg("Set CPU Levels to 2");
            }, null, Color);

            VSinkTweeksPresets.AddButton("Fast!", "Sets GPU and CPU to full and lowers your FPS", () =>
            {
                OVRPlugin.systemDisplayFrequency = 72;
                MelonLogger.Msg("Set to 72hz");
                OVRPlugin.gpuLevel = 4;
                MelonLogger.Msg("Set GPU Levels to 4");
                OVRPlugin.cpuLevel = 4;
                MelonLogger.Msg("Set CPU Levels to 4");
            }, null, Color);

            VSinkTweeksPresets.AddButton("Max Power", "Everyting is set to the highest it can", () =>
            {
                OVRPlugin.systemDisplayFrequency = 120;
                MelonLogger.Msg("Set to 120z");
                OVRPlugin.gpuLevel = 4;
                MelonLogger.Msg("Set GPU Levels to 4");
                OVRPlugin.cpuLevel = 4;
                MelonLogger.Msg("Set CPU Levels to 4");
            }, null, Color);

            VSinkTweeksPresets.AddButton("Power Saving", "Sets everything to the lowest", () =>
            {
                OVRPlugin.systemDisplayFrequency = 60;
                MelonLogger.Msg("Set to 60hz");
                OVRPlugin.gpuLevel = 2;
                MelonLogger.Msg("Set GPU Levels to 2");
                OVRPlugin.cpuLevel = 2;
                MelonLogger.Msg("Set CPU Levels to 2");
            }, null, Color);

            VSinkTweeksPresets.AddButton("Balance", "Good for worlds that are highly optimized", () =>
            {
                OVRPlugin.systemDisplayFrequency = 90;
                MelonLogger.Msg("Set to 90hz");
                OVRPlugin.gpuLevel = 3;
                MelonLogger.Msg("Set GPU Levels to 4");
                OVRPlugin.cpuLevel = 3;
                MelonLogger.Msg("Set CPU Levels to 4");
            }, null, Color);


            /*************************************************************************************************
             * Currently out of order, Sorry! I want to add it, but nothing I do works.
                        var VSinksTweeksMenuRes = TweaksMenu.AddSliderCategory("Resolution Controller", Color); //This is your Slider category inside of your cat page lol

                        VSinksTweeksMenuRes.AddSlider("Resolution Slider", "Tool tip", f =>
                        {
                            OVRPlugin.SetDesiredEyeTextureFormat(1, 1);
                        }, true, 0, 10, 100, Color);//Slider<3
            *************************************************************************************************/
            //eyeTextureResolutionScale = 

            LOADING_CLIENT.Extra.Note();
            //NOTE: !!Anything Ui below this will not load!!
            #endregion
        }
    }
}







