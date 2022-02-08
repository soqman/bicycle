using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;

    private Vector3 position;

    private void Awake()
    {
        position = cam.transform.position;
    }

    private void Update()
    {
        position.x = target.position.x;
        cam.transform.position = position;
    }
}