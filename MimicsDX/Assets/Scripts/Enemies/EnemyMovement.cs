using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _patrolPoints;
    [SerializeField] private float _acceptanceRadius;
    private int _currentPoint;
    private enum EnemyState
    {
        PATROL,
        FOLLOW
    }
    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

}
