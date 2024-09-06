using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winScreenImage;  // Reference to the win screen UI Image
    public GameObject winAudioObject;  // Reference to the GameObject with the AudioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers the win condition
        {
            WinGame();
        }
    }

    void WinGame()
    {
        // Activate the win screen UI
        winScreenImage.SetActive(true);

        // Activate the GameObject with the AudioSource (which will play the audio automatically)
        winAudioObject.SetActive(true);
    }
}
