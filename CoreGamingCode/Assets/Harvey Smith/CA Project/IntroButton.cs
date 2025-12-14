using UnityEngine;
using UnityEngine.UI;

public class IntroButton : MonoBehaviour
{
    public Button button;
    public Transform canvas;
    ButtonControlScript myButton;

    /// <summary>
    /// Initializes and configures the "Start Game" button with specified properties, including colors, text, position,
    /// and size.
    /// </summary>
    /// <remarks>This method retrieves the button's control script, sets its appearance and behavior, and
    /// prepares it for user interaction.</remarks>
    void Start()
    {
        
        myButton = button.GetComponent<ButtonControlScript>();
        myButton.SetColors(Color.lightBlue, Color.green, Color.red, Color.lightBlue);
        myButton.SetButtonText("Start Game");
        myButton.SetPosition(new Vector2(47, -154));
        myButton.SetButtonSize(160, 60);
        myButton.Initilise();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
