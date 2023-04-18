using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    // Start is called before the first frame update
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
        float angle = Random.Range(0, 360);
        //_save.transform.Rotate(0, angle, 0);
        reload = false;
    }
}
