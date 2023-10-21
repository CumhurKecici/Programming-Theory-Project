using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settingsMenu;

    void Awake()
    {
        Initiliaze();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveSettings()
    {
        DataAccess.Settings.PlayerName = GameObject.Find("textbox_Playername").GetComponent<InputField>().text;
        DataAccess.Settings.BackgroundMusicVolume = GameObject.Find("slider_BackgroundMusicVolume").GetComponent<Slider>().value;
        DataAccess.SaveSettings();
    }

    public void Back(GameObject senderMenu, GameObject targetMenu)
    {
        DataAccess.LoadSettings();
        ApplySettings();
        senderMenu.SetActive(false);
        targetMenu.SetActive(true);
    }

    private void Initiliaze()
    {
        ApplySettings();

        mainMenu = GameObject.Find("MainMenu");
        settingsMenu = GameObject.Find("SettingsMenu");

        //temporary line need changes
        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(delegate { Back(settingsMenu, mainMenu); });



        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    private void ApplySettings()
    {
        DataAccess.LoadSettings();
        GameObject.Find("textbox_Playername").GetComponent<InputField>().text = DataAccess.Settings.PlayerName;
        GameObject.Find("slider_BackgroundMusicVolume").GetComponent<Slider>().value = DataAccess.Settings.BackgroundMusicVolume;
    }

    public void OnBackgroundMusicVolume_Changed()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = GameObject.Find("slider_BackgroundMusicVolume").GetComponent<Slider>().value;
    }

}
