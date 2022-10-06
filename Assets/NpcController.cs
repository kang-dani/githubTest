using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : CharacterController
{
	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private Animator animator;

	private float findTime = 0f;
	private float attackTime = 0f;
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
			if (distance < 2f)
			{
				Attack();
			}
			else
			{
				navMeshAgent.isStopped = false;
			}

			navMeshAgent.SetDestination(target.position);

		}
		else
		{
			findTime += Time.fixedDeltaTime;
			if (findTime >= 1f)
			{
				FindTarget();
				findTime = 0f;
			}
		}

		float speed = navMeshAgent.desiredVelocity.magnitude;
		animator.SetFloat("Speed", speed);
	}

	private void Attack()
	{
		navMeshAgent.isStopped = true;
		transform.LookAt(target);

		attackTime += Time.fixedDeltaTime;
		if (attackTime > 3f)
		{
			animator.SetTrigger("Attack");
			attackTime = 0f;
		}
	}


}
