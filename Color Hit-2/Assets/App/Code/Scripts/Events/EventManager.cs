using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction<float> RotateChanged;

    public static void OnRotateChanged(float degree) => RotateChanged?.Invoke(degree);

    public static event UnityAction<int> BallSpawned;

    public static void OnBallSpawned(int count) => BallSpawned?.Invoke(count);

    public static event UnityAction<int> AmountChanged;

    public static void OnAmountChanged(int amount) => AmountChanged?.Invoke(amount);
}
