using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float radius = 2.0f;

    [SerializeField]
    private LayerMask collisionMask;

    [SerializeField]
    private GameObject arrowPrefab;

    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void UpdateMovement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 horizontalForce = Vector3.zero;
        Vector3 verticalForce = Vector3.zero;

        _animator.SetBool("Moving", horizontalAxis != 0 || verticalAxis != 0);

        if (verticalAxis != 0)
        {
            _animator.SetBool("FacingUp", verticalAxis > 0);
            _animator.SetBool("MovingVertically", true);

            verticalForce = Vector3.up * verticalAxis;
        }

        if (horizontalAxis != 0)
        {
            bool facingRight = horizontalAxis > 0;

            _animator.SetBool("FacingRight", facingRight);
            _animator.SetBool("MovingVertically", false);

            gameObject.transform.rotation = facingRight
                ? Quaternion.identity
                : Quaternion.Euler(0, 180, 0);

            horizontalForce = Vector3.right * horizontalAxis;
        }

        Vector3 forces = horizontalForce + verticalForce;

        gameObject.transform.position += forces.normalized * Speed * Time.deltaTime;
    }

    private void Update()
    {
        UpdateMovement();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, mousePosition, radius, collisionMask);

            if (hit.collider != null)
            {
                FireBall(gameObject.transform.position - mousePosition);
            }
        }
    }

    public void FireBall(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Instantiate(arrowPrefab, gameObject.transform.position, rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, 10.0f);
    }
}
