using Unity.VisualScripting;
using UnityEngine;

public class YB_PlayerMovement : MonoBehaviour
{
    int movementMultiplier = 3;

    void Start()
    { 
    
    }

    void Update()
    {
        Vector3 dir = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        dir.Normalize();
        transform.LookAt(transform.position + dir, Vector3.up);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += movementMultiplier * transform.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            transform.position -= movementMultiplier * transform.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= movementMultiplier * transform.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += movementMultiplier * transform.right * Time.deltaTime;
        }
    }
}
