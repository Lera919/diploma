using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{ 
    void OnTriggerEnter(Collider other)
    {       
        
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            Debug.Log($"Eate! {player.Score}");
            
            player.Eat();
        }

        Destroy(gameObject);
    }
    
}
