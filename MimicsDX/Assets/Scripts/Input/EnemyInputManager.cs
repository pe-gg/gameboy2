using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputManager : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerDirection playerDirection;


    CopyEnemyInput characterInput;

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        playerDirection = GetComponent<PlayerDirection>();

        if (characterInput == null)
        {
            characterInput = new CopyEnemyInput();
            characterInput.EnemyMovement.Movement.performed += i => playerController?.HandleMovementInput(i.ReadValue<Vector2>());
            characterInput.EnemyMovement.Movement.performed += i => playerDirection?.GetMovementInput(i.ReadValue<Vector2>());
        }

        characterInput.Enable();
    }

}
