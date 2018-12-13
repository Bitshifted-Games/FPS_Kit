using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitshiftedGames.ActorSystem
{
    [System.Serializable]
    public class ActorVital
    {
        [SerializeField] private float maxValue;
        [SerializeField] private float currentValue;
        [SerializeField] private bool regenActive = false;
        [SerializeField] private float regenMagnitude = 2f;
        [SerializeField] private float regenFrequency = 0.5f;

        public ActorVital ()
        {
            Max = 100f;
            Value = Max;
        }

        public ActorVital(float max )
        {
            Max = max;
            Value = Max;
        }

        public float Max
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public float Value
        {
            get { return currentValue; }
            set
            {
                if ( value <= maxValue && value > 0f )                    currentValue = value;
                else
                {
                    if ( value < 0f ) currentValue = 0f;
                    else if ( value > maxValue ) currentValue = maxValue;
                }
            }
        }

        public bool IsRegenerating
        {
            get { return regenActive; }
            set { regenActive = value; }
        }

        public void Increase ( float amount )
        {
            Value += amount;
        }

        public void Decrease ( float amount )
        {
            Value -= amount;
        }

        public void DoRegenTick ()
        {
            if ( !regenActive ) return;
            Increase ( regenMagnitude );
        }
    }
}