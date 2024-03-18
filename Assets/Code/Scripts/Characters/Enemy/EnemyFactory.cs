using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour{
    [Inject]
    public WaveManager waveManager;

    private int SpawnedCount = 0;
    public GameObject Spawn(GameObject SpawnPrefab,Vector3 position,Quaternion rotation,Transform transformParent){
        var unit = Instantiate(SpawnPrefab, position, Quaternion.identity, transformParent);

        unit.gameObject.name = SpawnPrefab.gameObject.name + SpawnedCount;
        SpawnedCount++;
        
        unit.GetComponent<EnemyAI>().waveManager = waveManager;
        return unit;
    }
}
