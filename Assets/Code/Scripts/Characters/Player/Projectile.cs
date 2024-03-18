using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    // [Inject]
    // public ProjectileManager projectileManager; 
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(-1, 0, 0));
    }
    private void OnTriggerEnter(Collider other) {
        var Obj = other.gameObject;
        if(Obj.CompareTag("Enemy")){
            Obj.GetComponent<Health>().OnHit(damage);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "World Border"){
            Destroy(this.gameObject);
        }
    }
}
