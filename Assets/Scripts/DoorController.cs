using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum Status
    {
        open = 1,
        close = 2,
        blocked = 3
    }
    public Status status;
    private Color _color;
    public Transform anchor;
    private float speedDor = 1f;

    private void Start()
    {
        _color = this.gameObject.GetComponent<Renderer>().material.color;
        if (_color == Color.red || _color == Color.green)
        {
            status = Status.blocked;
        }
        else
        {
            status = Status.close;
        }
    }
    private void Update()
    {
        if (status == Status.open)
        {
            CloseOpenDoor(-90);
        }
        if (status == Status.close)
        {
            CloseOpenDoor(0);
        }
    }

    public void CheckStatus(bool mustOpen)
    {
        switch(status)
        {
            case Status.open:
                status = Status.close;
                break;
            case Status.close:
                status = Status.open;
                break;
            default:
                if (mustOpen) status = Status.open;
                break;
        }
    }

    void CloseOpenDoor(float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, speedDor * Time.deltaTime);
    }
}
