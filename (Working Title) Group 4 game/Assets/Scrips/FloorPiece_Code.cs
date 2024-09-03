using UnityEngine;

public class FloorPiece : MonoBehaviour
{
    public float delay = 2f;

    // Function to shatter the floor piece
    public void Shatter()
    {
        // Add any breaking or shattering logic here (e.g., adding a Rigidbody to the piece)
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.AddExplosionForce(300f, transform.position, 5f);
        Destroy(gameObject, 2f); // Optional: destroy the piece after a delay
    }

    // Delay the shatter
    public void TriggerShatter()
    {
        Invoke("Shatter", delay);
    }
}
