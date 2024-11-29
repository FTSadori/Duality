using TMPro;
using UnityEngine;

namespace Client.Runtime.Activities.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FontData", menuName = "ScriptableObjects/FontData")]
    public sealed class FontDataScriptableObject : ScriptableObject
    {
        public TMP_FontAsset _textFont;
    }
}
