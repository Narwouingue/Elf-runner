using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PortalController : MonoBehaviour
{

    public bool IsReturnActive = false;
    
    public Transform destinationPortal; // The other portal to teleport to
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform player)
    {
        Vector3 portalToPlayer = player.position - transform.position;


        
            Vector3 newPosition = destinationPortal.position + portalToPlayer;
            player.position = newPosition;

            // Rotate the player's forward direction to match the destination portal's up direction
            Vector3 portalUp = destinationPortal.up;
            Quaternion rotationDifference = Quaternion.FromToRotation(player.up, portalUp);

            // Add 90-degree rotation to the X-axis
            rotationDifference *= Quaternion.Euler(90f, 0f, 0f);

            if (IsReturnActive)
            {
            rotationDifference *= Quaternion.Euler(0, 180f, 0f);
            }

           

            player.rotation = rotationDifference * player.rotation;
           

    }
}




