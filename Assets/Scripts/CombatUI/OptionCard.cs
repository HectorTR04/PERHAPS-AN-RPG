using Assets.Scripts.Globals;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CombatUI
{
    public class OptionCard : MonoBehaviour, IFlippable
    {
        private SpriteRenderer rend;
        [SerializeField] private Sprite cardFrontRegular, cardFrontSelected, cardBack;
        public bool IsSelected { get; set; }
        public bool IsFlipped { get ; set ; }

        public event Action OnFlipped;

        public void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            ((IFlippable)this).IsFlipped = false;
            rend.sprite = cardFrontRegular;
        }

        private void Update()
        {
            if (!((IFlippable)this).IsFlipped && IsSelected)
            {
                if (Input.GetKeyDown(InputCodes.INTERACT_BUTTON))
                {
                    StartCoroutine(Flip());
                }
                rend.sprite = cardFrontSelected;
            }
            else if(!((IFlippable)this).IsFlipped && !IsSelected)
            {
                rend.sprite = cardFrontRegular;
            }
            else if(((IFlippable)this).IsFlipped)
            {
                rend.sprite = cardBack;
            }
        }

        public IEnumerator Flip()
        {
            for (float i = 180f; i >= 0f; i -= 5f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    ((IFlippable)this).IsFlipped = true;
                }
                yield return null;
            }
            OnFlipped?.Invoke();
        }
    }
}
