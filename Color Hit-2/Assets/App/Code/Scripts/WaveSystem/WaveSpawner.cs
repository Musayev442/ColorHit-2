using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject squarePrefab;

    private int amount = 1;

    private int counter = 0;

    private void Start()
    {
        InvokeRepeating("Spawn", 3f, 2f);
    }

    private void Spawn()
    {
        GameObject square = Instantiate(squarePrefab, transform.position, Quaternion.identity);

        Character character = square.GetComponent<Character>();//add interface

        int rand = Random.Range(0, 4);

        character.SetColorToCharacter(rand);
        character.GetComponent<IAmountAccessable>().SetAmount(amount);

        if(counter > 10)
        {
            counter = 0;
            amount++;
        }

        counter++;
    }

}
