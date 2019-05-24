using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    private float maxWidth;
    private float time = 2f;
    private GameObject newBall;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = moveWidth.x - ballWidth;
    }
    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = Random.Range(1.5f, 2.0f);
            float PosX = Random.Range(-maxWidth, maxWidth);
            Vector3 spawnPosition = new Vector3(PosX, transform.position.y, 0);
            newBall = (GameObject)Instantiate(ball, spawnPosition, Quaternion.identity);
            Destroy(newBall, 10);
        }
    }
   
}
