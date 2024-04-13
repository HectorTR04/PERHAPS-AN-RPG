using UnityEngine;
using Assets.Scripts.Globals;

namespace Assets.Scripts.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {        
        [SerializeField] private MainMenuButton continueButton, savesButton, quitButton;
        private enum MenuState { Continue, Saves, Quit };
        private MenuState CurrentMenuState;

        void Start()
        {
            continueButton.IsSelected = false;
            savesButton.IsSelected = false;
            quitButton.IsSelected = false;
            CurrentMenuState = MenuState.Continue;
        }

        void Update()
        {
            MenuNavigation();
            switch (CurrentMenuState)
            {
                case MenuState.Continue:
                    continueButton.IsSelected = true;
                    savesButton.IsSelected = false;
                    quitButton.IsSelected = false;
                        break;
                case MenuState.Saves:
                    continueButton.IsSelected = false;
                    savesButton.IsSelected = true;
                    quitButton.IsSelected = false;
                        break;
                case MenuState.Quit:
                    continueButton.IsSelected = false;
                    savesButton.IsSelected = false;
                    quitButton.IsSelected = true;
                    break;
            }
        }

        void MenuNavigation()
        {
            switch (CurrentMenuState)
            {
                case MenuState.Continue:
                    if (Input.GetKeyDown(InputCodes.NAVIGATE_DOWN))
                    {
                        CurrentMenuState = MenuState.Saves;
                    }
                    break;
                case MenuState.Saves:
                    if (Input.GetKeyDown(InputCodes.NAVIGATE_UP))
                    {
                        CurrentMenuState = MenuState.Continue;
                    }
                    if (Input.GetKeyDown(InputCodes.NAVIGATE_DOWN))
                    {
                        CurrentMenuState = MenuState.Quit;
                    }                    
                    break;
                case MenuState.Quit:
                    if (Input.GetKeyDown(InputCodes.NAVIGATE_UP))
                    {
                        CurrentMenuState = MenuState.Saves;
                    }
                    break;
            }
        }
    }

}
