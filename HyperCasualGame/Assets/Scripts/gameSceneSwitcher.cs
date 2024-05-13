using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameSceneSwitcher : MonoBehaviour
{
    public GameObject loseUI;    
    public GameObject winUI;    
    //public GameObject mainUI;    
    public int score;
    //public TextMeshPro scoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI inGameScoreText;  
    


    void Start()
    {
        //SceneSwitcher();
        loseUI.SetActive(false);              
        winUI.SetActive(false);              
        
    }

    // Update is called once per frame
    public void LevelEnd()
    {
        loseUI.SetActive(true);
        scoreText.text= "SCORE : " + score;
        inGameScoreText.gameObject.SetActive(false);
    }

    public void WinLevel() {

        winUI.SetActive(true);
        scoreText1.text = "SCORE : " + score;
        inGameScoreText.gameObject.SetActive(false);
        //loseUI.SetActive(false);
    }

    public void NextLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AddScore(int pointValue) {

        score += pointValue;
        inGameScoreText.text = "SCORE : " + score; 
    }

    public void StartApp() {

        SceneManager.LoadScene(1);//SceneManager.GetActiveScene().name); // içinde bulunduðumuz sahneyi tekrar yüklemek için kullanýlan bir method
    }
    //public void SceneSwitcher() {
    //    if (loseUI == null) {
    //        mainUI.SetActive(false);
    //        SceneManager.LoadScene(1);
    //    }
    //}

    public void AppQuit() {

        Application.Quit();
    }
}
