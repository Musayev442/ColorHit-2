using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private GameObject fireBallPrefab;

    [SerializeField] private GameObject iceBallPrefab;

    [SerializeField] private float shootDelay;

    [SerializeField] private Transform shootTransform;

    private int currentColorId;

    private Character ballRef;


    private void OnEnable()
    {
        EventManager.BallSpawned += SpawnBall;
        EventManager.SpecialBallSpawned += SpawnSpecialBall;
    }

    private void OnDisable()
    {
        EventManager.BallSpawned -= SpawnBall;
        EventManager.SpecialBallSpawned -= SpawnSpecialBall;

    }

    private void SpawnBall(int count)
    {
        StartCoroutine(ISpawnBallCoroutine(count));
    }

    private void SpawnSpecialBall(bool isFire)
    {
        if(isFire)
        {
            GameObject specialBall = Instantiate(fireBallPrefab, shootTransform.position, Quaternion.identity);
        }else
        {
            GameObject specialBall = Instantiate(iceBallPrefab, shootTransform.position, Quaternion.identity);
        }

    }
    
    private IEnumerator ISpawnBallCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject ball = Instantiate(ballPrefab, shootTransform.position, Quaternion.identity);

            ballRef = ball.GetComponent<Character>();

            ballRef.SetColorToCharacter(currentColorId);

            yield return new WaitForSeconds(shootDelay);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IColorAccessible selectedColor = collision.GetComponent<IColorAccessible>();

        if (selectedColor != null)
        {
            currentColorId = selectedColor.GetColorId();
        }

    }

}
