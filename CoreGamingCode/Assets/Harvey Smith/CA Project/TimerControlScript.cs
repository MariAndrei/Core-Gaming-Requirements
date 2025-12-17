using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerUser : MonoBehaviour
{

    ///This Script is responsible for starting and displaying the timer, 
    ///as well as handling game over state, intro state, the hiding and showing of objects, 
    ///button control and also defines a few methods. This is the main game controller script, as the game mostly revolves around the timer.
    
    float time;

    public Button button;

    public TextMeshProUGUI intro;

    public Collectible collectibleScript;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI gameOverText;

    public GameObject player;

    public GameObject ground;

    public GameObject collectible;

    public TextMeshProUGUI highScore;

    private MAR_TimerScript timer;



    public float timeAmount = 20f;
    private bool timerActive = true;


    /// <summary>
    /// Initializes the game by setting up necessary components, disabling game elements, and registering event
    /// listeners.
    /// </summary>
    /// <remarks>This method prepares the game for the start state by adding a timer component, hiding UI and
    /// game objects, and attaching the button click event handler. Ensure all referenced objects are properly assigned
    /// in the Unity Editor before calling this method.</remarks>
    void Start()
    {
        timer = gameObject.AddComponent<MAR_TimerScript>();
        
        gameOverText.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        ground.gameObject.SetActive(false);
        collectible.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        button.onClick.AddListener(OnButtonPressed);
    }

    /// <summary>
    /// Updates the game state based on the remaining time in the timer.
    /// </summary>
    /// <remarks>This method checks if the timer is active and updates the displayed time accordingly.  If the
    /// timer reaches zero, it ends the game by displaying a "GAME OVER" message,  showing the high score, and disabling
    /// relevant game objects.</remarks>
    void Update()
    {
        if (timerActive)
        {
            time = timer.GetTimeRemaining(); 

            if (time > 0)
            {
                timerText.text = time.ToString("0.00");
            }
            else
            {
                timerText.text = "GAME OVER!";
                timerActive = false;
                gameOverText.gameObject.SetActive(true);
                highScore.text = collectibleScript.counter.ToString();
                highScore.gameObject.SetActive(true);
                player.SetActive(false);
                ground.SetActive(false);
                collectible.SetActive(false);

            }
        }

    }
    
        
        /// <summary>
        /// Handles the event triggered when the button is pressed, initializing the game state and starting the timer.
        /// </summary>
        /// <remarks>This method activates the player, ground, and collectible objects, hides the
        /// introductory UI elements,  and displays the timer text. It also initializes and starts the game timer with
        /// the specified duration.</remarks>
        void OnButtonPressed()
    {
        player.SetActive(true);
        ground.SetActive(true);
        collectible.SetActive(true);
        intro.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        timer.InitialiseTimer(timeAmount);
        timer.StartTimer();

        timerActive = true;
    }

    /// <summary>
    /// Handles the event when another collider enters the trigger collider attached to this object.
    /// </summary>
    /// <remarks>This method checks if the entering collider has the tag "Player" and whether the timer is
    /// active. If both conditions are met, it initializes and starts the timer with the specified time
    /// amount.</remarks>
    /// <param name="other">The <see cref="Collider"/> that entered the trigger. Typically used to detect interactions with specific
    /// objects.</param>
    private void OnTriggerEnter(Collider other) {
        {
            if (other.CompareTag("Player") && timerActive)
            {
                timer.InitialiseTimer(timeAmount);
                timer.StartTimer();
              
            }

        }


    }

}




