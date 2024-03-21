using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BoostingSystem
{
    public class BoostSystemManager : MonoBehaviour{
        [Inject]
        private BoostFactory boostFactory;
        [Range(3,15)]
        public int maxSpawnTime;
        private void Start() {
            StartCoroutine(StartSpawnBoosts());
        }

        IEnumerator StartSpawnBoosts()
        {
            boostFactory.CreateBoost();
            yield return new WaitForSeconds(Random.Range(3,maxSpawnTime));//
            StartCoroutine(StartSpawnBoosts());
        }
    }
}