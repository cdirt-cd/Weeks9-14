using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool Dead = false;

    private Rigidbody2D rb;
    private Collider2D col;
    private Coroutine dodgeCooldownCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        DamageManager dm = FindObjectOfType<DamageManager>();
        if (dm != null)
        {
            dm.OnPlayerDeath.AddListener(HandleDeath);
        }
    }

    
    public void StartDodgeCooldown()
    {
        if (dodgeCooldownCoroutine != null)
            StopCoroutine(dodgeCooldownCoroutine);

        dodgeCooldownCoroutine = StartCoroutine(DodgeCooldown());
    }


    private IEnumerator DodgeCooldown()
    {
        float cooldownTime = 5f;
        float timer = 0f;

        while (timer < cooldownTime)
        {
            if (Dead)
            {
                Debug.Log("Dodge cooldown stopped because player is dead.");
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Dodge is ready again.");
    }

  
    private void HandleDeath()
    {
        if (Dead) return;

        Dead = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        col.enabled = false;
        transform.Rotate(0f, 0f, 90f);

        Debug.Log("PlayerController: Dead event handled.");
    }
    public void ResetDodgeCooldown()
    {
        if (Dead) return;

        if (dodgeCooldownCoroutine != null)
        {
            StopCoroutine(dodgeCooldownCoroutine);
            dodgeCooldownCoroutine = null;
        }

        Debug.Log("Dodge cooldown reset by upgrade.");
    }

}
