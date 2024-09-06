using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAndDestroyOnTouch : MonoBehaviour
{
    // The force with which the object will be launched
    public Vector3 launchForce = new Vector3(0, 500, 0); // Example: launching upward
    public string playerTag = "Player"; // Tag for the player object

    // Time in seconds before the object is destroyed after being launched
    public float timeBeforeDestruction = 3f;

    // Called when something enters the collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided with this has the Player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Get the Rigidbody component attached to this object
            Rigidbody rb = GetComponent<Rigidbody>();

            // If the Rigidbody exists, apply the launch force
            if (rb != null)
            {
                // Apply the force to launch the object
                rb.AddForce(launchForce, ForceMode.Impulse);

                // Log the launch event
                Debug.Log("Object launched!");

                // Destroy the object after the specified delay
                Destroy(gameObject, timeBeforeDestruction);
            }
            else
            {
                Debug.LogWarning("No Rigidbody attached to this object.");
            }
        }
    }
}