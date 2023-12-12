using UnityEngine;


namespace AI
{
    [CreateAssetMenu()]
    public class AiEnemyConfig : ScriptableObject
    {
        [Range(1f, 5f)] public float MaxStopTimeOnHealthDecrease;
        [Header("Movement Speeds")]  //Walk,FastWalk,Run,FastRun,Sprint
        public float[] EasyMovementSpeeds = new float[5];
        public float[] NormalMovementSpeeds = new float[5];
        public float[] HardMovementSpeeds = new float[5];
        [Header("Sight Sensor")]
        [Range(1, 150f)] public float NormalSightAngle;
        [Range(1, 150f)] public float HardSightAngle;
        [Range(1, 100f)] public float NormalSightDistance;
        [Range(1, 100f)] public float HardSightDistance;
        [Header("Chase Player State")]
        [Range(0, 5f)] public float MaxSetDestTime;
        [Range(0, 30f)] public float EasyChaseTimeout;
        [Range(0, 30f)] public float NormalChaseTimeout;
        [Range(0, 30f)] public float HardChaseTimeout;
        [Range(1f, 10f)] public float MaxAttackDistance;
        [Header("Wander/Roam State")]
        [Range(2f, 35f)] public float WanderRandomPointRadius;
        [Range(0.5f, 3f)] public float WanderRandomSamplePointRange;
        [Range(2f, 20f)] public float WanderForwardDistance;
        [Header("Idle State")]
        [Range(0.1f, 7f)] public float IdleWaitTime;
        [Header("Seek Player State")]
        [Range(0.1f,7f)] public float MaxRotationTime;
        [Range(0.1f, 5f)] public float DelayAfterRotate;
        [Range(0.1f, 15f)] public float SeekForwardDistance;
        [Range(0.5f, 3f)] public float SeekRandomSamplePointRange;
        [Range(1f,30f)] public float SeekTimeOut;
        [Header("Stunned State")]
        [Range(1f, 10f)] public float MaxStunTime;
        

        
        
    }

}
