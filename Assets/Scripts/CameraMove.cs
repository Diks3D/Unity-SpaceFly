using UnityEngine;

public class CameraMove : MonoBehaviour
{
     [SerializeField] private Transform _target;

    private void Start()
    {
        transform.parent = null;    
    }

    private void LateUpdate()
    {
        if (!_target) return;

        transform.position = new Vector3(_target.position.x, _target.position.y, -10);
    }
}
