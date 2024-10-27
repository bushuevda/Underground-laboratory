using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private RaycastHit hit;
    private float distance;
    [SerializeField] private float maxSeeDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos= player.transform.position;
        Vector3 enemyPos = transform.position;
        distance = Vector3.Distance(enemyPos, playerPos);
        //Debug.Log(SeePlayer());
    }

    private bool SeePlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;

        if(Physics.Raycast(transform.position, directionToPlayer, out hit))
        {
            if(hit.collider.gameObject.name == "Player" && distance < maxSeeDistance)
            {
                transform.position += directionToPlayer * 1 * Time.deltaTime;
                return true;
            }
            else if (hit.collider.gameObject.name != "Player")
            {
                Vector3 avoidanceDirection = Vector3.zero;
                Vector3 normal = hit.normal;
                avoidanceDirection = Vector3.Reflect(directionToPlayer.normalized, normal);
                Vector3 finalDirection = (directionToPlayer.normalized + avoidanceDirection).normalized;
                transform.position += finalDirection * 1 * Time.deltaTime;
                return false;
            }

            

        }
        return false;
    }
}
