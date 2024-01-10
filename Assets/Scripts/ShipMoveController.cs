using System.IO;
using UnityEditor.Callbacks;
using UnityEngine;

public class ShipMoveController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5.0f;
    [SerializeField] float _maxRotationAngle = 5.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //float moveX = Input.GetAxis("Horizontal") * speed * 100 * Time.fixedDeltaTime;
        //float moveY = Input.GetAxis("Vertical") * speed * 100 * Time.fixedDeltaTime;
        //_rb.velocity = transform.TransformDirection(new Vector3(moveX, moveY, 0));
        if(Input.GetMouseButton(0)){
            //Rotate ship for mouse point with max rotate angle restricted
            Vector3 _mouseDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
            float _deltaAngle = Vector3.SignedAngle(transform.up, _mouseDirection, transform.forward);
            _deltaAngle = Mathf.Clamp(_deltaAngle, -1 * _maxRotationAngle, _maxRotationAngle);
            transform.Rotate(new Vector3(0, 0 ,_deltaAngle * Time.fixedDeltaTime));

            //Move ship to mouse point position
            transform.Translate(Vector3.up * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
