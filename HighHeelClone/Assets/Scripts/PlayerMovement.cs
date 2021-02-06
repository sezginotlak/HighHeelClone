using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    private Touch touch;
    private float speedModifier;
    public bool isGameStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) isGameStarted = true;
        if (isGameStarted)
        {
            if (Input.touchCount > 0)
            {
                DragControl();
                FootRotation();
            }
            else
            {
                Move();
                FootRotation();
            }
        }
    }
    
    private void DragControl()
    {
        touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier);
        }else if(touch.phase == TouchPhase.Stationary)
        {
            transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
        }
    }

    private void FootRotation()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x - 0.2f, transform.position.y + 1f, transform.position.z), -Vector3.up, out hit))
        {
            if (hit.transform.tag == "Ground")
            {
                if (transform.Find("LeftFoots").childCount == 0)
                {
                    transform.position = new Vector3(transform.position.x, hit.transform.position.y + 0.75f, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, hit.transform.position.y + 0.75f + 0.25f * transform.Find("LeftFoots").childCount, transform.position.z);
                }
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
        transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
    }
}
