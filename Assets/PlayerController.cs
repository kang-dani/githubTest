using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Animator Ani { get; private set; }
    [SerializeField] private Rigidbody rigid;
    public LayerMask layerMask;

	void Awake()
	{
        Ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        Ani.SetFloat("Speed", vertical);

        transform.Translate(Vector3.forward * vertical * Time.deltaTime * speed);

        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontal  * Time.deltaTime * 50f * speed);

        if(Input.GetKeyDown(KeyCode.Space))
		{
            rigid.AddForce(Vector3.up * 300f);
            Ani.SetTrigger("Jump");
		}

        if(Input.GetMouseButtonDown(0)) //L
		{
            Debug.Log(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
                Debug.Log(hit.collider);
			}
		}
    }
}
