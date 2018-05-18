using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class WardrobeInteraction : HidingInteractable
    {
        public Collider colliderNonTrigger;
        public GameObject player;
        public Transform HiddenPosition;
        public Transform ExitPosition;
        private bool interacted;

        private void Start()
        {
            IsLoosingControl = true;
        }

        public void Update()
        {
    
            if (interacted)
            {
                var playerPos = player.transform.position;
                player.transform.position = Vector3.Lerp(playerPos, HiddenPosition.position, .1f);
                Debug.Log("Zinteraktowalem");
            }
            else
            {

            }


        }
        IEnumerator ExitiningAnimation()
        {
            do
            {
                yield return null;
                var playerPos = player.transform.position;
                player.transform.position = Vector3.Lerp(playerPos, ExitPosition.position, .1f);
            } while (Vector3.Distance(player.transform.position, ExitPosition.position) >.1f);
            Movement.enabled = true;

        }
        public override void Interact()
        {
            if (interacted)
            {
                interacted = false;
                StartCoroutine("ExitiningAnimation");
                colliderNonTrigger.enabled = true;
                //Debug.Log("Zinteraktowalem");
            }
            else
            {
                interacted = true;
                Movement.enabled = false;
                colliderNonTrigger.enabled = false;
               // Debug.Log("Zinteraktowalem");
            }
        }
    }
}
