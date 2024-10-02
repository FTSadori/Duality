using System.Diagnostics.Contracts;

namespace Client.Runtime.System
{
    public sealed class Scenes
    {
        public static class System
        {
            public const string Audio = "System_Audio";
            public const string Input = "System_Input";
            public const string MainCamera = "System_MainCamera";
        }

        public static class Activity
        {
            public const string LobbyBackground = "Activity_LobbyBackground";
            public const string Lobby = "Activity_Lobby";
            public const string Saves = "Activity_Saves";
            public const string Settings = "Activity_Settings";
            public const string Extra = "Activity_Extra";
            public const string ExitGamePopUp = "Activity_ExitGamePopUp";
            public const string TutorialStart = "Activity_TutorialStart";
        }
    }
}