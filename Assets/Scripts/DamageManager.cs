using UnityEngine;
using UnityEngine.Events;

public class DamageManager : MonoBehaviour
{
    
    public UnityEvent OnPlayerDeath = new UnityEvent();

    
    public void InvokeDamage()
    {
        OnPlayerDeath.Invoke();
    }
}
