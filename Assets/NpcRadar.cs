using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRadar : MonoBehaviour
{
	[SerializeField] private NpcController controller;
	private void Awake()
	{
		controller = transform.parent.GetComponent<NpcController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			controller.target = other.transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			controller.target = null;
		}
	}
}
