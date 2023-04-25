using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.EatHandler();
        }

        Destroy(gameObject);
    }
}
