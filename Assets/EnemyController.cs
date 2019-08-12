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

    [SerializeField] protected Vector3 m_from = new Vector3(0.0F, 45.0F, 0.0F);
    [SerializeField] protected Vector3 m_to = new Vector3(0.0F, -45.0F, 0.0F);
    [SerializeField] protected float m_frequency = 1.0F;

    [Inject]
    void Initialize(InputManager inputManager, List<IPoi> pois)
    {
        _inputManager = inputManager;
        _pois = pois;
    }

    void FixedUpdate()
    {
        var faja = transform.Find("Faja");
        Quaternion from = Quaternion.Euler(this.m_from);
        Quaternion to = Quaternion.Euler(this.m_to);

        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
        faja.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }

    void Update()
    {
        if (Mathf.Abs(agent.velocity.x) > 0 || Mathf.Abs(agent.velocity.y) > 0 || Mathf.Abs(agent.velocity.z) > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            var poi = _pois[UnityEngine.Random.Range(0, _pois.Count)];
            agent.SetDestination(poi.Position);

            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}
