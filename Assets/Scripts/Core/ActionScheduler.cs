﻿using System.Collections;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if(currentAction == action) return; 
            if(currentAction != null )
            {
                currentAction.Cancel();
                print("Cancelling" + currentAction);
            }
            currentAction = action;
        }
    }
}