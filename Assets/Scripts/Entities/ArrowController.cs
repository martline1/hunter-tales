#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D? _rigidbody2D;

    [SerializeField]
    private float maxDistance = 120.0f;

    private void Awake()
    {
        Vector3 rotationDirection = gameObject.transform.rotation.eulerAngles;

        rotationDirection.x  = 0;
        rotationDirection.y  = 0;
        rotationDirection.z -= 180;

        gameObject.transform.rotation = Quaternion.Euler(rotationDirection);
    }

    private void MoveBasedOnRotation()
    {
        float degrees = gameObject.transform.rotation.eulerAngles.z;

        float radians = (degrees - 90) * Mathf.PI / 180;

        float x = -Mathf.Cos(radians);
        float y = -Mathf.Sin(radians);

        _rigidbody2D?.AddForce(new Vector2(x, y) * speed);
    }

    private void DestroyIfDistant()
    {
        GameObject? player = null;

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 differenceVector = player.transform.position - gameObject.transform.position;

        float distance = differenceVector.sqrMagnitude;

        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        MoveBasedOnRotation();

        DestroyIfDistant();
    }
}
