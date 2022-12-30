using Core.Data;
using Core.Util;
using System;
using System.Collections.Generic;
using UnityEngine;
using View.Pool;


namespace View.Tags.Lists
{
    public class TagListView : MonoBehaviour
    {
        [SerializeField] private TagBadgeView prefab = null!;
        [SerializeField] private Transform badgeParent = null!;
        private readonly List<TagBadgeView> actives = new();
        private ObjectPool<TagBadgeView> pool = null!;


        private void Awake()
        {
            badgeParent.EnsureNotNull();
            pool = new ObjectPool<TagBadgeView>(
                () => Instantiate(prefab, badgeParent),
                postPop: view => view.gameObject.SetActive(true),
                prePush: view => view.gameObject.SetActive(false));
        }


        public void Render(IReadOnlyList<ITag> tags)
        {
            foreach (var tagBadgeView in actives)
            {
                pool.Push(tagBadgeView);
            }

            actives.Clear();
            foreach (var t in tags)
            {
                var view = pool.Pop();
                view.Tag(t);
                actives.Add(view);
            }
        }
    }
}