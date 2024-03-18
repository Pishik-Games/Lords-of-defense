using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputHandler : MonoBehaviour {
    private PlayerInput playerInput;
    public InputAction ClickOnGameObjectAction;
    RaycastHit hit;

    public LayerMask TouchAbleLayerMask;
    void Start(){
        playerInput = GetComponent<PlayerInput>();
        ClickOnGameObjectAction = playerInput.actions["ClickOnGameObjectAction"];
    }
    private void Update() {
        if(ClickOnGameObjectAction.triggered){
            Vector2 ClickPos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(ClickPos.x, ClickPos.y, 0));
            // Perform the raycast and check if it hits a GameObject.
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,TouchAbleLayerMask)) {
                var HitObj = hit.transform.gameObject;
                Debug.Log(HitObj.name + " OnTouch Triggerd ");
                // If a GameObject was hit, check if it implements the ITouchable interface.
                if (HitObj.GetComponent<ITouchable>() != null) {
                    // If it does, call the OnTouch method.
                    HitObj.GetComponent<ITouchable>().OnTouch();
                    Debug.Log("ITouchable OnTouch Triggerd ");
                }
                else {
                    Debug.Log("No ITouchable interface found on hit GameObject.");
                }
            }
            else {
                //Debug.Log("No GameObject hit by the ray.");
            }
        }
    }
}