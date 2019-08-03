using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

    private InputManager _inputManager;

    [Inject]
    void Initialize(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputManager.IsClicked())
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //agent.updatePosition = false;
                agent.SetDestination(hit.point);
            }
        }

        if (Mathf.Abs(agent.velocity.x) > 0 || Mathf.Abs(agent.velocity.y) > 0 || Mathf.Abs(agent.velocity.z) > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
