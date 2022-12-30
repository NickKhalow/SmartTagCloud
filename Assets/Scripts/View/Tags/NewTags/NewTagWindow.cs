using Core.Data;
using Core.Util;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View.Binds;


namespace View.Tags.NewTags
{
    public class NewTagWindow : MonoBehaviour, IBind<ITags>
    {
        public event Action<ITag>? Created;


        [SerializeField] private Button createButton = null!;
        [SerializeField] private TMP_InputField inputField = null!;
        private ITags tags = null!;


        private void Awake()
        {
            createButton.EnsureNotNull();
            inputField.EnsureNotNull();

            createButton.onClick!.AddListener(Create);
        }


        private void Create()
        {
            var @new = tags.New(inputField.text!);
            Created?.Invoke(@new);
        }


        public void Bind(ITags value)
        {
            tags = value;
        }
    }
}