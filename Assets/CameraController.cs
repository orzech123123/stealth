using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _borderOffset = 0.05f;

    private InputManager _inputManager;

    [Inject]
    void Initialize(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID

#endif
#if UNITY_ANDROID

        if (Input.mousePosition.y > Screen.height * (1 - _borderOffset))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed, Space.World);
        }
        if (Input.mousePosition.y < Screen.height * _borderOffset)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed, Space.World);
        }
        if (Input.mousePosition.x > Screen.width * (1 - _borderOffset))
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed, Space.World);
        }
        if (Input.mousePosition.x < Screen.width * _borderOffset)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed, Space.World);
        }
#endif
    }
}
