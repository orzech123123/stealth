using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private InputManager _inputManager;
    private List<IPoi> _pois;
    public NavMeshAgent agent;
    public Camera camera;

    [Inject]
    private void Initialize(InputManager inputManager, List<IPoi> pois)
    {
        _inputManager = inputManager;
        _pois = pois;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inputManager.WasClicked)
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
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