using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    private bool hasStopped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {// check if the laser has collided with the player or an upgrade
        if (collision.CompareTag("Player") && !hasStopped)
        {//

            
            DamageManager dm = FindObjectOfType<DamageManager>();
            // check if the DamageManager is not null
            if (dm != null)
            { 
                dm.InvokeDamage();
            }
            
            hasStopped = true;
        }
        // check if the laser has collided with an upgrade
        if (collision.CompareTag("Upgrade"))
        {//destroy the upgrade object upon collision
            Destroy(collision.gameObject);
        }
    }
}
