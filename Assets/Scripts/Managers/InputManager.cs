using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    private static Controls _controls;

    public static void Init(Player myPlayer)
    {
        _controls = new Controls();

        _controls.GAME.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };

        _controls.GAME.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _controls.GAME.Shoot.started += ctx =>
        {
            myPlayer.Shoot();
        };

        _controls.GAME.Reload.started += ctx =>
        {
            myPlayer.Reload();
        };



        _controls.Permanent.Enable();

    }

    public static void GameMode()
    {
        _controls.GAME.Enable();
        _controls.UI.Disable();
    }

    public static void UIMode()
    {
        _controls.GAME.Enable();
        _controls.UI.Disable();

    }


  





}
