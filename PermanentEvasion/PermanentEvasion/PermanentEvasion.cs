using Harmony;
using System.Reflection;

namespace PermanentEvasion
{
    public class PermanentEvasion
    {
        public static void Init() {
            var harmony = HarmonyInstance.Create("de.morphyum.BrokenSalvagedMechs");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
