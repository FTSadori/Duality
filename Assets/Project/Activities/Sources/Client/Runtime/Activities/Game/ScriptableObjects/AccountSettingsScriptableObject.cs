using System.Collections.Generic;
using UnityEngine;

namespace Client.Runtime.Activities.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AccountSettings", menuName = "ScriptableObjects/AccountSettings")]
    public sealed class AccountSettingsScriptableObject : ScriptableObject
    {
        public List<Sprite> profilePictures = new();
        public List<Color> profileColors = new();
    }
}
