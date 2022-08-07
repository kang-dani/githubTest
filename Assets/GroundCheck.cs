using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;

	private void Awake()
	{
		playerController = transform.parent.GetComponent<PlayerController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		playerController.Ani.SetBool("IsGrounded", true);
	}

	private void OnTriggerExit(Collider other)
	{
		playerController.Ani.SetBool("IsGrounded", false);
	}
}
