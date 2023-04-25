using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] foodToSpawn;
    [SerializeField] private int foodCount = 20;
    [SerializeField] private int foodSpawnRange = 20;
    private const int MaxGenerateIterationsCount = 10;
    private void Start()
    {
        SpawnFoodOnMesh();
    }

    private void SpawnFoodOnMesh()
    {
        int i = 0;

        do
        {
            SpawnOnMesh(foodToSpawn[i % 2]);
            i++;
        }
        while (i < foodCount);
    }

    private void SpawnOnMesh(GameObject objectToSpawn) =>
                Instantiate(objectToSpawn, FindPoinOnNavMesh(), objectToSpawn.transform.rotation);

    private Vector3 FindPoinOnNavMesh()
    {
        int i = 0;

        do
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * foodSpawnRange;
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                var position = hit.position + new Vector3(0, 1, 0);
                i++;
                return position;
            }

        } while (i != MaxGenerateIterationsCount);
        throw new System.Exception("Unable to generate point on NavMesh");
    }
}
