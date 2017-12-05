using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudLoop : MonoBehaviour {

    float cloudMax = 0.6f;
    float cloudMin = -0.35f;

    void Start() {
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("cloud");

        foreach(GameObject cloud in clouds) {
            Vector3 pos = cloud.transform.position;
            pos.y = Random.Range(cloudMin, cloudMax);
            cloud.transform.position = pos; // move the first tile to the new position
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered: " + collider.name);

        float cloudWidth = ((BoxCollider2D)collider).size.x; // cast collider to box collider 2d
        Vector3 pos = collider.transform.position;
        pos.x += cloudWidth * 6; // 4 background tiles

        if (collider.tag == "cloud") {
            pos.y = Random.Range(cloudMin, cloudMax);
        }

        collider.transform.position = pos; // move the first tile to the new position
    }
}
