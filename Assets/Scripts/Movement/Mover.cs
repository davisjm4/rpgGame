using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            updateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            //GetComponent<ActionScheduler>.StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
           // print("now running MoveTo method, setting navMeshAgent.isStopped to false");
            navMeshAgent.isStopped = false;
           // print("isStopped: " + navMeshAgent.isStopped);
            navMeshAgent.destination = destination;
            updateAnimator();
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private void updateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
