using System;
using System.Collections;
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

    void Start()
    {
        StartCoroutine(ChangeAngle());
    }
        
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

        //var faja = transform.Find("Faja").Find("Cylinder");
        //faja.transform.eulerAngles = new Vector3(faja.transform.eulerAngles.x, _targetAngle, faja.transform.eulerAngles.z);
        //        var angle = Mathf.LerpAngle(faja.localEulerAngles.y, _targetAngle, Time.time);
        //        faja.transform.localEulerAngles = new Vector3(0, angle, 0);
        //        if (faja.transform.localEulerAngles.y == _targetAngle)
        //        {
        //            _targetAngle = -_targetAngle;
        //        }
//        var desiredRotQ = Quaternion.Euler(faja.transform.localEulerAngles.x, 1000000, faja.transform.localEulerAngles.z);
//        faja.transform.localRotation = Quaternion.Lerp(faja.transform.localRotation, desiredRotQ, Time.deltaTime * 1f);
//        if (faja.transform.rotation.y == _targetAngle)
//        {
//            _targetAngle = -_targetAngle;
//        }
    }

    private IEnumerator ChangeAngle()
    {
        yield return new WaitForSeconds(4);
        _targetAngle = -_targetAngle;

        StartCoroutine(ChangeAngle());
    }

    private float _targetAngle = 90;
}
