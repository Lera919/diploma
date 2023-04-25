using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaserGenerator : MonoBehaviour
{
    [SerializeField] private GameObject save; 
    private GameObject _save;
    bool reload = false;
   
    void Update()
    {
        if (_save == null && !reload)
        {
            Invoke("SpawnObject", 5f);
            reload = true;
        }
    }

    void SpawnObject()
    {
        _save = Instantiate(save) as GameObject;
        _save.transform.position = this.transform.position;
        reload = false;
    }
}
