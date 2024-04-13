using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] GameObject startCard;
    [SerializeField] private GameObject fightOption, itemOption, runOption;

    void Start()
    {
        startCard.GetComponent<StartcardFlip>().OnCardFlipped += ShowOptions;
    }

    void ShowOptions()
    {
        fightOption.SetActive(true);
        itemOption.SetActive(true);
        runOption.SetActive(true);
    }


}