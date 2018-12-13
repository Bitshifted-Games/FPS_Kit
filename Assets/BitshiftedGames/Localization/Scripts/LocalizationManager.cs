using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BitshiftedGames.Localization
{
    [System.Serializable]
    public enum SupportedLanguages
    {
        UNLOCALIZED,
        English,
        French,
        German,
        Italian
    }

    [System.Serializable]
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager instance;

        public SupportedLanguages selectedLanguage;
        public bool DebugMode = true;

        private Dictionary<string, string> unlocalizedText;
        private Dictionary<string, string> localizedText;
        private readonly string missingTextString = "Localized text not found";
        private bool isReady = false;

        private string unlocalizedTextPath = "unlocalizedText_en.json";

        public string GetMissingTextString ()
        {
            return missingTextString;
        }
        public bool GetIsReady ()
        {
            return isReady;
        }

        public delegate void LanguageSwitchHandler ();
        public LanguageSwitchHandler LanguageSwitchEvent;
        public void ChangeLanguage ()
        {
            if ( LanguageSwitchEvent != null )
                LanguageSwitchEvent ();
        }

        // Use this for initialization
        void Awake ()
        {
            if ( instance == null )
            {
                instance = this;
            } else if ( instance != this )
            {
                Destroy ( gameObject );
            }

            DontDestroyOnLoad ( gameObject );
            switch ( selectedLanguage )
            {
                case SupportedLanguages.UNLOCALIZED:
                    LoadUnlocalizedText ();
                    break;
                case SupportedLanguages.English:
                    LoadLocalizedText ( "localizedText_en.json" );
                    break;
                case SupportedLanguages.French:
                    LoadLocalizedText ( "localizedText_fr.json" );
                    break;
                case SupportedLanguages.German:
                    LoadLocalizedText ( "localizedText_de.json" );
                    break;
                case SupportedLanguages.Italian:
                    LoadLocalizedText ( "localizedText_it.json" );
                    break;
                default:
                    LoadUnlocalizedText ();
                    break;
            }
        }

        /// <summary>
        /// Deserializes JSON data contained within the passed filename
        /// </summary>
        /// <param name="filename"></param>
        public void LoadLocalizedText ( string fileName )
        {
            localizedText = new Dictionary<string, string> ();

            string filePath = Path.Combine ( Path.Combine ( Application.streamingAssetsPath, "lang" ), fileName );

            if ( File.Exists ( filePath ) )
            {
                string dataAsJson = File.ReadAllText ( filePath );
                LocalizedLanguageData loadedData = JsonUtility.FromJson<LocalizedLanguageData> ( dataAsJson );
                for ( int i = 0; i < loadedData.items.Length; i++ )
                    localizedText.Add ( loadedData.items[i].key, loadedData.items[i].value );

                selectedLanguage = loadedData.Language;

                foreach ( KeyValuePair<string, string> pair in unlocalizedText )
                    if ( !localizedText.ContainsKey ( pair.Key ) ) localizedText.Add ( pair.Key, pair.Value );

                Debug.Log ( "Data loaded, dictionary contains: " + localizedText.Count + " entries" );
            } else
            {
                Debug.LogError ( "Cannot find file! Defaulting to unlocalized text" );
                LoadUnlocalizedText ();
            }

            isReady = true;
        }

        /// <summary>
        /// Retrieves the given key if it exists
        /// </summary>
        /// <param name="key">Key to search for</param>
        /// <returns>Localized string stored in key</returns>
        public string GetLocalizedValue ( string key )
        {
            string result = missingTextString;
            if ( localizedText.ContainsKey ( key ) )
                result = localizedText[key];
            return result;
        }

        private void LoadUnlocalizedText ()
        {
            unlocalizedText = new Dictionary<string, string> ();
            string filePath = Path.Combine ( Application.streamingAssetsPath, "lang" );
            filePath = Path.Combine ( filePath, unlocalizedTextPath );

            if ( File.Exists ( filePath ) )
            {
                string dataAsJson = File.ReadAllText ( filePath );
                LocalizedLanguageData loadedData = JsonUtility.FromJson<LocalizedLanguageData> ( dataAsJson );

                for ( int i = 0; i < loadedData.items.Length; i++ )
                {
                    unlocalizedText.Add ( loadedData.items[i].key, loadedData.items[i].value );
                }

                Debug.Log ( "Data loaded, dictionary contains: " + unlocalizedText.Count + " entries" );
            } else
            {
                Debug.LogError ( "Cannot find file! Defaulting to English text" );
                LoadLocalizedText ( "localizedText_en.json" );
            }
            localizedText = unlocalizedText;
        }

        private void LoadBySelectedLanguage ()
        {
            switch ( selectedLanguage )
            {
                case SupportedLanguages.English:
                    LoadLocalizedText ( "localizedText_en.json" );
                    break;
                case SupportedLanguages.French:
                    LoadLocalizedText ( "localizedText_fr.json" );
                    break;
                case SupportedLanguages.German:
                    LoadLocalizedText ( "localizedText_de.json" );
                    break;
                case SupportedLanguages.Italian:
                    LoadLocalizedText ( "localizedText_it.json" );
                    break;
                default:
                    LoadLocalizedText ( "unlocalizedText_en.json" );
                    break;
            }
        }
    }
}