using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameLauncher;
using System.Diagnostics;

namespace GameLauncher_UnitTests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void spielHinzufügenTest()
        {
            List<Spiel> spieleListe = new List<Spiel>();
            spieleListe = SpieleVerwaltung.SpielHinzufügen("Counter-Strike: Global Offensive", "Taktikshooter", 16, "csgo.exe", spieleListe);
            Assert.AreEqual(1, spieleListe.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NotInstalledException))]
        public void falschesSpielHinzufügenTest()
        {
            List<Spiel> spieleListe = new List<Spiel>();
            spieleListe = SpieleVerwaltung.SpielHinzufügen("Assassin's Creed", "Action-Adventure", 16, "AC.exe", spieleListe);
        }

        [TestMethod]
        public void spielEntfernenTest()
        {
            List<Spiel> spieleListe = new List<Spiel>();
            spieleListe.Add(new Spiel("Assassin's Creed", "Action-Adventure", "Ubisoft", 16, "C:/Program Files/Assassin's Creed/", "AC.exe"));
            spieleListe = SpieleVerwaltung.SpielEntfernen("Assassin's Creed", "Ubisoft", spieleListe);
            Assert.AreEqual(0, spieleListe.Count);
        }

        [TestMethod]
        public void spielStartenTest()
        {
            List<Spiel> spieleListe = new List<Spiel>();
            spieleListe.Add(new Spiel("Counter Strike: Global Offensive", "Taktikshooter", "Valve", 16, "C:/Program Files (x86)/Steam/steamapps/common/Counter-Strike Global Offensive/", "csgo.exe"));
            SpieleVerwaltung.SpielStarten("Counter Strike: Global Offensive", "Valve", spieleListe);
            Process[] laufendesSpiel = Process.GetProcessesByName("csgo");
            Assert.IsTrue(laufendesSpiel[0].ProcessName == "csgo");
        }
    }
}
