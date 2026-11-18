using HarmonyLib;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof($safeprojectname$.Core), "$safeprojectname$", "1.0.0", "alydev", null)]
[assembly: MelonGame("Finn Schuuring", "King of the Bridge")]

namespace $safeprojectname$;

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Initialized.");
    }

    [HarmonyPatch(typeof(ChessMatchManager), nameof(ChessMatchManager.CompleteMove))]
    public static class CompleteMoveWatcher
    {
        public static void Postfix(ChessMatchManager __instance)
        {
        }

        internal static void Reset()
        {
        }
    }

    [HarmonyPatch(typeof(ChessMatchManager), nameof(ChessMatchManager.SetupChessMatch))]
    public static class SetupMatchWatcher
    {
        public static void Postfix()
        {
            Melon<Core>.Logger.Msg("Resetting.");
            CompleteMoveWatcher.Reset();
        }
    }
}
