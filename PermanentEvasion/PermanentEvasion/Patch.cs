using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Collections.Generic;

namespace PermanentEvasion {

    [HarmonyPatch(typeof(AbstractActor), "ResolveAttackSequence")]
    public static class AbstractActor_ResolveAttackSequence {

        static bool Prefix(AbstractActor __instance) {
            return false;
        }

        static void Postfix(AbstractActor __instance, string sourceID, int sequenceID, int stackItemID, AttackDirection attackDirection) {
            try {

                AttackDirector.AttackSequence attackSequence = __instance.Combat.AttackDirector.GetAttackSequence(sequenceID);
                if (attackSequence != null && attackSequence.attackDidDamage) {
                    List<Effect> list = __instance.Combat.EffectManager.GetAllEffectsTargeting(__instance).FindAll((Effect x) => x.EffectData.targetingData.effectTriggerType == EffectTriggerType.OnDamaged);
                    for (int i = 0; i < list.Count; i++) {
                        list[i].OnEffectTakeDamage(attackSequence.attacker, __instance);
                    }
                    if (attackSequence.isMelee) {
                        int value = attackSequence.attacker.StatCollection.GetValue<int>("MeleeHitPushBackPhases");
                        if (value > 0) {
                            for (int j = 0; j < value; j++) {
                                __instance.ForceUnitOnePhaseDown(sourceID, stackItemID, false);
                            }
                        }
                    }
                }
                int evasivePipsCurrent = __instance.EvasivePipsCurrent;
                if (Fields.LoosePip) {
                    __instance.ConsumeEvasivePip(true);
                    Fields.LoosePip = false;
                }
                int evasivePipsCurrent2 = __instance.EvasivePipsCurrent;
                if (evasivePipsCurrent2 < evasivePipsCurrent && !__instance.IsDead && !__instance.IsFlaggedForDeath) {
                    __instance.Combat.MessageCenter.PublishMessage(new FloatieMessage(__instance.GUID, __instance.GUID, "-1 EVASION", FloatieMessage.MessageNature.Debuff));
                }
            }
            catch (Exception e) {
                Logger.LogError(e);
            }
        }
    }

    [HarmonyPatch(typeof(Mech), "ResolveAttackSequence", null)]
    public static class Mech_ResolveAttackSequence
    {
        // Token: 0x0600000F RID: 15 RVA: 0x000023E4 File Offset: 0x000005E4
        private static void Prefix(Mech __instance)
        {
            Settings settings = Helper.LoadSettings();
            try
            {
                bool flag = false;
                using (List<Ability>.Enumerator enumerator = __instance.pilot.Abilities.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.Def.Description.Id == "AbilityDefP8")
                        {
                            flag = true;
                        }
                    }
                }
                int num = settings.PercentageToKeepPips;
                if (flag)
                {
                    num = settings.PercentageToKeepPips + settings.AcePilotBonusPercentage;
                }
                bool flag2 = UnityEngine.Random.Range(1, 100) < num;
                if (flag)
                {
                    if (__instance.MaxWalkDistance == 210f && settings.Movement210KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (__instance.MaxWalkDistance == 190f && settings.Movement190KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (__instance.MaxWalkDistance == 165f && settings.Movement165KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (__instance.MaxWalkDistance == 140f && settings.Movement140KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (__instance.MaxWalkDistance == 120f && settings.Movement120KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (__instance.MaxWalkDistance == 95f && settings.Movement95KeepPipsCount + settings.AcePilotBonusPips < __instance.EvasivePipsCurrent)
                    {
                        Fields.LoosePip = true;
                    }
                    else if (!flag2)
                    {
                        Fields.LoosePip = true;
                    }
                }
                else if (__instance.MaxWalkDistance == 210f && settings.Movement210KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (__instance.MaxWalkDistance == 190f && settings.Movement190KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (__instance.MaxWalkDistance == 165f && settings.Movement165KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (__instance.MaxWalkDistance == 140f && settings.Movement140KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (__instance.MaxWalkDistance == 120f && settings.Movement120KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (__instance.MaxWalkDistance == 95f && settings.Movement95KeepPipsCount < __instance.EvasivePipsCurrent)
                {
                    Fields.LoosePip = true;
                }
                else if (!flag2)
                {
                    Fields.LoosePip = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}