using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectRadius : MonoBehaviour
{
    private EnemyMovement _nav;
    private void Awake()
    {
        _nav = GetComponentInParent<EnemyMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter?");
        PlayerController checkEnter;
        checkEnter = collision.GetComponent<PlayerController>();
        if (checkEnter == null)
            return;
        Debug.Log("enter?");
        _nav.playerDetected = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController checkExit;
        checkExit = collision.GetComponent<PlayerController>();
        if (checkExit == null)
            return;
        Debug.Log("Exit?");
        _nav.playerDetected = false;
    }
}
