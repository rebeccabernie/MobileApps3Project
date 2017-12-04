using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudLoop : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.name);

        float cloudWidth = ((BoxCollider2D)collider).size.x; // cast collider to box collider 2d
        Vector3 pos = collider.transform.position;
        pos.x += cloudWidth * 5; // 4 background tiles
        collider.transform.position = pos; // move the first tile to the new position
    }
}
