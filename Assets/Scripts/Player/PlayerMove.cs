using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private CharacterController _charController;
	public float speed = 6.0f;
	public float gravity = -9.8f;

	void Start()
	{
		_charController = GetComponent<CharacterController>();  
	}

	void Update()
	{
		Moving();
	}

	void Moving()
	{
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	private void OnTriggerEnter(Collider other)
	{
		GManager.Instance.TrapActive(other.gameObject.name);
		Destroy(other.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "smallCube")
		{
			collision.gameObject.GetComponent<Rigidbody>().AddForce(-transform.position, ForceMode.Impulse);
		}
	}
}
