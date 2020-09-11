using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_HighscoreText;

    void Start()
    {
        m_HighscoreText.text = "Your Highscore is: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    public void Start_Clicked()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void HowTo_Clicked()
    {

    }

    public void Quit_Clicked()
    {
        Application.Quit();
    }
}
