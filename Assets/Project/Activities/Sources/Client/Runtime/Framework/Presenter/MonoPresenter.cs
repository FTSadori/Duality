using UnityEngine;

namespace Client.Runtime.Framework.Presenter
{
    public abstract class MonoPresenter : MonoBehaviour, IPresenter
    {
        public virtual void Disable()
        {
        }

        public virtual void Enable()
        {
        }
    }
}
