using System.Collections;
using System;
using UnityEngine;


public class StartcardFlip : MonoBehaviour
{
    public event Action OnCardFlipped;
    private SpriteRenderer rend;
    [SerializeField] private Sprite cardFront, cardBack;
    private bool hasFlipped;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = cardFront;
        hasFlipped = false;
    }

    private void Update()
    {
        if (!hasFlipped)
        {
            //if (Input.GetKeyDown(InputCodes.INTERACT_BUTTON))
            //{
            //    StartCoroutine(FlipCard());
            //}
        }
    }

    private IEnumerator FlipCard()
    {
        for (float i = 180f; i >= 0f; i -= 5f)
        {
            transform.rotation = Quaternion.Euler(i, 0f, 0f);
            transform.localScale = new Vector3(1.2f, 1f, 1f);
            if (i == 90f)
            {
                rend.sprite = cardBack;
            }
            yield return null;
        }
        hasFlipped = true;
        OnCardFlipped?.Invoke();
    }
}

