using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    private void Update()
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
}
