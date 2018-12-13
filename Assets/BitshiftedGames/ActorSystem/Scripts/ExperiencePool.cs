using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.ActorSystem
{
    [System.Serializable]
    public class ExperiencePool
    {
        [SerializeField] private float poolAmount;

        public ExperiencePool ()
        {
            poolAmount = 0f;
        }

        public ExperiencePool ( float startingAmount )
        {
            poolAmount = Mathf.Abs ( startingAmount );
        }

        #region Public API
        /// <summary>
        /// Amount of experience currently in the pool
        /// </summary>
        public float GetTotal
        {
            get { return poolAmount; }
        }

        /// <summary>
        /// Adds the passed amount of experience to the pool
        /// </summary>
        /// <param name="amount">Amount of experience to add</param>
        public void AddExperience ( float amount )
        {
            poolAmount += Mathf.Abs ( amount );
        }

        /// <summary>
        /// Removes the passed amount of experience from the pool
        /// </summary>
        /// <param name="amount">Amount of experience to remove</param>
        public void RemoveExperience ( float amount )
        {
            poolAmount -= Mathf.Abs ( amount );
        }
        #endregion
    }
}