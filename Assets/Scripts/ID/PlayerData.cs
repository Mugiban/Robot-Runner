using UnityEngine;

namespace ID
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        public bool applyMovement = true;
        
        public float movementSpeed = 4f;
        
        public bool applyGravity = true;
        
        public float maxJumpHeight = 3.6f;
        
        public float minJumpHeight = .3f;
        
        public float timeToJumpApex = .36f;
        
        public float maxVelocityY = 15f;
        
        public float coyoteTime = .15f;

        public float groundTime = .15f;
    } 
}

