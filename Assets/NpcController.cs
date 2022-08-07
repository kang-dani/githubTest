using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
	public Text text;
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer.Equals(gameObject.layer))
		{
			if(other.CompareTag("Player"))
			{
				text.text = "Hello";
			}
			
		}
			

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer.Equals(gameObject.layer))
			if(other.CompareTag("Player"))
				text.text = "Bye";
	}

}
