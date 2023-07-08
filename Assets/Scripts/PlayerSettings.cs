using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings Instance;
    //settings to be saved, Player name, ColorCode for the player sprite color as a string, and GameDifficulty as an int
    public string PlayerName;
    public int color;
    public int GameDifficulty;
    public int score;
    public bool GameOver = false;
    
    //If there is no instance of this class it is created on awake 
    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("HERE");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
