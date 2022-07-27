using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;


    //bool endGame = false;

    int currentScore, score;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentScore = 0;
        GuiManager.instance.currentScoreText.text = "0";
        GuiManager.instance.BestScoreValueText.text = PlayerPrefs.GetInt("Best").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        currentScore = (int)player.transform.position.y;
        if (currentScore > score)
        {
            score = currentScore;
        }
        GuiManager.instance.currentScoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Best",0))
        {
            GuiManager.instance.BestScoreValueText.text = score.ToString();
            PlayerPrefs.SetInt("Best", score);
        }
    }

    public void Resume()
    {

    }

    public void Restart()
    {
        GuiManager.instance.BestScorePanel.SetActive(false);
        GuiManager.instance.currentScoreText.gameObject.SetActive(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        GuiManager.instance.yourScoreValueText.text = score.ToString();
        GuiManager.instance.BestScorePanel.SetActive(true);
        GuiManager.instance.currentScoreText.gameObject.SetActive(false);

        Invoke( "Pause" , 1f);
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    public void OnOpenShop()
    {
        GuiManager.instance.ShopPanel.SetActive(true);
    }
    public void OnCloseShop()
    {
        GuiManager.instance.ShopPanel.SetActive(false);
    }

}
