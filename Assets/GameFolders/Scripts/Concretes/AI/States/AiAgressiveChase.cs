using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgressiveChase : IAiState
{
    AiEnemy _ai;
    public AiAgressiveChase(AiEnemy ai)
    {
        _ai = ai;
    }

    public AiStateId StateId => AiStateId.AggressiveChase;

    public void Enter()
    {
        _ai.NavMeshAgent.speed = _ai.CurrentMovementSpeeds[4];
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
       _ai.NavMeshAgent.SetDestination(_ai.PlayerTransform.position);
        if (Vector3.Distance(_ai.transform.position, _ai.PlayerTransform.position) < _ai.Config.MaxAttackDistance)
        {
            _ai.StateMachine.ChangeState(AiStateId.Attack);
        }
    }
}
