using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class MainMenuButton : MonoBehaviour
    {
        public bool IsSelected;

        private SpriteRenderer rend;

        [SerializeField]private Sprite regular, selected;

        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            rend.sprite = regular;
        }

        void Update()
        {
            if (IsSelected)
            {
                rend.sprite = selected;
            }
            else 
            { 
                rend.sprite = regular;
            }
        }
    }
}
