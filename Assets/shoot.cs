using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    [SerializeField] private Text Attempts;
    [SerializeField] private MessageController MeassageController;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioClip failSound;

    [SerializeField] private GameObject fireballPrefab;
    public PauseController pauseController;
    public int size = 500;
    private float _attempts = 5;
    private float _leftAttempts;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _leftAttempts = _attempts;
        Attempts.text = $"Attemts {_leftAttempts}/{_attempts}";
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; 
         Cursor.visible = false;
    }
    
private IEnumerator SphereIndicator(Vector3 pos)
{
        //    var sphere_fireball = Instantiate(fireballPrefab) as GameObject;
        //    sphere_fireball.transform.position = transform.TransformPoint((Vector3.forward + new Vector3(0, 0.5f, 0)) * 1.5f);
        //    sphere_fireball.transform.rotation = transform.rotation;

        ////        GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ////sphere.transform.position = pos;
        ////    sphere.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        soundSource.PlayOneShot(failSound);
        yield return new WaitForSeconds(1); 
    //    Destroy(sphere_fireball); 
 }
}


