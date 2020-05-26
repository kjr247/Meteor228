using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("collision");
        if(other.collider.tag == "Planet") {
            Destroy(gameObject);
        }
    }
}
