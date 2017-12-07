using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toasterMove : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 boostVelo; // Velocity of boost/tap
    bool boost = false; // boost = user taps screen, toaster flies
    public float maxSpeed = 5;
    float xSpeed = 1.5f; // How fast toaster moves towards right
    Animator animator;
    public bool dead = false;
    float deathCooldown;

	// Use this for initialization
	void Start () {
        animator = transform.GetComponentInChildren<Animator>();
	}

    // Graphic + input updates
    void Update () {
        if (dead) {
            deathCooldown -= Time.deltaTime;

            if (deathCooldown <= 0) {
                //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
                    SceneManager.LoadScene("scene");
                //}
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
                boost = true;
            }
        }
        
    }
	
	// Handles movement (physics) updates - use fixed update
	void FixedUpdate () {
        float angle = 0;
        if (dead){
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity / 30;
            angle = Mathf.Lerp(0, -90, (-velocity.y / 7) - 0.001f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            velocity.x = 0;
            velocity.y = -1f;
            return;
        }

        velocity.x = xSpeed;
        velocity += gravity * (Time.deltaTime / 0.95f);
        if (boost == true) {
            boost = false; // reset
            animator.SetTrigger("doBoost");
            if (velocity.y < 0) {
                velocity.y = 0;
                velocity.x += 0.02f;
            }
            velocity += boostVelo;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // Velocity increases as time goes on
        transform.position += velocity * Time.deltaTime;
 
        // velocity is less than 0, toaster will start to angle downwards
        if (velocity.y < 0) {
            angle = Mathf.Lerp(0, -90, (-velocity.y / 7) - 0.001f);
        }
   
        transform.rotation = Quaternion.Euler(0, 0, angle); // no x or y rotation but will rotate on z
    }

    // When toaster collides with anything
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected");
        animator.SetTrigger("death");
        dead = true;
        deathCooldown = 0.5f;
        Score.stopWatch.Stop();
        Score.OnDeath();
    }
}
