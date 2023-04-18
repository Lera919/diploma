using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PortalCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject teleport;
    [SerializeField]
    private Transform[] points;
    

    public Vector3 CreateTeleport(Vector3 playerPosition)
    {
            Spawn(playerPosition + new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)));
            if (points.Length != 0)
            {
            Debug.Log("Create teleport");
            var secondTeleportPosition = points[Random.Range(0, points.Length - 1)].position;
                Spawn(secondTeleportPosition);
                return secondTeleportPosition;
            }

        return Vector3.zero;

    }

    public void Spawn(Vector3 spawnPosition) => Instantiate(teleport, spawnPosition, teleport.transform.rotation);
            
    
}
