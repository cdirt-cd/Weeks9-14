using UnityEngine;
using UnityEngine.Events;

public class DamageManager : MonoBehaviour
{
    // even that triggers when the player dies
    public UnityEvent OnPlayerDeath = new UnityEvent();

    // when the player dies, this function is called
    public void InvokeDamage()
    {
        OnPlayerDeath.Invoke();
    }
}
