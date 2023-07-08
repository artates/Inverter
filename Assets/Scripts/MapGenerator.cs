using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    //UI Elements
    public Text ScoreText;
    
    //game objects needed for generating floor and ceiling
    public GameObject CeilingPrev;
    public GameObject FloorPrev;
    public GameObject Floor;
    public GameObject Ceiling;

    public GameObject Player;

    //init obstacle
    public GameObject ObstaclePrefab;
    
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    

    //obstacle spacing and size variables
    //Some of these set in inspector
    public float minObstacleY = -4;
    public float maxObstacleY =5;
    
    public float minObstacleScaleY;
    public float maxObstacleScaleY;

    public float minObstacleScaleX;
    public float maxObstacleScaleX;

    public float minObstacleSpacing;
    public float maxObstacleSpacing;
    

    

    // Start is called before the first frame update
    void Start()
    {
        //sets GameOver to false on game start
        PlayerSettings.Instance.GameOver = false;
        
        //Code for the score, Initializes it and sets the on screen Score text to the value
        PlayerSettings.Instance.score = 0;
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        ScoreText.text = "Score: " + PlayerSettings.Instance.score;
        

        //inits the game objects for the map
        CeilingPrev = GameObject.Find("CeilingPrev");
        FloorPrev = GameObject.Find("FloorPrev");
        Floor = GameObject.Find("Floor");
        Ceiling = GameObject.Find("Ceiling");
        Player = GameObject.Find("Player");

        //code for obstacles
        //ObstaclePrefab = GameObject.Find("Obstacle");
        obstacle1 = GenerateObstacle(Player.transform.position.x + 10);
        obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
        obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
        obstacle4 = GenerateObstacle(obstacle3.transform.position.x);

        //add code here for min/max object spacing being different on different difficulty settings
        //changes spacing for medium difficulty
        if(PlayerSettings.Instance.GameDifficulty == 1)
        {
            minObstacleSpacing = 3;
            maxObstacleSpacing = 8;
        }

        //changes spacing for hard difficulty
        if (PlayerSettings.Instance.GameDifficulty == 2)
        {
            minObstacleSpacing = 1;
            maxObstacleSpacing = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x > Floor.transform.position.x)
        {
            var TempFloor = FloorPrev;
            var TempCeiling = CeilingPrev;
            CeilingPrev = Ceiling;
            FloorPrev = Floor;
            TempCeiling.transform.position += new Vector3(80, 0, 0);
            TempFloor.transform.position += new Vector3(80, 0, 0);
            Ceiling = TempCeiling;
            Floor = TempFloor;
            PlayerSettings.Instance.score++;
            ScoreText.text = "Score: " + PlayerSettings.Instance.score;
            Debug.Log(PlayerSettings.Instance.score);
        }

        //updates for obstacles
        if(Player.transform.position.x > obstacle2.transform.position.x)
        {
            
            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;
            SetTransform(tempObstacle, obstacle3.transform.position.x);
            obstacle4 = tempObstacle;
        }

    }

    //method instantiates and obstacle. Takes an x reference for spacing between other obstacles
    GameObject GenerateObstacle(float xRef)
    {
        GameObject obstacle = GameObject.Instantiate(ObstaclePrefab);
        SetTransform(obstacle, xRef);
        return obstacle;
    }

    //set transform to adjust stats of obstacles as the game runs
    void SetTransform(GameObject obstacle,float xRef)
    {
        obstacle.transform.position = new Vector2(xRef + 10f + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY));
        obstacle.transform.localScale = new Vector2(Random.Range(minObstacleScaleX, maxObstacleScaleX), Random.Range(minObstacleScaleY, maxObstacleScaleY));
    }
}
