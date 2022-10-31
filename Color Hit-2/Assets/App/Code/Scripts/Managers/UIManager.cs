using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void RotateCircle(int degree)
    {
        EventManager.OnRotateChanged(degree);
    }

    public void ShootButton(int count)
    {
        EventManager.OnBallSpawned(count);
    }
}
