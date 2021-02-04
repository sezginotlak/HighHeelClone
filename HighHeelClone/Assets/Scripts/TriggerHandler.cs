using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 0.6f);
            Debug.Log("Triggered!");
        }
    }
}
