using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public Transform target;
	protected void FindTarget()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, colliderMask);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Player")
			{
				target = collider.transform;
				break;
			}
		}
	}



}
