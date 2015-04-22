using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour 
{
    public GameObject target;
    //Vector3 offset; // position relative to our view target

	// Use this for initialization
	void Start () 
    {
        // compute offset relative to target
        //offset = transform.position - target.transform.position;
        transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.position = target.transform.position + offset;
        transform.position = target.transform.position;
	}
}
