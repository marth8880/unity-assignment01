using UnityEngine;
using System.Collections;

public class Moving_Platform_Magnet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Moving_Platform_Magnet: player has been parented");
            other.transform.parent = transform.parent;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Moving_Platform_Magnet: player has been unparented");
            other.transform.parent = null;
        }
    }
}