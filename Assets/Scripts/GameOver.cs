using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text ScoreText;
    
    public void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        
        ScoreText.text = "Score = " + PlayerSettings.Instance.score.ToString(); 

       
        
    }
}
