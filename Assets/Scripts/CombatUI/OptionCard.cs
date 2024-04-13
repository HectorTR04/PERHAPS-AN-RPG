using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CombatUI
{
    public class OptionCard : MonoBehaviour, IFlippable
    {
        [SerializeField] private Sprite cardFrontRegular, cardFrontSelected, cardBack;

        public bool IsSelected { get; set; }
        public bool IsFlipped { get ; set ; }

        public event Action OnFlipped;

        public IEnumerator Flip()
        {
            yield return null;
        }
    }
}
