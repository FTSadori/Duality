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
            public const string Extra = "Activity_Extra";
            public const string GameGUI = "Activity_GameGUI";
            public const string Tutorial = "Activity_Tutorial";
            public const string RestartBootstrap = "RestartBootstrap";
            public const string TransitionBootstrap = "TransitionBootstrap";
        }
    }
}