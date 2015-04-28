using UnityEngine;
using System.Collections;

public class Ball_Controller : MonoBehaviour
{
    public float forwardSpeed;
    public float strafeSpeed;
    public float jumpSpeed;
    bool isGrounded = true;
    float jumpControlFactor;

    public Vector3 firstCheckpoint;
    public Vector3 lastCheckpoint;
    public Vector3 newCheckpoint;

    //enum ForceMode { Acceleration };

	// Use this for initialization
	void Start() 
    {
        forwardSpeed *= 100;
        strafeSpeed *= 100;
        jumpSpeed *= 100;
        jumpControlFactor = 1;

        firstCheckpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newCheckpoint = firstCheckpoint;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
    {
        // user inputs
        if(isGrounded)
        {
            jumpControlFactor = 1;
        }
        else
        {
            jumpControlFactor = 0.5f;
        }

        float x = Input.GetAxis( "Horizontal" ) * (-strafeSpeed * Time.deltaTime) * jumpControlFactor;
        float z = Input.GetAxis( "Vertical" ) * (-forwardSpeed * Time.deltaTime) * jumpControlFactor;

        // physics horse shit
        Vector3 force = new Vector3( x, 0f, z );

        // jumping
        if( Input.GetButtonDown( "Jump" ) && (isGrounded) )
        {
            isGrounded = false;
            force.y = jumpSpeed;
        }
        force = force * 2.0f;
        rigidbody.AddForce( force );
        //rigidbody.velocity = rigidbody.velocity + rigidbody.velocity.normalized;
	}

    void OnCollisionStay( Collision collision )
    {
        if( collision.collider.CompareTag( "Ground_tag" ) )
        {
            //print( "collision enter" );
            isGrounded = true;
        }
    }

    void OnCollisionExit( Collision collision )
    {
        if( collision.collider.CompareTag( "Ground_tag" ) )
        {
            //print( "collision exit" );
            isGrounded = false;
        }
    }

    void OnTriggerEnter( Collider other )
    {
        if( other.CompareTag( "Coin_tag" ) )
        {
            other.gameObject.SetActive( false );
            ScoreTrack.Instance.AddScore(1);
        }

        if (other.CompareTag("KillZ_tag"))
        {
            LivesTrack.Instance.LoseLife(1);
        }

        if (other.CompareTag("Checkpoint_tag"))
        {
            newCheckpoint = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            lastCheckpoint = newCheckpoint;
            other.gameObject.SetActive(false);
        }
    }
}
