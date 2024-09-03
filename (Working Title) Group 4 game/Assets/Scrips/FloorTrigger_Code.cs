using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public LayerMask floorMask;
    public float checkRadius = 1f;

    private void Update()
    {
        // Check the floor underneath the player
        Collider[] floorPieces = Physics.OverlapSphere(transform.position, checkRadius, floorMask);

        foreach (Collider floorPiece in floorPieces)
        {
            // Trigger the shatter effect on the floor piece
            FloorPiece piece = floorPiece.GetComponent<FloorPiece>();
            if (piece != null)
            {
                piece.TriggerShatter();
            }
        }
    }
}
