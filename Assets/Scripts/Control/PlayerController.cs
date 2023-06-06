using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;
using Unity.VisualScripting;
using RPG.Core;
using static UnityEngine.GraphicsBuffer;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour, IAction
    {
        Mover mover;
        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (InteractWithCombat())
                {
           //         print("interactingWithCombat");
                    return;
                }
                if (InteractWithMovement())
                {
                   // print("Trying to move");
                    return;
                }
                print("Nothing to do");
            }
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0))
                {
                   // GetComponent<Mover>().MoveTo(hit.point);
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            GetComponent<ActionScheduler>().StartAction(this);
            //GetComponent<Fighter>().Cancel();
            if (Input.GetMouseButton(0))
            {
                moveToCursor();
               // print("Trying to move to cursor");
                return true;
            }
            return false;
        }

        private void moveToCursor()
        {
           // print("Running moveTCursor");
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
          //  print("checking if his is true" + hasHit.ToString());
            if (hasHit)
            {
           //     print("successful rayCast hit, running MoveTo method");
                mover.MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void Cancel()
        {
            mover.Cancel();
        }
    }
}
