using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Character
{   

    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IColorAccessible access = collision.GetComponent<IColorAccessible>();

        if (access != null)
        {
            if(this.currentColorId== access.GetColorId())
            {
                print("Color equal " + this.currentColorId);

                //add score
            }else
            {
                Time.timeScale = 0;
            }
        }

        Destroy(gameObject);
    }
}
