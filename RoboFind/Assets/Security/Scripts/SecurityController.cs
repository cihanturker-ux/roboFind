using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class SecurityController : MonoBehaviour
{

    public GameObject light;

    public float lookRadius = 18f;
    public Animator securityAnim;
    public Transform target;
    NavMeshAgent agent;

    //Patroling
    public Transform point1, point2;
    public Vector3 walkPoint;
    Vector3 currentPoint;
    bool walkPointSet, inPoint1 = true, inPoint2;


    void Start()
    {
        //target = FirstPersonController.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }
    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

            light.SetActive(true);
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                securityAnim.SetBool("isWalking", true);
                FaceTarget();

                if (distance <= agent.stoppingDistance) // Game Over
                {
                    DeathController.instance.GameOver();
                }
            }
            else
            {
                if (inPoint1)
                {
                    securityAnim.SetBool("isWalking", true);
                    agent.speed = 1;
                    agent.SetDestination(point2.transform.position);
                }
                else if(inPoint2)
                {
                    securityAnim.SetBool("isWalking", true);
                    agent.speed = 1;
                    agent.SetDestination(point1.transform.position);
                }
            }
            
            light.SetActive(false);
            if (distance <= agent.stoppingDistance)
            {
                securityAnim.SetBool("isWalking", false);
            }
            
            currentPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            securityAnim.SetBool("isWalking", true);
            agent.speed = 1;
            agent.SetDestination(walkPoint);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point_1"))
        {
            inPoint1 = true;
            inPoint2 = false;
        }
        
        if (other.gameObject.CompareTag("Point_2"))
        {
            inPoint2 = true;
            inPoint1 = false;
        }
        
    }
    
    private void SearchWalkPoint()
    {
        if (inPoint1)
        {
            walkPoint = point2.transform.position;
            walkPointSet = true;
        }
        else if (inPoint2)
        {
            walkPoint = point1.transform.position;
            walkPointSet = true;
        }
        
    }
    
    
    
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
