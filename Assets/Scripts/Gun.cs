using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Gun : MonoBehaviour
{
    private const int Size = 40;
    private Camera _camera;
    private float _posX;
    private float _posY;
    private readonly string _gunLabel = "+";

    void Start()
    {
        _camera = GetComponent<Camera>();
        _posX = _camera.pixelWidth / 2 - Size / 4;
        _posY = _camera.pixelHeight / 2 - Size / 2;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(_posX, _posY, Size, Size), _gunLabel);
    }

    public void Shoot()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        GameObject hitObject = hit.transform.gameObject;
        ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
        
        if (target != null)
        {
            target.ReactToHit();
        }
    }
}
