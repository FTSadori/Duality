using Client.Runtime.Framework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Project.Activities.Sources.Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class UnloadSceneKeyDownCommand : KeyDownCommand
    {
        public override void Execute()
        {
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }
    }
}
