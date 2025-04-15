using UnityEngine;

public class DeathLogger : MonoBehaviour
{
    private void Start()
    {// find the DamageManager in the scene
        DamageManager dm = FindObjectOfType<DamageManager>();
        // subscribe to the OnPlayerDeath event
        if (dm != null)
        {// check if the DamageManager is not null
            dm.OnPlayerDeath.AddListener(LogDeath);
        }
    }
    // trigger the death event
    private void LogDeath()
    {
        Debug.Log("DeathLogger: Player has died.");
    }
}
