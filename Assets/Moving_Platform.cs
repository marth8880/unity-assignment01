using UnityEngine;
using System.Collections;

public class Moving_Platform : MonoBehaviour
{
    public float xMoveSpeed;
    public float yMoveSpeed;
    public float zMoveSpeed;
    public float maxDistance;
    private float minDistance;
    private float distanceLimit;
    private float currentPosition;
    private bool movingPositive;

	// Use this for initialization
	void Start ()
    {
        minDistance = transform.position.y;
        distanceLimit = minDistance + maxDistance;
        movingPositive = true;

        xMoveSpeed *= 0.1f;
        yMoveSpeed *= 0.1f;
        zMoveSpeed *= 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentPosition = transform.position.y;

        if (movingPositive)
        {
            transform.Translate(xMoveSpeed, yMoveSpeed, zMoveSpeed);
            
            if (currentPosition >= distanceLimit)
            {
                print("Moving_Platform: changing direction, now moving downwards");
                movingPositive = false;
            }
        }
        else
        {
            transform.Translate(-xMoveSpeed, -yMoveSpeed, -zMoveSpeed);

            if (currentPosition <= minDistance)
            {
                print("Moving_Platform: changing direction, now moving upwards");
                movingPositive = true;
            }
        }
	}
}
