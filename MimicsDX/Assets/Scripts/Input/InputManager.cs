using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerDirection playerDirection;
    private PlayerAnimator playerAnimator;
    private PlayerSword playerSword;


    CharacterInput characterInput;

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        playerDirection = GetComponent<PlayerDirection>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerSword = GetComponentInChildren<PlayerSword>();

        if (characterInput == null)
        {
            characterInput = new CharacterInput();
            characterInput.CharacterMovement.Movement.performed += i => playerController?.HandleMovementInput(i.ReadValue<Vector2>());
            characterInput.CharacterMovement.Movement.performed += i => playerDirection?.GetMovementInput(i.ReadValue<Vector2>());
            //characterInput.CharacterMovement.Movement.canceled += i => playerDirection?.CacheLastInput(i.ReadValue<Vector2>());

            characterInput.CharacterActions.AButton.performed += i => playerSword?.StartAttack();
            characterInput.CharacterActions.AButton.performed += i => playerAnimator.AttackSprite();
        }

        characterInput.Enable();
    }

}
