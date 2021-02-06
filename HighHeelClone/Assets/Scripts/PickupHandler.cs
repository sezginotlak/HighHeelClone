using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    public Transform leftFoots;
    public Transform rightFoots;
    public Transform left;
    public Transform right;
    Vector3 leftPosition;
    Vector3 rightPosition;

    private void Start()
    {
        leftFoots = GameObject.FindGameObjectWithTag("Player").transform.Find("LeftFoots");
        rightFoots = GameObject.FindGameObjectWithTag("Player").transform.Find("RightFoots");
    }

    private void Update()
    {
        GetPosition();
    }
    public void CreateFoots()
    {
        if (leftFoots.childCount == 0)
        {
            leftPosition = new Vector3(leftFoots.position.x, leftFoots.position.y - 0.125f, leftFoots.position.z);
            rightPosition = new Vector3(rightFoots.position.x, rightFoots.position.y - 0.125f, rightFoots.position.z);
        }
        else
        {
            leftPosition = new Vector3(leftFoots.position.x, leftFoots.GetChild(leftFoots.childCount - 1).position.y - 0.25f, leftFoots.position.z);
            rightPosition = new Vector3(rightFoots.position.x, rightFoots.GetChild(rightFoots.childCount - 1).position.y - 0.25f, rightFoots.position.z);
        }

        Instantiate(left, leftPosition, Quaternion.identity, leftFoots);
        Instantiate(right, rightPosition, Quaternion.identity, rightFoots);
    }

    private void GetPosition()
    {
        leftPosition = leftFoots.position;
        rightPosition = rightFoots.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Foot")
        {
            Destroy(gameObject);
            CreateFoots();
        }
    }
}
