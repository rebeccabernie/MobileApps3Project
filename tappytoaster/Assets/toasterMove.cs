﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toasterMove : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 boostVelo; // Velocity of boost/tap
    bool boost = false; // boost = user taps screen, toaster flies
    public float maxSpeed = 5;

    public float xSpeed = 0.5f; // How fast toaster moves towards right

	// Use this for initialization
	void Start () {
		
	}

    // Graphic + input updates
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
            boost = true;
        }
    }
	
	// Handles movement (physics) updates - use fixed update
	void FixedUpdate () {
        velocity.x = xSpeed;
        velocity += gravity * Time.deltaTime;
        if (boost == true) {
            boost = false; // reset
            if (velocity.y < 0)
                velocity.y = 0;
            velocity += boostVelo;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Velocity increases as time goes on
        transform.position += velocity * Time.deltaTime;

        float angle = 0;
        // velocity is less than 0, toaster will start to angle downwards
        if (velocity.y < 0) {
            angle = Mathf.Lerp(0, -90, -velocity.y / 7);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle); // no x or y rotation but will rotate on z

        
	}
}
