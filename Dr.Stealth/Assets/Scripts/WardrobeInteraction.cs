using System;
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
        public Transform position;
        private bool interacted;
        public void Update()
        {
            if (interacted)
            {
                var playerPos = player.transform.position;
                player.transform.position = Vector3.Lerp(playerPos, position.position, .1f);
                
            }

        }
        public override void Interact()
        {
            if (interacted)
            {
                interacted = false;
                colliderNonTrigger.enabled = true;
                Debug.Log("Zinteraktowalem");
            }
            else
            {
                interacted = true;
                colliderNonTrigger.enabled = false;
                Debug.Log("Zinteraktowalem");
            }
        }
    }
}
