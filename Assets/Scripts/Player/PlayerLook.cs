using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseX;

	public float sensitivityHor = 9.0f; // sped rotation
	public float sensitivityVert = 9.0f;
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0; // rotation angle

	void Update()
	{
		if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); 
		}
		else if (axes == RotationAxes.MouseY)
		{
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); 
																			
			float rotationY = transform.localEulerAngles.y; 
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
