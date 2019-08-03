using System;
using UnityEngine;
using Zenject;

public class InputManager : ITickable
{
    private Vector3? _lastClickPosition;
    private Vector3? _lastMovePosition;

    public void Tick()
    {
        WasClicked = Input.GetMouseButtonUp(0) && _lastClickPosition == Input.mousePosition;
        WasSwiped = false;
        SwipeDelta = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            _lastClickPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if (_lastClickPosition != null && _lastClickPosition != Input.mousePosition)
            {
                WasSwiped = true;
            }

            _lastMovePosition = Input.mousePosition;

            SwipeDelta = _lastMovePosition.Value - _lastClickPosition.Value;
        }
    }

    public bool WasClicked { get; private set; }

    public bool WasSwiped { get; private set; }

    public Vector3 SwipeDelta { get; private set; } = Vector3.zero;

    public Vector3 CursorPosition => Input.mousePosition;
}
