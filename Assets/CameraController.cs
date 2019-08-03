using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _borderOffset = 0.05f;

    private InputManager _inputManager;
    private ApplicationManager _applicationManager;

    [Inject]
    void Initialize(InputManager inputManager, ApplicationManager applicationManager)
    {
        _inputManager = inputManager;
        _applicationManager = applicationManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (_applicationManager.Platform == RuntimePlatform.Android)
        {
            if (_inputManager.WasSwiped)
            {
                var x = _inputManager.SwipeDelta.x;
                var y = _inputManager.SwipeDelta.y;

                if (Mathf.Abs(y) > 0)
                {
                    var forwardDir = (transform.up + transform.forward);
                    transform.Translate(new Vector3(forwardDir.x, 0, forwardDir.z).normalized * -y / 100 * Time.deltaTime * _speed, Space.World);
                }
                if (Mathf.Abs(x) > 0)
                {
                    transform.Translate(transform.right.normalized * -x / 100 * Time.deltaTime * _speed, Space.World);
                }
            }
        }
        else
        {
            var forwardDir = (transform.up + transform.forward);
            if (_inputManager.CursorPosition.y > Screen.height * (1 - _borderOffset))
            {
                transform.Translate(new Vector3(forwardDir.x, 0, forwardDir.z).normalized * Time.deltaTime * _speed, Space.World);
            }
            if (_inputManager.CursorPosition.y < Screen.height * _borderOffset)
            {
                transform.Translate(-new Vector3(forwardDir.x, 0, forwardDir.z).normalized * Time.deltaTime * _speed, Space.World);
            }
            if (_inputManager.CursorPosition.x > Screen.width * (1 - _borderOffset))
            {
                transform.Translate(transform.right.normalized * Time.deltaTime * _speed, Space.World);
            }
            if (_inputManager.CursorPosition.x < Screen.width * _borderOffset)
            {
                transform.Translate(-transform.right.normalized * Time.deltaTime * _speed, Space.World);
            }
        }
    }
}
