using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettingsController : MonoBehaviour
{
    public InputField PlayerNameInputField;
    public Button PlayerColorButtonRed, PlayerColorButtonBlue, PlayerColorButtonMagenta, Button_Back_Setting;
    public Dropdown GameDifficultyDropdown;
    // Start is called before the first frame update
    void Start()
    {
        PlayerNameInputField = GameObject.Find("PlayerNameInputField").GetComponent<InputField>();
        PlayerColorButtonRed = GameObject.Find("PlayerColorButtonRed").GetComponent<Button>();
        PlayerColorButtonBlue = GameObject.Find("PlayerColorButtonBlue").GetComponent<Button>();
        PlayerColorButtonMagenta = GameObject.Find("PlayerColorButtonMagenta").GetComponent<Button>();
        GameDifficultyDropdown = GameObject.Find("GameDifficultyDropdown").GetComponent<Dropdown>();

        Button_Back_Setting = GameObject.Find("Button_Back_Setting").GetComponent<Button>();

        PlayerColorButtonRed.onClick.AddListener(delegate { PlayerColorButtonRed_Callback(); });
        PlayerColorButtonBlue.onClick.AddListener(delegate { PlayerColorButtonBlue_Callback(); });
        PlayerColorButtonMagenta.onClick.AddListener(delegate { PlayerColorButtonMagenta_Callback(); });
        Button_Back_Setting.onClick.AddListener(delegate { Button_Back_Setting_Callback(); });

        //everytime we come to this screen this will set the player name and teh difficulty settings to the previously set values
        PlayerNameInputField.text = PlayerSettings.Instance.PlayerName;
        GameDifficultyDropdown.value = PlayerSettings.Instance.GameDifficulty;

    }

    //button callbacks
    //Red = 0 //Blue = 1 // Magenta = 2
    public void PlayerColorButtonRed_Callback()
    {
        PlayerSettings.Instance.color = 0;
        
    }
    public void PlayerColorButtonBlue_Callback()
    {
        PlayerSettings.Instance.color = 1;
        
    }
    public void PlayerColorButtonMagenta_Callback()
    {
        PlayerSettings.Instance.color = 2;
        
    }
    //callback for the back button saves the player name and GameDifficulty to singleton
    public void Button_Back_Setting_Callback()
    {
        PlayerSettings.Instance.PlayerName = PlayerNameInputField.text;
        PlayerSettings.Instance.GameDifficulty = GameDifficultyDropdown.value;
        Debug.Log(PlayerSettings.Instance.PlayerName);
        Debug.Log(PlayerSettings.Instance.GameDifficulty);
        Debug.Log(PlayerSettings.Instance.color);
    }

}
