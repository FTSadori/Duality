using Client.Runtime.Activities.Game.ScriptableObjects;
using UnityEngine;

namespace Client.Runtime.Activities.Base
{
    public sealed class TextBehavior : MonoBehaviour
    {
        [SerializeField] FontDataScriptableObject _fontData;

        private void Start()
        {
            if (TryGetComponent(out TMPro.TMP_Text tmptext))
            {
                tmptext.font = _fontData._textFont;
            }
        }
    }
}
