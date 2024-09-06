using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Ball Properties
    public GameObject[] ballList;
    public GameObject ballPrefab;
    public Collider2D touchedObject;

    // Makes sure each level starts with a local score of 0
    public float localLevelScore = 0.0f;

    // Print these on canvas
    public TextMeshProUGUI levelLeft, levelRight;
    public TextMeshProUGUI scoreTop, scoreBottom;
    public TextMeshProUGUI timeLeftTop, timeLeftBottom;
    public TextMeshProUGUI livesBottom, livesTop;

    // Used for ball spawning inside the boundaries
    private float width = Screen.width - 100;
    private float height = Screen.height - 100;
    private float x;
    private float y;
    public GameObject spawnArea;
    private BoxCollider areaCol;
    private Bounds bounds;
    private Vector2 screenBounds;
    Vector2 temp;

    void Awake()
    {
        areaCol = spawnArea.GetComponent<BoxCollider>();

        bounds = areaCol.bounds;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(width, height, Camera.main.transform.position.z));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get required information that always saves data (DON'T DESTROY ON LOAD)
        GameDataTracker getData = Object.FindFirstObjectByType<GameDataTracker>();

        // Using that saved data, set up player life
        livesBottom.text = "" + getData.PlayerLives;
        livesTop.text = "" + getData.PlayerLives;

        // Using that saved data, set up Text for left/right level
        levelLeft.text = "" + getData.gameLevel;
        levelRight.text = "" + getData.gameLevel;

        // Using that saved data, make an array
        ballList = new GameObject[getData.numberOfBalls];

        // Spawn balls and add it to the array, based on saved data
        for (int i = 0; i < getData.numberOfBalls; i++)
        {
            x = Random.Range(bounds.min.x, bounds.max.x);
            y = Random.Range(bounds.min.y, bounds.max.y);
            Vector2 randomPosition = new Vector2(x, y);
            Vector2 testPos = new Vector2(x, y);
            GameObject ball = Instantiate(ballPrefab, randomPosition, Quaternion.identity);
            ball.tag = "CircleBall";
            ballList[i] = ball;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Call upon saved data once again
        GameDataTracker getData = Object.FindFirstObjectByType<GameDataTracker>();

        // Get timer, and start counting down
        getData.timer -= Time.deltaTime;
        timeLeftBottom.text = ("" + getData.timer.ToString("F2"));
        timeLeftTop.text = ("" + getData.timer.ToString("F2"));

        // If timer gets to 0, load scene GAME OVER
        if (getData.timer <= 0)
        {
            if (getData.PlayerLives <= 1)
            {
                SceneManager.LoadScene("GameOver");
            }
            getData.PlayerLives -= 1;
            SceneManager.LoadScene("LostLifeClassicLevel");
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            // Confirms user touches an object
            if (hit.collider != null)
            {
                // Checks if object touched is "CircleBall"
                if (hit.collider.tag == "CircleBall")
                {
                    // goes through each list and checks if users touched object touches any object inside the array
                    foreach (GameObject singleBall in ballList) 
                    {
                        touchedObject = hit.collider;
                        if (touchedObject.IsTouching(singleBall.GetComponent<CircleCollider2D>()))
                        {
                            if (getData.PlayerLives <= 0)
                            {
                                SceneManager.LoadScene("GameOver");
                            }
                            else
                            {
                                getData.PlayerLives -= 1;
                                SceneManager.LoadScene("LostLifeClassicLevel");
                            }
                        }
                    }
                    
                    temp = hit.collider.transform.localScale;

                    //Increase/increment x and y value, Time.deltaTime makes for a smoother transition for ball growth
                    temp.x += Time.deltaTime * 2.0f;
                    temp.y += Time.deltaTime * 2.0f;

                    hit.collider.transform.localScale = temp;
                }
                localLevelScore += Time.deltaTime * 5;
                scoreTop.text = ("" + localLevelScore.ToString("F0"));
                scoreBottom.text = ("" + localLevelScore.ToString("F0"));
                if (localLevelScore >= 100)
                {
                    SceneManager.LoadScene("IntermissionClassicLevel");
                }
            }
        }
    }
}
