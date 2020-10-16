using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight);

public static class EventHandler 
{
    //Movent Events
    public static event MovementDelegate MovementEvent;

    //Movment Event call for publishers
    public static void CallMovmentEvent(float inputX, float inputY, bool isWalking,
    bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingRight, bool isLiftingLeft, bool isLiftingUp, bool isLiftingDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingToolRight, bool isSwingToolLeft, bool isSwingToolUp, bool isSwingToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {
        if(MovementEvent != null)
        {
            MovementEvent(inputX, inputY, 
                isWalking, isRunning, 
                isIdle, isCarrying,toolEffect, 
                isUsingToolRight, isUsingToolLeft, isSwingToolUp, isUsingToolDown,
                isLiftingRight, isLiftingLeft, isLiftingUp, isLiftingDown,
                isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
                isSwingToolRight, isSwingToolLeft, isSwingToolUp, isUsingToolDown,
                idleRight, idleLeft, idleUp, idleDown);
        }
    }
}
