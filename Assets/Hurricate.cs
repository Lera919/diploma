using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurricate : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.CanTeleport = true; 
            Destroy(gameObject);
        }
       
    }
}
