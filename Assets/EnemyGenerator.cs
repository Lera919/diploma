using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject boxPrefab;
    private Animator animator;
     
    void Start()
    {
         var obj = SpawnObject(boxPrefab);        
        obj.transform.position = transform.position;
        animator = obj.GetComponent<Animator>();
        animator.SetBool("Open", true);
        StartCoroutine(SpawnObject(enemyPrefab, 3f));
    }
    GameObject SpawnObject(GameObject prefab) => Instantiate(prefab);

    IEnumerator SpawnObject(GameObject prefab, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Instantiate(prefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Open", false);
    }
}

