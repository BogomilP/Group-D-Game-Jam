using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayers : MonoBehaviour {

    private GameObject collided;

    public int p1Lives = 3;
    public int p2Lives = 3;

    public GameObject P1;
    public GameObject P2;
    private Vector3[] spawnPoint; 
    

    private int randomise;

    private float timeLeft = 300;

    private void Awake()
    {
        
    }

    void Start ()
    {
        spawnPoint = new[]
    {
            new Vector3(-1.941772f, 2.4f, -14.08822f),
            new Vector3(65.8f, 2.4f, -14.08822f),
            new Vector3 (65.8f, 2.4f, 56.3f),
            new Vector3 (-10, 2.4f, 56.3f)
    };
    }
	
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("TimedOut");
        }
    }


    
    void OnTriggerEnter(Collider collision)
    {
        
        collided = collision.gameObject;
        if (collided.tag == "Player1")
        {
            Debug.Log("P1Enter");
            p1Lives -= 1;
            Debug.Log("P1Lives = " + p1Lives);
            if (p1Lives > 0)
            {
                randomise = UnityEngine.Random.Range(0, spawnPoint.Length);
                P1.transform.position = spawnPoint[randomise];
            }
            if (p1Lives == 0)
            {
                Debug.Log("P1DeadScene");
            }
        }

        
        if (collided.tag == "Player2")
        {
            Debug.Log("P2Enter");
            p2Lives -= 1;
            Debug.Log("P2Lives = " + p2Lives);
            if (p2Lives > 0)
            {
                randomise = UnityEngine.Random.Range(0, spawnPoint.Length);
                P2.transform.position = spawnPoint[randomise];
            }
            if (p2Lives == 0)
            {
                Debug.Log("P2DeadScene");
            }
        }
    }
}
