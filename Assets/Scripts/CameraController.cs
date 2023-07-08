using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController Player;
   
    // Update is called once per frame
    void Update()
    {
        //sets the camera to move consistently to the right as the update method gets called
        //Changes speed based on the current score of the game. The exact number for the increases and the speed when it is increased can be looked at
        if(PlayerSettings.Instance.score < 20 && !PlayerSettings.Instance.GameOver)
        {
            transform.position += new Vector3(.01f + Time.deltaTime, 0, 0);
        }
        else if (PlayerSettings.Instance.score < 40 && !PlayerSettings.Instance.GameOver)
        {
            transform.position += new Vector3(.012f + Time.deltaTime, 0, 0);
        }
        else if(!PlayerSettings.Instance.GameOver) transform.position += new Vector3(.015f + Time.deltaTime, 0, 0);

        


        
    }
}
 