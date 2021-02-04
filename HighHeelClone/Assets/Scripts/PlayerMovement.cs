using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform leftFoots;
    public Transform rightFoots;
    public Transform left;
    public Transform right;
    Vector3 newPosition;
    Vector3 leftPosition;
    Vector3 rightPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        CreateFoots();
    }

    private void CreateFoots()
    {
        leftPosition = new Vector3(leftFoots.position.x, leftFoots.position.y - 0.125f, leftFoots.position.z);
        rightPosition = new Vector3(rightFoots.position.x, rightFoots.position.y - 0.125f, rightFoots.position.z);

        Instantiate(left, leftPosition, Quaternion.identity, leftFoots);
        Instantiate(right, rightPosition, Quaternion.identity, rightFoots);

        leftPosition = new Vector3(leftFoots.position.x, leftFoots.position.y - 0.375f, leftFoots.position.z);
        rightPosition = new Vector3(rightFoots.position.x, rightFoots.position.y - 0.375f, rightFoots.position.z);
        Instantiate(left, leftPosition, Quaternion.identity, leftFoots);
        Instantiate(right, rightPosition, Quaternion.identity, rightFoots);

        leftPosition = new Vector3(leftFoots.position.x, leftFoots.position.y - 0.625f, leftFoots.position.z);
        rightPosition = new Vector3(rightFoots.position.x, rightFoots.position.y - 0.625f, rightFoots.position.z);
        Instantiate(left, leftPosition, Quaternion.identity, leftFoots);
        Instantiate(right, rightPosition, Quaternion.identity, rightFoots);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Debug.Log(gameObject.transform.Find("LeftFoots").transform.GetChild(2));
        FootRotation();
    }

    private void FootRotation()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x - 0.15f, transform.position.y + 0.5f, transform.position.z), -Vector3.up, out hit))
        {
            if (hit.transform.tag == "Ground")
            {
                transform.Find("LeftFoots").GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                transform.Find("RightFoots").GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            transform.Find("LeftFoots").GetComponent<Transform>().rotation = Quaternion.Euler(90f, 0, 0);
            transform.Find("RightFoots").GetComponent<Transform>().rotation = Quaternion.Euler(-90f, 0, 0);
        }
    }

    private void Move()
    {
        newPosition = new Vector3(newPosition.x - 0.005f, transform.position.y, transform.position.z);
        rigidbody.MovePosition(newPosition);
    }
}
