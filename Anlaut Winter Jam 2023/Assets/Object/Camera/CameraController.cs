using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followingSpeed = 5f;

    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.Log(_offset);
        Vector3 newCameraPosition = _playerTransform.position + _offset;
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, newCameraPosition, _followingSpeed * Time.deltaTime);
    }
}
