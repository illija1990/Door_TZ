using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private void Update()
    {
        if(this.transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }
}
