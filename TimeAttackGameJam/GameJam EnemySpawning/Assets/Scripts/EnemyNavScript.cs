using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    private Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        target = player.transform.position;
        agent.SetDestination(target);
    }
}
