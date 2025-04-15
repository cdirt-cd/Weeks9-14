using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    
    public PlayerController playerController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {// check if the player has collided with the upgrade
        if (collision.CompareTag("Player"))
        {
            
            Debug.Log("Player picked up an upgrade! Dodge cooldown reset.");
            
            if (!playerController)
            { 
                Debug.LogWarning("UpgradePickup: No reference to PlayerController found.");
                return;
            }
            // reset the dodge cooldown upon pickup
            playerController.ResetDodgeCooldown();
            //destroy the upgrade object upon pickup
            Destroy(gameObject);
        }
    }
}
