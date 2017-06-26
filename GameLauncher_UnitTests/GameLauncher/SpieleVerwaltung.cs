using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace GameLauncher
{
    internal class SpieleVerwaltung
    {
        internal static List<Spiel> SpielHinzufügen(string Titel, string Genre, int USK, string executable, List<Spiel> SpieleListe)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (subkey.GetValue("DisplayName") != null)
                        {
                            if (subkey.GetValue("DisplayName").ToString() == Titel)
                            {
                                SpieleListe.Add(new Spiel(Titel, Genre, subkey.GetValue("Publisher").ToString(), USK, subkey.GetValue("InstallLocation").ToString(), executable));
                                return SpieleListe;
                            }
                        }
                    }
                }
            }
            throw new NotInstalledException("Das gewählte Spiel ist nicht installiert.");
        }

        internal static List<Spiel> SpielEntfernen(string Titel, string Publisher, List<Spiel> spieleListe)
        {
            Spiel zuLöschen = null;
            foreach (Spiel spiel in spieleListe)
            {
                if (spiel.titel == Titel && spiel.publisher == Publisher)
                {
                    zuLöschen = spiel;
                }
            }
            spieleListe.Remove(zuLöschen);
            return spieleListe;
        }

        internal static void SpielStarten(string Titel, string Publisher, List<Spiel> spieleListe)
        {
            foreach (Spiel spiel in spieleListe)
            {
                if (spiel.titel == Titel && spiel.publisher == Publisher)
                {
                    System.Diagnostics.Process.Start(spiel.installationsPfad + spiel.executable);
                }
            }
        }
    }
}