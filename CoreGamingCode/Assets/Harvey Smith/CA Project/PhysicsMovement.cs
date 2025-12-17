using UnityEngine;


/// <summary>
/// Provides movement functionality for a physics-based object in a 3D environment.
/// </summary>
/// <remarks>This class enables directional movement (forward, backward, left, and right) for a Rigidbody
/// component based on the orientation of a Camera. The movement is applied using physics forces, making it suitable for
/// objects that require realistic motion in a physics simulation.</remarks>
public class physicsMovement : MonoBehaviour
{
    public Rigidbody rigid;
    public Camera cam;


    public void forwardMovement(float speed)
    {
        Vector3 forwardDir = cam.transform.forward;

        forwardDir.y = 0f;       
        forwardDir.Normalize();   

        rigid.AddForce(forwardDir * speed, ForceMode.Force);
    }

    public void backwardMovement(float speed)
    {
        Vector3 backDir = -cam.transform.forward;

        backDir.y = 0f;
        backDir.Normalize();

        rigid.AddForce(backDir * speed, ForceMode.Force);
    }

    public void rightMovement(float speed)
    {
        Vector3 rightDir = cam.transform.right;

        rightDir.y = 0f;
        rightDir.Normalize();

        rigid.AddForce(rightDir * speed, ForceMode.Force);
    }

    public void leftMovement(float speed)
    {
        Vector3 leftDir = -cam.transform.right;

        leftDir.y = 0f;
        leftDir.Normalize();

        rigid.AddForce(leftDir * speed, ForceMode.Force);
    }
}
