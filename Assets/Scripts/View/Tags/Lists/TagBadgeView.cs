using Core.Data;
using Core.Util;
using System.Collections;
using TMPro;
using UnityEngine;


namespace View.Tags.Lists
{
    [RequireComponent(typeof(RectTransform))]
    public class TagBadgeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = null!;
        private RectTransform rectTransform = null!;


        private void Awake()
        {
            text.EnsureNotNull();
            rectTransform = GetComponent<RectTransform>().EnsureNotNull();
        }


        public void Tag(ITag value)
        {
            text.SetText(value.Text());
            StartCoroutine(Fit());
        }


        [ContextMenu(nameof(Fit))]
        private IEnumerator Fit()
        {
             yield return null;
             //TODO
            //yield return new WaitForSeconds(1);
            var rect = text.rectTransform!.rect;
            rectTransform.sizeDelta = new Vector2(rect.width, rect.height);
        }
    }
}