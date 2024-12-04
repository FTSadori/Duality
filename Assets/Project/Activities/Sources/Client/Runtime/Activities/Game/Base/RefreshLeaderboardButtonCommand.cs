using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Base
{
    public sealed class RefreshLeaderboardButtonCommand : ButtonCommand
    {
        [SerializeField] FinishLineController _finish;

        public override void Execute()
        {
            _finish.ClearLeaderboard();
            _finish.GetLeaderboard();
        }
    }
}
