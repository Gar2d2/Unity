using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    [SerializeField]
    int m_objectsCount = 0;
    [SerializeField]
    List<Material> m_materials;
    void Start()
    {
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        var renderer = GetComponent<Renderer>();

        
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)renderer.bounds.min.x, (int)renderer.bounds.max.x).OrderBy(x => Guid.NewGuid()).Take(m_objectsCount));
        var minZ = (int)(renderer.bounds.min.z +1);
        var maxZ = (int)renderer.bounds.max.z;
        List<int> pozycje_z = new List<int>();
        // List<int> pozycje_z = new List<int>(Enumerable.Range(minZ, maxZ).OrderBy(z => Guid.NewGuid()).Take(m_objectsCount)); z jakiegoœ powodu zwraca elementy poza zasiêgiem
        pozycje_z.Add(Random.Range(minZ, maxZ));
        while (pozycje_z.Count < m_objectsCount)
        {
            int candidate = Random.Range(minZ, maxZ);
            if(pozycje_z.IndexOf(candidate) == -1)
            {
                pozycje_z.Add(candidate); 
            }
        }

        for (int i = 0; i < m_objectsCount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], renderer.bounds.max.y + 2, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            var obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            if(m_materials.Count >0)
            {
                obj.GetComponent<Renderer>().material = m_materials[Random.Range(0, m_materials.Count - 1)];
            }
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}