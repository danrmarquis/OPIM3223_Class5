using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;

    private Rigidbody rigidBody;
    private KeyCode[] inputKeys;
    //the [] is an array
    private Vector3[] keyDirections;
    //Vector is speed and direction

    //Start is called before the first frame update
    //As soon as project is loaded this script is ran
    //We want to know which direction we want to move, with the keys we want to move us
    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        //declaring which keys will be captured for input
        keyDirections = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
        //getting rigidbody values for the object this script is on
    }

    // Update is called once per frame
    //difference between Update and FixedUpdate, updates for a fixed amount of frames
    void FixedUpdate()
    {
        for (int i = 0; i< inputKeys.Length; i++)
        {
            var currentKey = inputKeys[i];

            {
                Vector3 move = keyDirections[i] * acceleration * Time.deltaTime;
                //Creates new Vector3 variable called "move"
                //pick direction based on key, 
                movePlayer(move);
            }
        }
    }


    void movePlayer(Vector3 movement)
    {
        if (rigidBody.velocity.magnitude * acceleration > maxSpeed)
        {
            rigidBody.AddForce(movement * -1);

        }
        else
        {
            rigidBody.AddForce(movement);
        }
    }


}
