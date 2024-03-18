using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class WaveManager : MonoBehaviour
{
    [Inject]
    private MatchManager matchManager;
    [Inject]
    private EnemyFactory enemyFactory;

    public static WaveStates CurrentWaveState;
    private FormationBase _formation;
    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            transform.position = GetRandomPosForSPawn();
            return _formation;
        }
        set => _formation = value;
    }
    public GameObject SpawnPrefab;
    public static List<GameObject> _spawnedUnits = new List<GameObject>();
    public List<Vector3> _points = new List<Vector3>();
    public Transform _parent;
    [SerializeField] public float _unitSpeed = 2;

    [Tooltip("Square roots 2")]public int SpawnCount = 1;

    
    // Start is called before the first frame update
    public void Awake(){
        WaveStart();
    }

    // Update is called once per frame
    public void FixedUpdate(){
        if (CurrentWaveState == WaveStates.insideWave && _spawnedUnits.Count <= 0 ){
            WaveExit();
        }
    }

    public void WaveStart(){
        if (GameStateManager.GameState == GameStateManager.GameStates.MainGameIsRunning){
            CurrentWaveState = WaveStates.insideWave;
            SetFormation();
        }
    }
    private void SetFormation() {
        _points.Clear();
        _points = Formation.EvaluatePoints(SpawnCount).ToList();
        Spawn(_points);
            // if (_points.Count > _spawnedUnits.Count) {
            //     var remainingPoints = _points.Skip(_spawnedUnits.Count);
            // }
        // for (var i = 0; i < _spawnedUnits.Count; i++) {
        //     //_spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
        // }
    }

    private void Spawn(IEnumerable<Vector3> points) {
        foreach (var pos in points) {
            var unit = enemyFactory.Spawn(SpawnPrefab, transform.position + pos, Quaternion.identity, _parent);
            _spawnedUnits.Add(unit);
        }
    }

    public Vector3 GetRandomPosForSPawn(){
        var worldBorder = GameObject.Find("World Border");
        var RandX = UnityEngine.Random.Range(worldBorder.transform.localScale.x * -1,worldBorder.transform.localScale.x);
        var RandZ = UnityEngine.Random.Range(   worldBorder.transform.localScale.z * -1,worldBorder.transform.localScale.z);

        return new Vector3(RandX, 0.0f, RandZ);
    }

    private void Kill(int num) {
        for (var i = 0; i < num; i++) {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }


    void WaveExit(){
        CurrentWaveState = WaveStates.outsideWAve;
        matchManager.OnWaveEnd();
    }


    public void RemoveDiedEnemyAI(GameObject enemyAI){
        _spawnedUnits.Remove(enemyAI);
    }

    public void DestroyAllEnemies(){
        foreach (var unit in _spawnedUnits){
            Destroy(unit);
        }
        _spawnedUnits.Clear();
    }

    public enum WaveStates{
        insideWave,
        outsideWAve 
    }

}
