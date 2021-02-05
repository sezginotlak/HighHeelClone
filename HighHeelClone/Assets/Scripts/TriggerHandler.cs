using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Finish"))
        {
            int index = transform.GetSiblingIndex();
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            for (int i = index; i < transform.parent.childCount; i++)
            {
                Destroy(transform.parent.GetChild(index).gameObject, 0.5f);
                Destroy(transform.parent.parent.Find("RightFoots").GetChild(index).gameObject, 0.5f);
            }
        }
    }
}
