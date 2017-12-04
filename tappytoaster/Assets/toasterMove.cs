using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toasterMove : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 boostVelo; // Velocity of boost/tap
    bool boost = false; // boost = user taps screen, toaster flies
    public float maxSpeed = 5;
    float xSpeed = 0.5f; // How fast toaster moves towards right
    Animator animator;
    bool dead = false;

	// Use this for initialization
	void Start () {
        animator = transform.GetComponentInChildren<Animator>();
	}

    // Graphic + input updates
    void Update () {
        //animator.SetBool("doBoost", false);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
            boost = true;
        }
    }
	
	// Handles movement (physics) updates - use fixed update
	void FixedUpdate () {
        /*
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.0007f);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.007f);
        */
        float angle = 0;
        if (dead){
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity / 30;
            if (velocity.y < 0) // Angle
                angle = Mathf.Lerp(0, -90, (-velocity.y / 7) - 0.001f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            return;
        }

        velocity.x = xSpeed;
        velocity += gravity * Time.deltaTime;
        if (boost == true) {
            boost = false; // reset
            animator.SetTrigger("doBoost");
            if (velocity.y < 0)
                velocity.y = 0;
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
        velocity.y = -1;
    }
}
