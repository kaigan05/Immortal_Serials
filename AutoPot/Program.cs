using System;
using System.Reflection;
using LeagueSharp;
using LeagueSharp.Common;

namespace AutoPot
{
     class Program
    {
        public static Menu MainMenu;

        private static void Main(string[] args)
        {
            MainMenu = new Menu("[KH] Potion Manager", "PotionManager", true);
            //Menu ActivatorMenu = MainMenu.AddSubMenu(new Menu("Activator", "Activator"));
            new AutoPot(MainMenu);
            MainMenu.AddToMainMenu();
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Game.PrintChat("<font color = \"#00FF2B\">AutoPot</font> by <font color = \"#FD00FF\">kaigan</font> - Loaded!");
        }
    }
}