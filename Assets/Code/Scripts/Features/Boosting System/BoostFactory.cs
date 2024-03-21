

using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BoostingSystem{
    public class BoostFactory : MonoBehaviour{
        
        [Inject]
        private  Player player;
        private List<GameObject> boosts = new List<GameObject>();
        
        [SerializeField]
        public List<GameObject> boostPrefabs;
        void Awake(){
            boosts.AddRange(this.boostPrefabs);
        }
        public GameObject CreateBoost(){
            var randomBoost = boosts[Random.Range(0,boosts.Count)];
            var randomPositons = GetRandomPositionAround(player.gameObject.transform.position);
            var rotation = Quaternion.identity;
            var boostObj = Instantiate(randomBoost, randomPositons, rotation);
            return boostObj;
        }   
        private static Vector3 GetRandomPositionAround(Vector3 center)
        {
            var max = 50;
            Vector3 randomPosition;
                float randomX = Random.Range(-max, max);
                float randomZ = Random.Range(-max, max);
                randomPosition = new Vector3(randomX, 1, randomZ);
            if (Vector3.Distance(randomPosition, center) < 10)
                randomPosition += new Vector3(0,0,randomZ*2);

            return randomPosition;
        }

    }

}
