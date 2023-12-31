using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //variables
    public BoxCollider2D grid;      //


    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function to randomize the position of the the food
    private void RandomPos()
    {
        Bounds bounds = grid.bounds;                                                //declare the limits of the space

        float x = Random.Range(bounds.min.x, bounds.max.x);                         //give a random value to x within the limit
        float y = Random.Range(bounds.min.y, bounds.max.y);                         //give a random value to y within the limit

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));           //round values, change position of the food
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomPos();
        }
    }
}


