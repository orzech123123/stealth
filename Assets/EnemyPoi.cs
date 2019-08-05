using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoi : MonoBehaviour, IPoi
{
    public Vector3 Position => transform.position;
}
