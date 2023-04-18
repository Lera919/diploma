using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            StartCoroutine(TeleportPlayer(player));
        }

        StartCoroutine(Destroy());


    }

    IEnumerator TeleportPlayer(PlayerCharacter player)
    {
        Debug.Log("Teleport player");
        yield return new WaitForSeconds(2f);
        if (player.CanTeleport)
        {
            player.Teleport();
            player.CanTeleport = false;
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
