﻿using Harmony;
using System.Reflection;

namespace PermanentEvasion
{
    public class PermanentEvasion
    {
        internal static string ModDirectory;
        public static void Init(string directory, string settingsJSON) {
            var harmony = HarmonyInstance.Create("dZ.donZappo.Semi_Permanent_Evasion");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModDirectory = directory;
        }
    }
}
