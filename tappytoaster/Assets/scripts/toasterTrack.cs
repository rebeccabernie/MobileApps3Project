using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toasterTrack : MonoBehaviour {

    Transform toaster;
    public float offsetX;

	// Use this for initialization
	void Start () {
        //GameObject barrierObj = GameObject.FindGameObjectWithTag("barrier");
        //barrierObj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GameObject toasterObj = GameObject.FindGameObjectWithTag("Player");
        // Just for testing purposes...
        if (toasterObj == null) {
            Debug.LogError("Could not locate toaster...");
            return;
        }

        toaster = toasterObj.transform;
        offsetX = transform.position.x - toaster.position.x;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (toaster != null) { // i.e. not dead
            Vector3 pos = transform.position; // can't directly modify transform.position.x
            pos.x = toaster.position.x + offsetX;
            transform.position = pos;
        }
    }
}
