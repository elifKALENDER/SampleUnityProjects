using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameSceneSwitcher : MonoBehaviour
{
    public GameObject loseUI;
    public int score;
    //public TextMeshPro scoreText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        loseUI.SetActive(false);
    }

    // Update is called once per frame
    public void LevelEnd()
    {
        loseUI.SetActive(true);
        scoreText.text= "SCORE : " + score;
    }

    public void AddScore(int pointValue) {

        score += pointValue;
        scoreText.text = "SCORE : " + score;
    }

    public void StartApp() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // i�inde bulundu�umuz sahneyi tekrar y�klemek i�in kullan�lan bir method
    }

    public void AppQuit() {

        Application.Quit();
    }
}
