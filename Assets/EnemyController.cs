using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyController : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

    private InputManager _inputManager;
    private List<IPoi> _pois;

    [Inject]
    void Initialize(InputManager inputManager, List<IPoi> pois)
    {
        _inputManager = inputManager;
        _pois = pois;
    }

    // Update is called once per frame
    void Update()
    {
        //        if(_inputManager.WasClicked)
        //        {
        //            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //            RaycastHit hit;
        //
        //            if(Physics.Raycast(ray, out hit))
        //            {
        //                agent.SetDestination(hit.point);
        //            }
        //        }

//        if (agent.)
//        {
//        }

        if (Mathf.Abs(agent.velocity.x) > 0 || Mathf.Abs(agent.velocity.y) > 0 || Mathf.Abs(agent.velocity.z) > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            var poi = _pois[UnityEngine.Random.Range(0, _pois.Count())];
            agent.SetDestination(poi.Position);

            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
