using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    EnemyHealth health;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false; // bi khieu khich
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindAnyObjectByType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = true;
            navMeshAgent.speed = 0;
            



        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget(); 
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
          
        }
    }
    private void EngageTarget() //thu hut muc tieu
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("Move");

         navMeshAgent.SetDestination(target.position);
       
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); 
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
