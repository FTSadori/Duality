using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ExitGameButtonCommand : ActivateSceneButton
    {
        protected override string SceneToActivate => Scenes.Activity.ExitGamePopUp;
    }
}
