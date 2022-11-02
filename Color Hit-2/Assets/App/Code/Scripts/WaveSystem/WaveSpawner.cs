using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject squarePrefab;

    private int amount = 1;

    private int bossAmount = 5;
    private int regularAmount = 1;


    private int counter = 1;

    private void OnEnable()
    {
        EventManager.StopSpawning += StopInvokeRepeating;
    }

    private void OnDisable()
    {
        EventManager.StopSpawning -= StopInvokeRepeating;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 3f, 2f);
    }

    private void StopInvokeRepeating()
    {
        Destroy(gameObject);
    }

    private void Spawn()
    {
        GameObject square = Instantiate(squarePrefab, transform.position, Quaternion.identity);

        Square character = square.GetComponent<Square>();

        int rand = Random.Range(0, 4);

        character.SetColorToCharacter(rand);

        IAmountAccessable access = character.GetComponent<IAmountAccessable>();


        if (counter == 10)
        {
            amount = bossAmount += 5;
            counter = 1;

            regularAmount++;

            character.ActiveLight(true);

            access.SetAmount(amount);
        }else
        {
            amount = regularAmount;
            access.SetAmount(amount);
        }
        counter++;

    }

}
