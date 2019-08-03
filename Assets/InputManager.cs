using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : ITickable
{
    public void Tick()
    {
        Debug.Log("11");
    }

    public bool IsClicked()
    {
        return Input.GetMouseButtonDown(0);
    } 
}
