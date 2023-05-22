using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using tetrakarn_makarakarn_nerf;

[assembly: MelonInfo(typeof(TetrakarnMakarakarnNerf), "Tetrakarn/Makarakarn nerf (self only)", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace tetrakarn_makarakarn_nerf;
public class TetrakarnMakarakarnNerf : MelonMod
{
    // After getting the description of a skill
    [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
    private class Patch
    {
        public static void Postfix(ref int id, ref string __result)
        {
            switch (id) {
                case 69:
                    __result = "Repels Magical attacks \nonce next turn."; // Makarakarn
                    break;
                case 70:
                    __result = "Repels Physical attacks \nonce next turn."; // Tetrakarn
                    break;
            }
        }
    }

    // After getting the description of an item
    [HarmonyPatch(typeof(datItemHelp_msg), nameof(datItemHelp_msg.Get))]
    private class Patch2
    {
        public static void Postfix(ref int id, ref string __result)
        {
            switch (id)
            {
                case 34:
                    __result = "Repels Magical attacks \nonce next turn."; // Magic Mirror
                    break;
                case 35:
                    __result = "Repels Physical attacks \nonce next turn."; // Attack Mirror
                    break;
            }
        }
    }

    // When launching the game
    public override void OnInitializeMelon()
    {
        datNormalSkill.tbl[69].targettype = 0; // Makes Makarakarn 1 target
        datNormalSkill.tbl[70].targettype = 0; // Makes Tetrakarn 1 target

        datNormalSkill.tbl[69].targetrule = 1; // Makes Makarakarn only work on self
        datNormalSkill.tbl[70].targetrule = 1; // Makes Tetrakarn only work on self
    }
}
