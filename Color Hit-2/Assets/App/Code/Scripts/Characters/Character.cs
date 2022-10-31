using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int currentColorId;

    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected SpriteRenderer spriteRenderer;

    [SerializeField] protected float speed;

    [SerializeField] protected Color[] hitColors;


    public void SetColorToCharacter(int colorId)
    {
        currentColorId = colorId;

        spriteRenderer.color = hitColors[colorId];
    }

}
