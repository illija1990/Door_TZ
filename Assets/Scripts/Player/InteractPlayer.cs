using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
	private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

	void OnGUI()
	{
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label(new Rect(posX, posY, size, size), "+"); 
	}

	private void Update()
    {
		Interact();
	}

	void Interact()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 10))
			{
				if (hit.transform.gameObject.name == "Key")
				{
					GManager.Instance.AddKeyName(hit.transform.parent.name);
					Destroy(hit.transform.gameObject);
				}

				if (hit.transform.gameObject.tag == "door")
				{
					var door = hit.transform.gameObject.GetComponent<DoorController>();
					door.CheckStatus(false);

					if (door.status == DoorController.Status.blocked)
					{
						GManager.Instance.CheckDoorWithKey(hit.transform.gameObject);
					}
				}
			}
		}
	}
}
