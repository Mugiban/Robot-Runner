using UnityEngine;

namespace ID.UserInterface
{
    [ExecuteInEditMode]
    public abstract class MenuPanel : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

