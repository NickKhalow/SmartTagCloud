using App.Model.Tags;
using Core.Data;
using Core.Data.Tags;
using Core.Util;
using UnityEngine;
using View.Tags.Lists;
using View.Tags.NewTags;


namespace App
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private NewTagWindow newTagWindow = null!;
        [SerializeField] private TagListView tagListView = null!;
        private readonly ITags tags =
            new CachedTags(
                new UniqueOnlyTags(
                    new PlayerPrefsTags()
                )
            );


        private void Awake()
        {
            newTagWindow.EnsureNotNull().Bind(tags);
            tagListView.EnsureNotNull().Render(tags.All());
            newTagWindow.Created += NewTagWindowOnCreated;
        }


        private void NewTagWindowOnCreated(ITag obj)
        {
            tagListView.Render(tags.All());
        }
    }
}