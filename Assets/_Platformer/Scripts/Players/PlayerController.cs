using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    // References
    private Player player;
    private PlayerInput playerInput;

    // Input Action
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction skillAction;

    private void Start()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        attackAction = playerInput.actions["Attack"];
        skillAction = playerInput.actions["Skill"];
    }

    private void Update()
    {
        HandleMoveInput();

        HandleAttackInput();

        HandleSkillInput();
    }

    private void HandleMoveInput()
    {
        if (moveAction == null) { return; }
        if (jumpAction == null) { return; }

        // back to normal state if can
        if (moveAction.triggered)
        {
            if (player.CurrentState != Player.PlayerState.Normal && player.CurrentState != Player.PlayerState.Dead)
            {
                player.SwitchPlayerState(Player.PlayerState.Normal);
            }
        }


        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        // move
        player.Movement.MovePlayer(moveValue.x, jumpAction.triggered);
        // climb
        player.Movement.Climb(moveValue.y, jumpAction.triggered);
    }



    private void HandleAttackInput()
    {
        if (attackAction == null) { return; }

        if (attackAction.triggered)
        {
            player.Combat.Attack();
        }
    }

    private void HandleSkillInput()
    {
        if (skillAction == null) { return; }

        if (attackAction.triggered)
        {
            player.Combat.Skill();
        }
    }
}

