using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : MonoBehaviour
{
    public int save = 1;
    void OnTriggerEnter(Collider other)
    { 
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Plus(save);
        }
        Destroy(gameObject);
    }
}
