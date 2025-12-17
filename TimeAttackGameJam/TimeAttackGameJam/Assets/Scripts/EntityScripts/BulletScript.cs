using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float force;
    [SerializeField] int damage;

    [Header("Component")]
    [SerializeField] Rigidbody rb;

    [Header("Despawn Timers")]
    [SerializeField] float timeTillDespawn;

    private void Start()
    {
        rb.linearVelocity = transform.forward * force;

        Destroy(gameObject, 5);
    }

   
    
}
