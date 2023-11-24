using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(-1, 0, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "World Border")
        {
            Destroy(gameObject);
        }
    }
}
