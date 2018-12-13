using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.ActorSystem
{
    public class Actor : MonoBehaviour
    {
        public ActorVital Health;
        public ActorVital Stamina;

        public ExperiencePool experiencePool;

        private void Initialize ()
        {
            if ( experiencePool == null ) experiencePool = new ExperiencePool ();
        }

        private void OnEnable ()
        {
            Initialize ();
        }

        // Start is called before the first frame update
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}