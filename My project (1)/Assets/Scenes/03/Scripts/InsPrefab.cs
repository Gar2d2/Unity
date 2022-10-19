using UnityEngine;
using System.Collections.Generic;
public class InsPrefab : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    public  List<Vector3> usedCoordinates = new List<Vector3>();
    void Update()
    {

    }
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        int objectSpawned = 0;
        int triesCount = 0;
        while (objectSpawned < 10)
        {
            if(triesCount++ > 1000)
            {
                break;
            }

            Vector3 newPos = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
            bool coordsInList = false;
            for (int i = 0; i < usedCoordinates.Count; i++)
            {
                if (Mathf.Abs(usedCoordinates[i].x - newPos.x) < 1 && Mathf.Abs(usedCoordinates[i].z - newPos.z) < 1)
                {
                    coordsInList = true;
                    break;
                }
            }

            if (!coordsInList)
            {
                objectSpawned++;
                Instantiate(myPrefab, newPos, Quaternion.identity);

            }

        }
    }
}