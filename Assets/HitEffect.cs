using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public static HitEffect _instance;

    private void Awake() {
        _instance = this;
    }

    public void HitReaction(SkinnedMeshRenderer meshRenderer , Material HitMatrial){
        Material[] mats = meshRenderer.materials;
        mats[1] = HitMatrial;
        meshRenderer.materials = mats;
        StartCoroutine(RemoveHitReaction(meshRenderer, 0.3f));
        
    }


    IEnumerator RemoveHitReaction(SkinnedMeshRenderer meshRenderer , float seconds){
        yield return new WaitForSeconds(seconds);
        if (meshRenderer != null){
            Material[] mats = meshRenderer.materials;
            mats[1] = mats[0];
            meshRenderer.materials = mats;
            
        }
    }
    
    
}
