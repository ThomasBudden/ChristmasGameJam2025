using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUpOneScript : MonoBehaviour
{

    
    [SerializeField] GameObject powerManager;

    [SerializeField] bool isDestroyed = false;

    private void Start()
    {
        powerManager = GameObject.FindWithTag("PowerManager");
        

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Destroy(gameObject);

        }
    }


    

    private void OnDestroy()
    {
        if (!isDestroyed)
        {
           powerManager.GetComponent<PowerUpScript>().lastSpawn = null;
           isDestroyed = true;
       }
       

   }

}
