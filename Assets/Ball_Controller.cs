using UnityEngine;
using System.Collections;

public class Ball_Controller : MonoBehaviour
{
    public float forwardSpeed;
    public float strafeSpeed;

	// Use this for initialization
	void Start() 
    {
        
	}
	
	// Update is called once per frame
	void Update() 
    {
        // user inputs
        float x = Input.GetAxis( "Horizontal" );
        float z = Input.GetAxis( "Vertical" );

        // physics horse shit
        Vector3 force = new Vector3( x * -strafeSpeed, 0f, z * -forwardSpeed );
        rigidbody.AddForce( force );
	}
}
