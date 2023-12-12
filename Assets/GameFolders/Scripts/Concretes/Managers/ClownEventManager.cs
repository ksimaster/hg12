using AI;
using Controllers;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClownEventManager : SingletonMonoObject<ClownEventManager>
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _enemyWhiteClownTransform;
    
    [SerializeField] Transform[] _eventRandomEnemyPositions;
    [SerializeField] Transform _eventPlayerPos;

    public event System.Action OnEventStarted;
    public event System.Action OnEventCompleted;
    

    Vector3 _lastPlayerPos;
    Vector3 _lastEnemyPos;

    private void Awake()
    {
        SingletonThisObject(this);

    }
    public void GameStarted()
    {
        StartCoroutine(GetTransformsWithDelay(7f));
    }
    private void Start()
    {
        GameManager.Instance.OnGameRestart += HandleOnGameRestart;

    }

    private void HandleOnGameRestart()
    {
       
    }

    public void FinishEvent()
    {
        
        OnEventCompleted?.Invoke();
        PlayerInventoryManager.Instance.DecreaseAmmo(8);
        SoundManager.Instance.PlaySoundFromSingleSource(1);
        MoveGameObjectsToLastPositions();
        

    }
    
    void MoveGameObjectsToEventArea()
    {
        _lastPlayerPos = _player.position;
        _lastEnemyPos = _enemyWhiteClownTransform.position;
        _player.transform.position = _eventPlayerPos.position;
        _enemyWhiteClownTransform.GetComponent<NavMeshAgent>().enabled = false;
        _enemyWhiteClownTransform.transform.position = _eventRandomEnemyPositions[Random.Range(0, _eventRandomEnemyPositions.Length)].position;
        _enemyWhiteClownTransform.GetComponent<NavMeshAgent>().enabled = true;
    }
    void MoveGameObjectsToLastPositions()
    {
        _player.transform.DOMove(_lastPlayerPos,0.1f);  //doesn't work otherwise?
        _enemyWhiteClownTransform.GetComponent<NavMeshAgent>().enabled = false;
        _enemyWhiteClownTransform.transform.position = _lastEnemyPos;
        _enemyWhiteClownTransform.GetComponent<NavMeshAgent>().enabled = true;
    }
    public void StartEvent()
    {
        OnEventStarted?.Invoke();
        PlayerInventoryManager.Instance.AddAmmo(8);
        MoveGameObjectsToEventArea();
      
    }
    IEnumerator GetTransformsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerController player = FindFirstObjectByType<PlayerController>();
        AiEnemy enemy = FindFirstObjectByType<AiEnemy>();
        if ( player == null || enemy == null)
        {
            StopAllCoroutines();
            StartCoroutine(GetTransformsWithDelay(delay + 5f));
            yield break;
        }
        _player = player.transform;
        _enemyWhiteClownTransform = enemy.transform;
        yield return null;
    }

}
