using UnityEngine;
namespace BoostingSystem{
    public abstract class Boost : MonoBehaviour{
        public BoostTypes boostType;
        public BoostUseTypes boostUseTypes;

        public abstract void ApplyBoost(GameObject Player);
        public abstract void OnBoostEnd();
        
        void Start(){
            Destroy(gameObject,30.0f);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ApplyBoost(other.gameObject);

                Destroy(gameObject);
            }
        }
    }

    public enum BoostTypes{
        Heal,
        Speed,
        Range

    }

    public enum BoostUseTypes{
        usedOnce,
        temporary,
        Eternal
    }

}
