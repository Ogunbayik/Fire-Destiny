using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private bool isRight;

    private void Start()
    {
        isRight = true;
    }
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var desiredDirection = Vector3.up;

        if(isRight)
        {
            transform.RotateAround(transform.position, desiredDirection, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(transform.position, desiredDirection, -rotationSpeed * Time.deltaTime);
        }
    }

    public void ChangeRotation()
    {
        isRight = !isRight;
    }

    public void ChangeRotateSpeed(float speed)
    {
        rotationSpeed += speed;
    }
}
