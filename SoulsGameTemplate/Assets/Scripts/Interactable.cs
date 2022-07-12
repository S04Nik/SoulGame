using UnityEngine;

namespace DarkSoul
{
    public class Interactable : MonoBehaviour
    {
        private float radius = 0.9f;
        public string interactableText;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        public virtual void Interact(PlayerManager playerManager)
        {
            // Called when player Interacts
            Debug.Log("YOU INTERACTED WITH OBJECT");
        }
    }

}
