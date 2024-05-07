using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public TextMeshProUGUI SoundText;

    private void Start()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeMenu()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        Settings.SetActive(!Settings.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SoundChange(float f)
    {
        SoundText.text = $"{(int)f} %";
    }
}
