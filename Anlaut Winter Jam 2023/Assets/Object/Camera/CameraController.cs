using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followingSpeed = 5f;
    [SerializeField] private float _minZoom = 0.5f;
    [SerializeField] private float _maxZoom = 1f;
    [SerializeField] private float _zoomSpeed = 0.05f;



    private Transform _cameraTransform;
    private float _zoomLevel = 1;

    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        _cameraTransform.position = _playerTransform.position + _offset * _zoomLevel;
    }

    private void Update()
    {
        Vector3 newCameraPosition = _playerTransform.position + _offset * _zoomLevel;
        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, newCameraPosition, _followingSpeed * Time.deltaTime);

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            changeZoom();
        }
    }

    private void changeZoom()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            _zoomLevel = _zoomLevel - _zoomSpeed >= _minZoom ? _zoomLevel - _zoomSpeed : _minZoom;
        }
        else
        {
            _zoomLevel = _zoomLevel + _zoomSpeed <= _maxZoom ? _zoomLevel + _zoomSpeed : _maxZoom;
        }
    }
}
