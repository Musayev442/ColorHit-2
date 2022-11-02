using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    
    [SerializeField] private TMP_Text textMeshProScore;
    [SerializeField] private Text textMeshProLosePanelScore;

    [SerializeField] private Text textMeshProMaxScore;

    [SerializeField] private Button fireButton;
    [SerializeField] private Button iceButton;

    private float timeToWait = 50f;

    // reference to the coroutine that toggles our button
    private Coroutine buttonDisabled = null;

    private int maxScore;

    private int score;

    private void Start()
    {     

        SetScoreToText(0);
        
    }

    private void OnEnable()
    {
        EventManager.ScoreChanged += SetScoreToText;

        EventManager.GameOver += LosePanel;
    }

    private void OnDisable()
    {
        EventManager.ScoreChanged -= SetScoreToText;

        EventManager.GameOver -= LosePanel;
    }

    public void SetMaxScoreToText(int score)
    {

        if (score>maxScore)
        {
            PlayerPrefs.SetInt("score", score);
        }

        maxScore = PlayerPrefs.GetInt("score");

        textMeshProMaxScore.text = "MaxScore: " + maxScore.ToString();
    }

    public void SetScoreToText(int score)
    {
        this.score += score;

        textMeshProScore.text = "Score: " + this.score.ToString();

        SetMaxScoreToText(this.score);
    }

    public void RotateCircle(int degree)
    {
        EventManager.OnRotateChanged(degree);
    }

    public void ShootButton(int count)
    {
        SoundManager.Instance.Play("Shoot");

        EventManager.OnBallSpawned(count);
    }

    public void SpecialShootButton(bool isFire)
    {
        EventManager.OnSpecialBallSpawned(isFire);
        
        Button tmpBtn;

        if (isFire)
        {
            tmpBtn = fireButton;
        }
        else
        {
           tmpBtn = iceButton;
        }

        buttonDisabled = StartCoroutine(DisableButtonForSeconds(tmpBtn));
    }


    private IEnumerator DisableButtonForSeconds(Button btn)
    {
        SoundManager.Instance.Play("SpellShoot");
        // disable the button 
        btn.interactable = false;

        // wait for our amount of time to re-enable
        yield return new WaitForSeconds(timeToWait);

        // re-enable the button
        btn.interactable = true;

        // reset our reference to be called again
        buttonDisabled = null;
    }

    public void LosePanel(bool isActive)
    {

        textMeshProLosePanelScore.text= "Score: " + this.score.ToString();

        losePanel.SetActive(isActive);

        EventManager.OnStopSpawning();

        //EventManager.OnAdMobLoaded();

        Time.timeScale = 0;
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
