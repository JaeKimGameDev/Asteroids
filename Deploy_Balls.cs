using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy_Balls : MonoBehaviour
{
    public GameObject ballPrefab;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-60, Screen.height-50, Camera.main.transform.position.z));

        for (int i=0; i < 4; i++)
        {
            SpawnBall();
        }
        
    }
    private void SpawnBall()
    {
        GameObject b = (GameObject)Instantiate(ballPrefab);
        b.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));

    }

    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                transform.localScale += new Vector3(0.00000001f, 0.00000001f, 0);
            }
        }
        
    }
    */
}
