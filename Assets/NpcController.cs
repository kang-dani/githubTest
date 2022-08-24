using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private Animator animator;
	public Transform target;
	private float findTime = 0f;
	public LayerMask colliderMask;

	private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	//0.02f
	private void FixedUpdate()
	{
		if (target)
		{
			float distance = Vector3.Distance(transform.position, target.position);
			if(distance < 2f)
			{
				navMeshAgent.isStopped = true;
				transform.LookAt(target);
			}
			else navMeshAgent.isStopped = false;

			navMeshAgent.SetDestination(target.position);

		}
		else
		{
			findTime += Time.fixedDeltaTime;
			if(findTime  >= 1f)
			{
				Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, colliderMask);
				foreach (Collider collider in colliders)
				{
					if(collider.tag == "Player")
					{
						target = collider.transform;
						break;
					}
				}
				findTime = 0f;
			}

			
		}

		float speed = navMeshAgent.desiredVelocity.magnitude;
		animator.SetFloat("Speed", speed);
	}

}
