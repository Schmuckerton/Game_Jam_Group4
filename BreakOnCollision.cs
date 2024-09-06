using UnityEngine;

public class BreakAndDisappear : MonoBehaviour
{
    // Array to hold the fragments that will replace the object when it breaks
    public GameObject[] fragments;

    // Time after which fragments should disappear
    public float fragmentLifetime = 5f;

    // The tag of the player object
    public string playerTag = "Player";

    // Called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the Player tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Only break if the player collides with it
            if (fragments.Length > 0)
            {
                BreakObject();
            }
            else
            {
                Debug.LogWarning("Fragments not assigned in the inspector.");
            }
        }
    }

    // Function to replace the object with fragments
    private void BreakObject()
    {
        // Disable or destroy the original object
        gameObject.SetActive(false);

        // Instantiate the fragments at the position and rotation of the original object
        foreach (GameObject fragment in fragments)
        {
            GameObject instantiatedFragment = Instantiate(fragment, transform.position, transform.rotation);

            // Make sure the fragment has a Rigidbody for physics interaction
            Rigidbody rb = instantiatedFragment.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply a random force to simulate the fragments scattering
                rb.AddExplosionForce(Random.Range(200, 500), transform.position, 1f);
            }

            // Destroy the fragment after the specified lifetime
            Destroy(instantiatedFragment, fragmentLifetime);
        }

    }
}