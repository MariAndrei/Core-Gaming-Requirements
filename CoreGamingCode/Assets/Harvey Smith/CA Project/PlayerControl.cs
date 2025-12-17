using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private physicsMovement movement;
    float movementSpeed = 300f;
    public Rigidbody rigid;
   

    void Start()
    {
        movement = GetComponent<physicsMovement>();
    }

    /// <summary>
    /// Updates the movement of the object based on user input.
    /// </summary>
    /// <remarks>This method checks for specific key presses and triggers the corresponding movement actions.
    /// The movement is determined by the keys (W,S,D,A) for forward, backward, right, and left  movement, respectively.
    /// The movement speed is controlled by the <c>movementSpeed</c> parameter.</remarks>
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            movement.forwardMovement(movementSpeed);

        if (Input.GetKey(KeyCode.S))
            movement.backwardMovement(movementSpeed);

        if (Input.GetKey(KeyCode.D))
            movement.rightMovement(movementSpeed);

        if (Input.GetKey(KeyCode.A))
            movement.leftMovement(movementSpeed);
    }
        
        
    }
   

