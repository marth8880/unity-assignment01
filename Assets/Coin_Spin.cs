using UnityEngine;
using System.Collections;

public class Coin_Spin : MonoBehaviour 
{
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 rotation = new Vector3( xSpeed, ySpeed, zSpeed );
        transform.Rotate( rotation );
	}
}
