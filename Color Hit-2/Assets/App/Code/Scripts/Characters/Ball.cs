using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Character
{
    [SerializeField] private bool isBall;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IColorAccessible access = collision.GetComponent<IColorAccessible>();

        IAmountAccessable amountAccess = collision.GetComponent<IAmountAccessable>();

        if (access != null && !isBall)
        {
            if (this.currentColorId == access.GetColorId())
            {
                HitSquare(amountAccess, false);
            }
            else
            {
                EventManager.OnGameOver(true);
            }

            Destroy(gameObject);
        }else if(amountAccess!=null)
        {
            HitSquare(amountAccess, true);
        }

        if(collision.CompareTag("Spawner"))
        {
            Destroy(gameObject);
        }

    }

    private void HitSquare(IAmountAccessable amountAccess, bool isSpecial)
    {
        EventManager.OnScoreChanged(1);

        amountAccess.TakeDamage(isSpecial);
    }
}
