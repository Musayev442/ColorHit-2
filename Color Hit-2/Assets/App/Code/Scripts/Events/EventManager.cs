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

    public static event UnityAction<bool> SpecialBallSpawned;

    public static void OnSpecialBallSpawned(bool isFire) => SpecialBallSpawned?.Invoke(isFire);

    public static event UnityAction<int> ScoreChanged;

    public static void OnScoreChanged(int score) => ScoreChanged?.Invoke(score);

    public static event UnityAction<bool> GameOver;

    public static void OnGameOver(bool isOver) => GameOver?.Invoke(isOver);

    public static event UnityAction AdMobLoaded;

    public static void OnAdMobLoaded() => AdMobLoaded?.Invoke();

    public static event UnityAction StopSpawning;

    public static void OnStopSpawning() => StopSpawning?.Invoke();
}
