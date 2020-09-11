using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour
{
    public StrokeManager StrokeCounter;

    [SerializeField]
    private UI_Manager m_UIManager;

    [SerializeField]
    private AudioManager m_AudioManager;

    private void OnTriggerEnter(Collider other)
    {
        m_AudioManager.Play("BallInHole");
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        int currentScore = StrokeCounter.m_NumberOfStrokes;
        if(currentScore < highScore || highScore == 0)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            m_UIManager.UpdateBestScore();
        }

        StartCoroutine(Waiter());
        
    }

    private IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenuScene");

    }




   

}
