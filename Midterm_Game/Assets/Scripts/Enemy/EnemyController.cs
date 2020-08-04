using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStat))]
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRange = 0.5f;
    public GameObject animator;


    private float attackDelayTime = 2f;
    private float timer = -1f;
    EnemyStat Enemy;

    GameObject target;
    NavMeshAgent agent;

    private void Start()
    {
        Enemy = GetComponent<EnemyStat>();
        target = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        //if (distance <= lookRadius)
        {
            agent.SetDestination(target.transform.position);
            
            if (distance - agent.stoppingDistance <= attackRange)
            {
                
                // Attack
                Attack();
                // Face the target
                FaceTarget();
            }
        }
    }
    void Attack()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            target.GetComponent<PlayerState>().TakeDamage(Enemy.AttackPower);
            timer = attackDelayTime;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
