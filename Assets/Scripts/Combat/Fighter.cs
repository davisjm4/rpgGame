using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (target == null) return;
            if (!getIsInRange())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Cancel();
            }
        }

        private bool getIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("Attack");
        }

        public void Cancel()
        {
            target = null;
        }


    }
}