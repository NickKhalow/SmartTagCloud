using Core.Util;
using UnityEngine;
using UnityEngine.UI;


namespace View.NewTags
{
    [RequireComponent(typeof(Button))]
    public class NewTagButton : MonoBehaviour
    {
        private Button button = null!;


        private void Awake()
        {
            button = GetComponent<Button>().EnsureNotNull();
        }
    }
}