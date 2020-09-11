using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_CurrentScoreText;
    [SerializeField]
    private TextMeshProUGUI m_BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBestScore();
    }

   

    public void UpdateCurrentScore(int i_CurrentScore)
    {
        m_CurrentScoreText.text = "Strokes:" + i_CurrentScore;
    }
    public void UpdateBestScore()
    {
        m_BestScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        UpdateBestScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
