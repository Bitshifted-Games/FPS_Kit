using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.Localization
{
    [System.Serializable]
    public class LocalizedLanguageData
    {
        public SupportedLanguages Language;
        public LocalizationItem[] items;

        public bool ContainsKey (string key)
        {
            for ( int i = 0; i < items.Length; i++ )
            {
                if ( items[i].key == key ) return true;
            }
            return false;
        }

        public void AddNewItem(LocalizationItem item )
        {
            System.Array.Resize ( ref items, items.Length + 1 );
            items[items.Length-1] = item;
        }
    }

    [System.Serializable]
    public struct LocalizationItem
    {
        public string key;
        public string value;
    }
}