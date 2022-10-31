using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private float shootDelay;

    [SerializeField] private Transform shootTransform;

    private int currentColorId;

    private Ball ballRef;


    private void OnEnable()
    {
        EventManager.BallSpawned += SpawnBall;
    }

    private void OnDisable()
    {
        EventManager.BallSpawned -= SpawnBall;
    }

    private void SpawnBall(int count)
    {
        StartCoroutine(ISpawnBallCoroutine(count));
    }

    private IEnumerator ISpawnBallCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject ball = Instantiate(ballPrefab, shootTransform.position, Quaternion.identity);

            ballRef = ball.GetComponent<Ball>();

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
