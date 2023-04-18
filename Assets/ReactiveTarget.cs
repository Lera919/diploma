using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public ParticleSystem dieEffect;
    // Start is called before the first frame update
    public void ReactToHit()
    {
         EnemyController enemy = GetComponent<EnemyController>();
        // var behavior = GetComponent<enemyWandering>();
        if (enemy != null)
        {
         enemy.Alive = false;
            dieEffect.Play();
        }
        StartCoroutine(Die());
    

}
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        // animation of death
        yield return new WaitForSeconds(1.5f);
        dieEffect.Stop();
        Destroy(this.gameObject);
    }
}
