using System.Collections;
using System;
using Assets.Scripts.Globals;
using UnityEngine;
using Assets.Scripts.Interfaces;

public class StartcardFlip : MonoBehaviour, IFlippable
{
    public event Action OnFlipped;

    private SpriteRenderer rend;
    [SerializeField] private Sprite cardFront, cardBack;

    bool IFlippable.IsFlipped { get; set; }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = cardFront;
        ((IFlippable)this).IsFlipped = false;
    }

    private void Update()
    {
        if (!((IFlippable)this).IsFlipped)
        {
            if (Input.GetKeyDown(InputCodes.INTERACT_BUTTON))
            {
                StartCoroutine(Flip());
            }
        }
    }

    public IEnumerator Flip()
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
        ((IFlippable)this).IsFlipped = true;
        OnFlipped?.Invoke();
    }
}
