using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    [SerializeField] private Text Attempts;
    //[SerializeField] private Text Message;
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

    // Update is called once per frame
    void OnGUI()
    {

        int size = 40;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !pauseController.isPaused)
        {
            if(_leftAttempts <= 0)
            {
                StartCoroutine(MeassageController.ShowMessage("you are run out off attempts!!!"));
            }
            else
            {
                Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                Ray ray = _camera.ScreenPointToRay(point);
                 RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                    _leftAttempts -= 1;
                    soundSource.PlayOneShot(sound);

                    if (target != null)
                    {                       
                        target.ReactToHit();
                        
                    }
                    else
                    {
                        
                        // reduce the number of attempts??
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }
            }
            Attempts.text = $"Attemts {_leftAttempts}/{_attempts}";
        }
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
