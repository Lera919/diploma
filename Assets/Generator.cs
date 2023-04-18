using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int count = 20;

    [SerializeField] private int range = 20;
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        int i = 0;
        
        do
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                var position = hit.position + new Vector3(0, 1, 0);
                Instantiate(prefabs[i % 2], position, prefabs[i % 2].transform.rotation); 
                i++;
            }
            //var position = new Vector3(Random.Range(-45, 45), 2, Random.Range(-45, 45));
           
           
        } while (i != count);
    }
}
