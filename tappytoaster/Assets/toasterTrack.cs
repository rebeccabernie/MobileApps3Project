using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toasterTrack : MonoBehaviour {

    Transform toaster;

	// Use this for initialization
	void Start () {
        GameObject toasterObj = GameObject.FindGameObjectWithTag("Player");
        // Just for testing purposes...
        if (toasterObj == null) {
            Debug.LogError("Could not locate toaster...");
            return;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
