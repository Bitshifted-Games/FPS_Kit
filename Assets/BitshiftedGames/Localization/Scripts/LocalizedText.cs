using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitshiftedGames.Localization
{
    public class LocalizedText : MonoBehaviour
    {
        public string key;

        private void OnEnable ()
        {
            LocalizationManager.instance.LanguageSwitchEvent += SetLocalizedString;
        }

        private void OnDisable ()
        {
            LocalizationManager.instance.LanguageSwitchEvent -= SetLocalizedString;
        }

        // Use this for initialization
        void Start ()
        {
            SetLocalizedString ();
        }

        void SetLocalizedString ()
        {
            Text text = GetComponent<Text> ();
            text.text = LocalizationManager.instance.GetLocalizedValue ( key );
        }

    }
}