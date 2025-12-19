using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{

    [Header("Shockwave")]
    [SerializeField] float AOE;
    [SerializeField] float force;

    [Header("Invincibility")]
    [SerializeField] float duration;
    [SerializeField] Collider hitbox;
    [SerializeField] bool isInvincible;


    private void Update()
    {
        if (isInvincible == true)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                hitbox.enabled = true;
                isInvincible = false;
                duration = 2;  
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUpOne")
        {
            ShockWave();
            Debug.Log("Trigger Shockwave");
        }

        if (collision.gameObject.tag == "PowerUpTwo")
        {
            Invincibility();
            Debug.Log("Trigger Invincibility");
        }
    }


    void ShockWave()
    {

    }

    void Invincibility()
    {
        hitbox.enabled = false;
        isInvincible = true;
    }




}
