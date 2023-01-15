using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _fristPerson;
    [SerializeField] private Transform _thirdPerson;

    [SerializeField] private float _followingSpeed = 5f;
    [SerializeField] private float _minZoom = 0.5f;
    [SerializeField] private float _maxZoom = 1f;
    [SerializeField] private float _zoomSpeed = 0.05f;

    [SerializeField] private FirstPersonPar _par;

    private Transform _staticPoint;

    private Transform _cameraTransform;
    private float _zoomLevel = 1;
    private CameraState _state;
    private bool _isAnimation;

    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        _isAnimation = false;
        _cameraTransform.position = _thirdPerson.position;
        _state = CameraState.THIRD_PERSON;
        ChangeStateToThirdPerson();

    }

    private void Update()
    {
        switch (_state)
        {
            case CameraState.THIRD_PERSON:
                if (!_isAnimation)
                    ThirdPersonMovement();

                break;
            case CameraState.FIRST_PERSON:
                FirstPersonMovement();
                break;
        }
    }

    private void ThirdPersonMovement()
    {
        Vector3 newCameraPosition = _playerTransform.position + _thirdPerson.position * _zoomLevel;
        //_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, newCameraPosition, _followingSpeed * Time.deltaTime);
        _cameraTransform.position = newCameraPosition;

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            changeZoom();
        }
    }

    private void FirstPersonMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * _par.sensitivyMouse * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * _par.sensitivyMouse * Time.deltaTime;

        Vector3 rotation = _cameraTransform.rotation.eulerAngles;
        rotation = new Vector3(rotation.x + mouseY, rotation.y + mouseX, rotation.z);

        Vector3 playerRotation = Player.Instance.Transform.rotation.eulerAngles;
        if (rotation.x >= 180)
            rotation.x -= 360;

        if (rotation.y - playerRotation.y > _par.maxX)
            rotation.y = playerRotation.y + _par.maxX;
        if (rotation.y - playerRotation.y < _par.minX)
            rotation.y = playerRotation.y + _par.minX;
        Debug.Log("1 - " + rotation);

        if (rotation.x - playerRotation.x > _par.maxY)
            rotation.x = playerRotation.x + _par.maxY;
        if (rotation.x - playerRotation.x < _par.minY)
            rotation.x = playerRotation.x + _par.minY;
        Debug.Log("2 - " + rotation);





        _cameraTransform.rotation = Quaternion.Euler(rotation);

        /*if (_cameraTransform.rotation.eulerAngles.y - _playerTransform.rotation.eulerAngles.y > _par.maxX + 1)
            _cameraTransform.rotation = Quaternion.Euler(_cameraTransform.rotation.eulerAngles.x, _par.maxX + _playerTransform.rotation.eulerAngles.y, _cameraTransform.rotation.eulerAngles.z);
        if (_cameraTransform.rotation.eulerAngles.y - _playerTransform.rotation.eulerAngles.y < _par.minX - 1)
            _cameraTransform.rotation = Quaternion.Euler(_cameraTransform.rotation.eulerAngles.x, _par.minX + _playerTransform.rotation.eulerAngles.y, _cameraTransform.rotation.eulerAngles.z);
*/

    }

    public void ChangeStateToThirdPerson()
    {
        Player.Instance.IsMove = true;
        StartCoroutine(MoveToPoint(_playerTransform, _thirdPerson, _thirdPerson));
        _state = CameraState.THIRD_PERSON;
    }

    public void ChangeStateToFirstPerson()
    {
        Player.Instance.IsMove = false;
        StartCoroutine(MoveToPoint(_fristPerson, _playerTransform));
        _state = CameraState.FIRST_PERSON;
    }

    public void ChangeStateToStatic(Transform point)
    {
        Player.Instance.IsMove = true;
        _staticPoint = point;
        StartCoroutine(MoveToPoint(_staticPoint, _staticPoint));
        _state = CameraState.STATIC;
    }

    private IEnumerator MoveToPoint(Transform position, Transform rotation)
    {
        _isAnimation = true;

        Vector3 startPosition = _cameraTransform.position;
        const float animationDuration = 1f;

        float t = 0;
        while (t < 1)
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, position.position, t);
            _cameraTransform.rotation = Quaternion.Lerp(transform.rotation, rotation.rotation, t);

            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        _isAnimation = false;
    }


    private IEnumerator MoveToPoint(Transform position, Transform rotation, Transform addedPoint)
    {
        _isAnimation = true;

        Vector3 startPosition = _cameraTransform.position;
        const float animationDuration = 1f;

        float t = 0;
        while (t < 1)
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, position.position + addedPoint.position, t);
            _cameraTransform.rotation = Quaternion.Lerp(transform.rotation, rotation.rotation, t);

            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        _isAnimation = false;
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


public enum CameraState
{
    STATIC,
    THIRD_PERSON,
    FIRST_PERSON
}


[Serializable]
public struct FirstPersonPar
{
    public float sensitivyMouse;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
}