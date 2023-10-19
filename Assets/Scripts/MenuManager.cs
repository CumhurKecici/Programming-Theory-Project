using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settingsMenu;

    void Start()
    {
        Initiliaze();
    }

    public void StartGame()
    {
        //load game scene
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
        //save settings for persistent data
    }

    public void Back(GameObject senderMenu, GameObject targetMenu)
    {
        senderMenu.SetActive(false);
        targetMenu.SetActive(true);
    }

    private void Initiliaze()
    {
        mainMenu = GameObject.Find("MainMenu");
        settingsMenu = GameObject.Find("SettingsMenu");

        //temporary line need changes
        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(delegate { Back(settingsMenu, mainMenu); });

        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

}
