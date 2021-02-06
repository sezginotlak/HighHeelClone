using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedWithPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<GameController>().isCollided = true;
        }
    }
}
