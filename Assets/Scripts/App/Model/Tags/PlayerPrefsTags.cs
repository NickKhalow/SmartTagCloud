using Core.Data;
using Core.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace App.Model.Tags
{
    public class PlayerPrefsTags : ITags
    {
        private readonly IdList idList = new();


        public ITag New(string tag)
        {
            var id = Guid.NewGuid();
            idList.Add(id);
            PlayerPrefs.SetString(id.ToString(), tag);
            PlayerPrefs.Save();
            return new Tag(id, tag);
        }


        public bool Contains(string tag)
        {
            return All().Any(t => t.Text() == tag);
        }


        public IReadOnlyList<ITag> All()
        {
            var ids = idList.All();
            var list = new List<ITag>(ids.Count);
            foreach (var id in ids)
            {
                list.Add(
                    new Tag(
                        Guid.Parse(id),
                        PlayerPrefs.GetString(id)!
                    )
                );
            }

            return list;
        }


        private class IdList
        {
            private const string Key = "id_list";


            public void Add(Guid id)
            {
                PlayerPrefs.SetString(
                    Key,
                    JsonConvert.SerializeObject(
                        new List<string>(
                            All()
                        )
                        {
                            id.ToString()
                        }
                    )
                );
            }


            public IReadOnlyList<string> All()
            {
                return PlayerPrefs.HasKey(Key)
                    ? JsonConvert.DeserializeObject<List<string>>(
                        PlayerPrefs.GetString(Key)!
                    ).EnsureNotNull()
                    : new List<string>();
            }
        }
    }
}