using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toasterMove : MonoBehaviour {

    // Handles all movement of toaster, including gravity / boost / collision / death
    // Vector3 used for handling position / direction etc

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 boostVelo; // Velocity of boost/tap
    bool boost = false; // Boost = user taps screen, toaster flies, default is false
    public float maxSpeed = 5; // Prevent going too fast / too much velocity
    float xSpeed = 1.5f; // How fast toaster moves towards right
    Animator animator; // For flying / death animations
    public bool dead = false; // Is dead or not
    float deathCooldown; // "Pause" after death, prevent game from restarting immediately, i.e. user has time to realise they died

    #region Start, Updates - Reload Game and Boost Inits
    // Use this for initialization
    void Start () {
        animator = transform.GetComponentInChildren<Animator>(); // Get the animator on start, need to update each frame depending on if user taps or not
	}

    // Graphic + input updates
    void Update () {
        if (dead) { // if the user is dead in the current frame
            deathCooldown -= Time.deltaTime; // Reduce the cooldown (like a timer, less each frame)

            if (deathCooldown <= 0) { // If cooldown is 0
                SceneManager.LoadScene("scene"); // Load the game scene again
            }
        }
        else { // Otherwise the user isn't dead, allow them to boost
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
                boost = true; // If the user taps / spacebar / clicks mouse, boost the toaster
            }
        }
        
    }
    #endregion

    #region Physics Based Updates
    // Use FixedUpdate to handle movement (physics) updates
    void FixedUpdate () {
        float angle = 0; // Initial toaster angle is straight
        if (dead){ // If dead, apply gravity and slight rotation
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity / 30; // Increase velocity slightly
            angle = Mathf.Lerp(0, -90, (-velocity.y / 7) - 0.001f); // Calculate angle based on current velocity
            transform.rotation = Quaternion.Euler(0, 0, angle); // Perform rotation
            velocity.x = 0; // Stop moving forward (fall straight down)
            velocity.y = -1f; // Fall down
            return;
        }

        velocity.x = xSpeed; // Set x velocity to speed defined at the top
        velocity += gravity * (Time.deltaTime / 0.95f); // Apply gravity based on time
        if (boost == true) { // If user does boost
            boost = false; // reset first
            animator.SetTrigger("doBoost"); // Trigger animation (flap wings)
            if (velocity.y < 0) { // If y less than 0
                velocity.y = 0; // Reset y velocity
                velocity.x += 0.02f; // Move forward slightly
            }

            velocity += boostVelo; // add boost to velocity
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // Velocity (downwards )increases as time goes on
        transform.position += velocity * Time.deltaTime;
 
        // velocity is less than 0, toaster will start to angle downwards
        if (velocity.y < 0) {
            angle = Mathf.Lerp(0, -90, (-velocity.y / 7) - 0.001f); // Calculate angle based on velocity
        }
        
        transform.rotation = Quaternion.Euler(0, 0, angle); // Perform rotation - no x or y rotation but will rotate on z
    }
    #endregion

    #region Collision Handling
    // When toaster collides with anything
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected"); // Testing
        animator.SetTrigger("death"); // Trigger death (greyed out not moving) animation
        dead = true; // Set dead equals true, for physics / reset game stuff above
        deathCooldown = 0.5f; // Initialise cooldown at half a second, gives user time to realise they died
        Score.stopWatch.Stop(); // Stop the score stopwatch (i.e. can't increase score)
        Score.OnDeath(); // Call OnDeath() function in score
    }
    #endregion
}
