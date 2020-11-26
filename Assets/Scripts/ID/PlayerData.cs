using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ID
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Player Data")]
    [HideReferenceObjectPicker]
    [InlineEditor]
    public class PlayerData : ScriptableObject
    {
        [BoxGroup("Movement")]
        public bool applyMovement = true;
        
        [BoxGroup("Movement", CenterLabel = true)]
        [EnableIf("applyMovement")]
        public float movementSpeed = 4f;
        
        [BoxGroup("Jumping", CenterLabel = true)] 
        public bool applyGravity = true;
        
        [BoxGroup("Jumping")]
        public float maxJumpHeight = 3.6f;
        
        [BoxGroup("Jumping")]
        public float minJumpHeight = .3f;
        
        [BoxGroup("Jumping")]
        public float timeToJumpApex = .36f;
        
        [BoxGroup("Jumping")]
        public float maxVelocityY = 15f;
        
        [BoxGroup("Jumping")]
        public float coyoteTime = .15f;
        
        [BoxGroup("Jumping")]
        public float groundTime = .15f;
    } 
}

