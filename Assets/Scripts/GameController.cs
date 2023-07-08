using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Init buttons for all menu system
    public Button Button_Back_Setting, Button_Back_About;
    public Button Button_ToPlay, Button_ToAbout, Button_ToSettings, Button_Menu_Quit;

    public GameOver GameOver;

    // Start is called before the first frame update
    void Start()
    {
        InitializeGameObjectsMenu();
    }

    //Initializes and caches the buttons in Menu
    public void InitializeGameObjectsMenu()
    {

        Button_ToPlay = GameObject.Find("Button_ToPlay").GetComponent<Button>();
        Button_ToAbout = GameObject.Find("Button_ToAbout").GetComponent<Button>();
        Button_ToSettings = GameObject.Find("Button_ToSettings").GetComponent<Button>();
        Button_Menu_Quit = GameObject.Find("Button_Menu_Quit").GetComponent<Button>();

        
        Button_ToPlay.onClick.AddListener(delegate { LoadSceneByNumber(3); });
        Button_ToAbout.onClick.AddListener(delegate { LoadSceneByNumber(1); });
        Button_ToSettings.onClick.AddListener(delegate { LoadSceneByNumber(2); });
        Button_Menu_Quit.onClick.AddListener(delegate { QuitButtonCallback(); });
    }

    //initilizes the Object in the Settings screen
    public void InitializeGameObjectsSettings()
    {
        Button_Back_Setting = GameObject.Find("Button_Back_Setting").GetComponent<Button>();
        Button_Back_Setting.onClick.AddListener(delegate { LoadSceneByNumber(0); });
    }

    //Callback funtion for moving in between scenes
    //0 = menu/ 1 = about / 2 = Settings / 3 = GamePlay / 4 = GameOver
    public void LoadSceneByNumber(int SceneNumber)
    {
        Debug.Log("Scene Number index to be loaded is " + SceneNumber);
        SceneManager.LoadScene(SceneNumber);
    }

    //used for the back buttons on settings and about screen
    public void LoadSettings()
    {
        LoadSceneByNumber(3);
    }

    public void LoadAbout()
    {
        LoadSceneByNumber(2);
    }
    public void LoadMenu()
    {
        LoadSceneByNumber(0);
    }

   

    public void QuitButtonCallback()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

}
