using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{

    [Header("Shockwave")]
    public float shDuration;
    public bool shockwaveActivated;
    
    

    [Header("Invincibility")]
    [SerializeField] float inDuration;
    [SerializeField] Collider hitbox;
    [SerializeField] bool isInvincible;


    private void Start()
    {
       
    }

    private void Update()
    {
        if (isInvincible == true)
        {
            inDuration -= Time.deltaTime;
            if (inDuration <= 0)
            {
                hitbox.enabled = true;
                isInvincible = false;
                inDuration = 2;  
            }
        }

        if (shockwaveActivated == true)
        {
            shDuration -= Time.deltaTime;
            if (shDuration <= 0)
            {
                
                shockwaveActivated = false;
                shDuration = 2;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUpOne")
        {
            ShockWave();
            Debug.Log("Trigger Shockwave");
        }

        if (other.gameObject.tag == "PowerUpTwo")
        {
            Invincibility();
            Debug.Log("Trigger Invincibility");
        }
    }


    void ShockWave()
    {
       shockwaveActivated = true;

    }

    void Invincibility()
    {
        hitbox.enabled = false;
        isInvincible = true;
    }




}
