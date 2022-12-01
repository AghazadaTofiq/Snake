using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject score;
    [SerializeField] private TMP_Text highScoreText;

    public void Back()
    {
        menu.SetActive(true);
        score.SetActive(false);
    }
    private void Awake()
    {
        highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
