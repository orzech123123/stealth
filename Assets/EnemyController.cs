using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyController : MonoBehaviour
{
    private InputManager _inputManager;
    private List<IPoi> _pois;
    public NavMeshAgent agent;
    public Camera camera;
    [SerializeField] protected float m_frequency = 1.0F;

    [SerializeField] protected Vector3 m_from = new Vector3(0.0F, 45.0F, 0.0F);
    [SerializeField] protected Vector3 m_to = new Vector3(0.0F, -45.0F, 0.0F);

    [Inject]
    private void Initialize(InputManager inputManager, List<IPoi> pois)
    {
        _inputManager = inputManager;
        _pois = pois;
    }

    private void FixedUpdate()
    {
        var faja = transform.Find("Faja");
        var from = Quaternion.Euler(m_from);
        var to = Quaternion.Euler(m_to);

        var lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * m_frequency));
        faja.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }

    private void Update()
    {
        if (Mathf.Abs(agent.velocity.x) > 0 || Mathf.Abs(agent.velocity.y) > 0 || Mathf.Abs(agent.velocity.z) > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            var poi = _pois[Random.Range(0, _pois.Count)];
            agent.SetDestination(poi.Position);

            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }
}