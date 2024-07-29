using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{

    public float speed = 5;
    public Transform[] patrolPoints;
    public int patrolIndex = 0; // tracks which point the enemy is currently going

    public float waitTime = 1; // how long player waits after getting to a point
    private float currentTime = 1; // how much time has passed


    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position; // enemy will spawn at the central position
        currentTime = waitTime; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolIndex].position, speed * Time.deltaTime); // enemy spawns > move to first point

        if (transform.position != patrolPoints[patrolIndex].position) // not at that first point, don't do anything
        {
            return;
        }
        // at that point create a countdown timer 
            if (currentTime < 0) { // time < 0: move to the next point
                 patrolIndex++;

            if (patrolIndex >= patrolPoints.Length) // point > length: reset it and ... (line 40)
            {
                patrolIndex = 0;
            }
            currentTime = waitTime; // reset current time 
        }
        else
        {
            currentTime -= Time.deltaTime; // time > 0: subtratc from counter
        }
     
    }
}
