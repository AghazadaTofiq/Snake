using UnityEngine;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource eat;
    [SerializeField] private TMP_Text muteText;

    private bool muted = false;

    public void Mute()
    {
        if (muted)
        {
            eat.mute = false;
            muted = false;
            muteText.text = "Mute";
        }
        else
        {
            eat.mute = true;
            muted = true;
            muteText.text = "Muted";
        }
    }

    public void Back()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
}
