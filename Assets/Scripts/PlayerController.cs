using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    public GameController GameController;

    //code for switching the color of the player sprite
    private Renderer rend;
    private Color newColor = Color.red;
    

    //public bool GameOver = false;//var for checking if the game is over
    // Start is called before the first frame update
    void Start()
    {
        //Code for switching the color
        //switches the new color var based on player settings default red
        if (PlayerSettings.Instance.color == 0)
        {
            newColor = Color.red;
           
        }
        else if (PlayerSettings.Instance.color == 1)
        {
            newColor = Color.cyan;
            
            
        }
        else if (PlayerSettings.Instance.color == 2)
        {
            
            newColor = Color.magenta;
            
        }

        //instantiates and uses renderer to Change sprite color
        rend = GetComponent<Renderer>();
        rend.material.color = newColor;

        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            body.AddForce(new Vector2(0, 45), ForceMode2D.Force);
        }
        else body.AddForce(new Vector2(0, -10), ForceMode2D.Force);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSettings.Instance.GameOver = true;
        body.isKinematic = true;
        SceneManager.LoadScene(4);
    }
}
