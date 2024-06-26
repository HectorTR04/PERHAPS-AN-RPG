using UnityEngine;
using Assets.Scripts.Globals;
using Assets.Scripts.CombatUI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject startCard;
    [SerializeField] private OptionCard fightOption, itemOption, runOption;
    enum CombatState { PlayerTurn, Fighting, UsingItem, Escaping, EnemyTurn }
    CombatState CurrentCombatState;
    enum PlayerChoice { Fight, UseItem, Escape }
    PlayerChoice CurrentPlayerChoice;
    
    void Start()
    {
        startCard.GetComponent<StartcardFlip>().OnFlipped += ShowOptions;
        fightOption.gameObject.SetActive(false);
        itemOption.gameObject.SetActive(false);
        runOption.gameObject.SetActive(false);
    }

    private void Update()
    {
        switch(CurrentCombatState)
        {
            case CombatState.PlayerTurn:
                PlayerTurn();
                break;
        }
    }

    void ShowOptions()
    {
        CurrentCombatState = CombatState.PlayerTurn;
        fightOption.gameObject.SetActive(true);
        itemOption.gameObject.SetActive(true);
        runOption.gameObject.SetActive(true);
    }

    void PlayerTurn()
    {      
        switch (CurrentPlayerChoice)
        {
            case PlayerChoice.Fight:
                FightChoice();
                //fightOption.GetComponent<StartcardFlip>().OnFlipped += TransitionToFighting;
                break;
            case PlayerChoice.UseItem:
                ItemChoice();
                break;
            case PlayerChoice.Escape:
                EscapeChoice();
                break;
        }

    }

    void FightChoice()
    {
        if (Input.GetKeyDown(InputCodes.NAVIGATE_RIGHT))
        {
            CurrentPlayerChoice = PlayerChoice.UseItem;
        }
        fightOption.IsSelected = true;
        itemOption.IsSelected = false;
        runOption.IsSelected = false;
        //logic to attack enemy
    }

    void ItemChoice()
    {
        if (Input.GetKeyDown(InputCodes.NAVIGATE_RIGHT))
        {
            CurrentPlayerChoice = PlayerChoice.Escape;
        }
        if (Input.GetKeyDown(InputCodes.NAVIGATE_LEFT))
        {
            CurrentPlayerChoice = PlayerChoice.Fight;
        }
        fightOption.IsSelected = false;
        itemOption.IsSelected = true;
        runOption.IsSelected = false;
        //logic to apply item
    }

    void EscapeChoice()
    {
        if (Input.GetKeyDown(InputCodes.NAVIGATE_LEFT))
        {
            CurrentPlayerChoice = PlayerChoice.UseItem;
        }
        fightOption.IsSelected = false;
        itemOption.IsSelected = false;
        runOption.IsSelected = true;
        //logic to leave combat
    }

    void TransitionToFighting()
    {
        CurrentCombatState = CombatState.Fighting;

    }


}