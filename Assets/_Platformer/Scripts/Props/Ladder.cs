using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Movement movement = other.GetComponent<Movement>();
        if (movement != null)
        {      
            movement.IsNearLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movement movement = other.GetComponent<Movement>();
        if (movement != null)
        {
            movement.IsNearLadder = false;
        }
    }
}
