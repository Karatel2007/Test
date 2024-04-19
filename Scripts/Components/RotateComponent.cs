using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] private Direction direction;
    [SerializeField] private float speed;

    private bool isWorking = true;

    private void Update()
    {
        if (isWorking)
        {
            switch (direction)
            {
                case Direction.X:
                    transform.Rotate(Vector3.right * speed * Time.deltaTime);
                    break;
                case Direction.Y:
                    transform.Rotate(Vector3.up * speed * Time.deltaTime);
                    break;
                case Direction.Z:
                    transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                    break;

            }
        }
    }

    public void ContinueRotating()
    {
        isWorking = true;
    }
    public void StopRotating()
    {
        isWorking = false;
    }
}

public enum Direction
{
    X, Y, Z
}
