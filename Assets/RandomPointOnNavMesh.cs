//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class RandomPointOnNavMesh : MonoBehaviour
//{
//    public float range = 10.0f;
//    private bool genered;
//    IEnumerable<Vector3> RandomPoint(Vector3 center, float range)
//    {
//        Vector3 result;
//        int i = 0;
//        { 
//            Vector3 randomPoint = center + Random.insideUnitSphere * range;
//            NavMeshHit hit;
//            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
//            {

//                genered = true;
//                result = hit.position;
//                yield return result;
//            }
//            i++;
//        } while (i != count) ;
//        Debug.Log("return false");
//        result = Vector3.zero;
//        yield return result;
//    }

//    //void Update()
//    //{
//    //    Vector3 point;
//    //    if (RandomPoint(transform.position, range, out point))
//    //    {
//    //        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
//    //    }
//    //}

//    [SerializeField] private GameObject[] prefabs;
//    [SerializeField] private int count = 20;

//    void Start()
//    {
//        genered = false;

//    }

//    private void Update()
//    {
//        if (!genered)
//        {
//            Spawn();
//        }
//    }
//    public void Spawn()
//    {
        
//            Debug.Log("In while");
//            Vector3 point;
//            foreach(var position in RandomPoint(transform.position, range))
//            {
//                if ( position != new Vector3(0, 0, 0))
//                { 
//                    Debug.Log("In if");
//                    //position = new Vector3(Random.Range(-45, 45), 2, Random.Range(-45, 45));
//                    //Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
//                    int i = Random.Range(0, 1);
//                    var o = Instantiate(prefabs[i], position, prefabs[i].transform.rotation);
//                    Debug.Log("instance " + o);
//                }
           
//            }
//    }
//}