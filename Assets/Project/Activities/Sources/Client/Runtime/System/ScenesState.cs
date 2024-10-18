using System.Collections.Generic;

namespace Client.Runtime.System
{
    public sealed class ScenesState
    {
        private static HashSet<string> _inLoad = new();

        public static void AddInLoad(string sceneName)
        {
            _inLoad.Add(sceneName);
        }

        public static bool IsInLoad(string sceneName)
        {
            return _inLoad.Contains(sceneName);
        }

        public static void RemoveInLoad(string sceneName)
        {
            _inLoad.Remove(sceneName);
        }
    }
}
