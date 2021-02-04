using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    Vector3 newPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        newPosition = new Vector3(newPosition.x - 0.005f, transform.position.y, transform.position.z);
        rigidbody.MovePosition(newPosition);
    }
}
