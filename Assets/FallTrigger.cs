using UnityEngine;
using System;
using UnityEngine.Events;
public class FallTrigger : MonoBehaviour
{
    public UnityEvent onPinFall=new();
    public bool isPinFallen = false;
    private void OnTriggerEnter(Collider triggeredObject){
        
        if(triggeredObject.gameObject.CompareTag("Ground")&& !isPinFallen){
            isPinFallen=true;
            Debug.Log($"{gameObject.name} has fallen");
            onPinFall?.Invoke();
        }

    }
}
