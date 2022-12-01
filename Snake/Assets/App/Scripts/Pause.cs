using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Awake()
    {
        highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
