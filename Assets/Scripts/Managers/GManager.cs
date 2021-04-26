using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance { get; set; }
    public GameObject cube, bigCube, sphere, longCube, particle, KeyPrefab;
    public List<string> KeyName = new List<string>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddKeyName(string nameKeyParent)
    {
        KeyName.Add(nameKeyParent);
    }

    public void CheckDoorWithKey(GameObject door)
    {
        foreach (string name in KeyName)
        {
            if (name == door.transform.parent.parent.parent.parent.name)
            {
                door.GetComponent<DoorController>().CheckStatus(true);
            }
        }
    }

    public void TrapActive(string nameTrap)
    {
        if (nameTrap == "TrapRoom")
        {
            for (int i = 0; i < 200; i++)
            {
                Transform.Instantiate(cube, new Vector3(0, 1 + i, 50), Quaternion.identity);
            }
        }
        if (nameTrap == "TrapRoom3")
        {
            for (int i = 0; i < 15; i++)
            {
                GameObject Sphere = Transform.Instantiate(sphere, new Vector3(-50, 1.8f, 0 + i), Quaternion.identity);
                Sphere.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 1) * 30);
            }
        }
        if (nameTrap == "TrapRoom4")
        {
            GameObject[] FirstEnemy = GameObject.FindGameObjectsWithTag("smallCube");
            foreach (GameObject cube in FirstEnemy)
            {
                Destroy(cube.gameObject);
            }
       
            for (int i = 0; i < 8; i++)
            {
                Vector3 position = new Vector3(-70 + i * 5, 2f, 30);
                GameObject BigCube = Transform.Instantiate(bigCube, position, Quaternion.identity);
                for (int j = 0; j < 8; j++)
                {
                    position.z += 5;
                    Transform.Instantiate(bigCube, position, Quaternion.identity);
                }
            }
        }
        if (nameTrap == "TrapRoom5")
        {
            GameObject[] SphereEnemy = GameObject.FindGameObjectsWithTag("sphereEnemy");
            foreach (GameObject sphere in SphereEnemy)
            {
                Destroy(sphere.gameObject);
            }

            for (int i = 0; i < 8; i++)
            {
                int random = Random.Range(1, 3);
                float x;
                if (random == 1)
                {
                    x = -63f;
                }
                else
                {
                    x = -40f;
                }
                Vector3 position = new Vector3(x, 2f, -70 + i * 5);
                GameObject LongCube = Transform.Instantiate(longCube, position, Quaternion.identity);
            }
        }

        if (nameTrap == "TrapRoom1")
        {
            particle.SetActive(true);
        }

        if (nameTrap == "TrapRoom6")
        {
            particle.SetActive(false);
            for (int i = 0; i < 50; i++)
            {
                Transform.Instantiate(KeyPrefab, new Vector3(50, 1 + i, -50), Quaternion.identity);
            }
        }

        if(nameTrap == "Win")
        {
            UIManager.UInstance.Win();
        }

    }
}


