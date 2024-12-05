using Client.Runtime.Activities.Game.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Assets.Project.Activities.Sources.Client.Runtime.Activities.Game.Base
{
    public sealed class CloseLeaderboardButtonCommand : ButtonCommand
    {
        [SerializeField] private InstantRestartSequenceCommand _command;

        public override void Execute()
        {
            _command.Execute();
        }
    }
}
