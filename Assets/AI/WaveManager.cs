using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager _instance;
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
    public GameObject SpawnPositon;
    public List<GameObject> _spawnedUnits = new List<GameObject>();
    public List<Vector3> _points = new List<Vector3>();
    public Transform _parent;
    [SerializeField] public float _unitSpeed = 2;

    public int SpawnCount = 1;

    
    // Start is called before the first frame update
    public void Awake(){
        _instance = this;
        WaveStart();
        
    }

    // Update is called once per frame
    public void FixedUpdate(){
        if (_spawnedUnits.Count <= 0){
            WaveExit();
        }
    }

    void WaveStart(){
        SetFormation();
    }
    private void SetFormation() {
        _points.Clear();
        _points = Formation.EvaluatePoints().ToList();
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
            var unit = Instantiate(SpawnPrefab, transform.position + pos, Quaternion.identity, _parent);
            unit.gameObject.name = SpawnPrefab.gameObject.name + Time.deltaTime.ToString();
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
        WaveStart();
    }


    public void RemoveSpawnedEnemyAI(GameObject enemyAI){
        _spawnedUnits.Remove(enemyAI);
    }

}
