using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
            }
           
            return instance;
        }
    }

    public Canvas GameOverCanvas;
    public Text timePassedLabel;
    public Text creaturesKilledLabel;

    float timePassed;
    float creaturesKilled;

    bool gameStarted = false;

    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        timePassedLabel.text = timePassed.ToString();
        creaturesKilledLabel.text = creaturesKilled.ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1;

    }

    public void IncrementCreatures()
    {
        creaturesKilled++;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (gameStarted)
            timePassed += Time.deltaTime;
    }

}
