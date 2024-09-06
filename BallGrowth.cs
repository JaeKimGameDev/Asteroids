using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrowth : MonoBehaviour
{
    public GameObject ball;
    Vector2 temp;

    // Start is called before the first frame update
    void Start()
    {

        ball = GetComponent<Deploy_Balls>().ballPrefab;
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (Input.touches[i].phase == TouchPhase.Began || Input.touches[i].phase == TouchPhase.Moved)
                {
                    temp = hit.collider.gameObject.transform.localScale;
                    FindObjectOfType<AudioManager>().Play("Grow");
                    
                    //Increase/increment x and y value, Time.deltaTime makes for a smoother transition for ball growth
                    temp.x += Time.deltaTime * .25f;
                    temp.y += Time.deltaTime * .25f;

                    hit.collider.gameObject.transform.localScale = temp;

                }
            }
        }
    }
}