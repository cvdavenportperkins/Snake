using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 direction;              //control direction of movement

    List<Transform> segments;               //varianble to store all the parts of the body of the snake
    public Transform bodyPrefab;            //variable to store the body
      
    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform> ();  //create new list
        segments.Add(transform);           //add head of the sanke to the list
    }

    // Update is called once per frame
    void Update()
    {
        //change direction of the snake
        if (Input.GetKeyDown(KeyCode.W))    //when W key is pressed
        {
            direction = Vector2.up;         //go up
        }

        if (Input.GetKeyDown(KeyCode.A))    //when A key is pressed
        {
            direction = Vector2.left;       //go left
        }

        if (Input.GetKeyDown(KeyCode.S))    //when S key is pressed
        {
            direction = Vector2.down;       //go down
        }

        if (Input.GetKeyDown(KeyCode.D))    //when D key is pressed
        {
            direction = Vector2.right;      //go right
        }
    }

    //FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        //move the body of the snake
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        //to move the snake
        this.transform.position = new Vector2(                      //get the postion
            Mathf.Round(this.transform.position.x) + direction.x,   //round the number add the value to x
            Mathf.Round(this.transform.position.y) + direction.y    //round the number add the value to y
            );
    }

    //Function top make the snake grow
    void Grow()
    {
        Transform segment = Instantiate(this.bodyPrefab);                  //create a new bpdy part
        segment.position = segments[segments.Count - 1].position;          //add it to the back of the snake
        segments.Add(segment);                                             //add it to the list
    }

    //Function for collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "Obstacle")
        { Debug.Log("Hit");
        }
    }
}

