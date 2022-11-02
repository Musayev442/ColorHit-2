using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text maxScore;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("score");

        maxScore.text = "MaxScore: " + score.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
