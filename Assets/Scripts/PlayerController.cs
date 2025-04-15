using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool Dead = false;

    private Rigidbody2D rb;
    private Collider2D col;
    private Coroutine dodgeCooldownCoroutine;

    
   

    private void Start()
    {// initialize the player controller with the rigidbody and collider components
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // subscribe to the OnPlayerDeath event from the DamageManager
        DamageManager dm = FindObjectOfType<DamageManager>();
        if (dm != null)
        {// check if the DamageManager is not null
            dm.OnPlayerDeath.AddListener(HandleDeath);
        }
    }

    private float moveSpeed = 5f;

    private void Update()
    {// handle player movement and dodge cooldown
        if (Dead) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed;
        rb.velocity = movement;
    }

    /// handle dodge cooldown
    public void StartDodgeCooldown()
    {
        if (dodgeCooldownCoroutine != null)
            StopCoroutine(dodgeCooldownCoroutine);

        dodgeCooldownCoroutine = StartCoroutine(DodgeCooldown());
    }
    // coroutine to manage the dodge cooldown
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
    /// handle player death
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
    /// reset the dodge cooldown when the player picks up an upgrade
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
