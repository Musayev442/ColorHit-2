using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Square : Character, IColorAccessible,IAmountAccessable
{
    [SerializeField] private TextMeshPro textMeshProAmount;

    private int amount = 1;    

    private void UpdateTextAmount(int amount)
    {
        textMeshProAmount.text = amount.ToString();
    }

    public void SetAmount(int amount)
    {
        this.amount = amount;
        UpdateTextAmount(amount);
    }

    public int GetColorId()
    {
        return currentColorId;
    }

    
    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            amount--;
            UpdateTextAmount(amount);
        }

        if (amount <= 0 || collision.CompareTag("Circle"))
        {
            Destroy(gameObject);
        }
    }

}
