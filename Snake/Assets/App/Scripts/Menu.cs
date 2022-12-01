using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject score;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void Score()
    {
        menu.SetActive(false);
        score.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
