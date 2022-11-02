using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Square : Character, IColorAccessible, IAmountAccessable
{
    [SerializeField] private TextMeshPro textMeshProAmount;

    [SerializeField] private GameObject lightEffect;

    private int amount = 1;

    private void OnEnable()
    {
        EventManager.GameOver += IsGameOver;
    }

    private void OnDisable()
    {
        EventManager.GameOver -= IsGameOver;
    }

    private void IsGameOver(bool i)
    {
        Destroy(gameObject);
    }

    private void UpdateTextAmount(int amount)
    {
        textMeshProAmount.text = amount.ToString();
    }

    public void ActiveLight(bool isActive)
    {
        lightEffect.SetActive(isActive);
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
        if (collision.CompareTag("Circle"))
        {
            EventManager.OnGameOver(true);

            Destroy(gameObject);
        }
    }

    public void TakeDamage(bool isSpecial)
    {
        amount--;
        UpdateTextAmount(amount);

        if (amount <= 0 || isSpecial)
        {
            Destroy(gameObject);
        }
    }
}
