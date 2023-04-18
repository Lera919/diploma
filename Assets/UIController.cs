using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    private int _score;
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
}
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
}
    void Start()
    {
        _score = 0;
        scoreLabel.text = "Score " + _score.ToString();
     
    }
    private void OnEnemyHit()
    {
        _score += 1; 
        scoreLabel.text = "Score "+ _score.ToString();
    }


}