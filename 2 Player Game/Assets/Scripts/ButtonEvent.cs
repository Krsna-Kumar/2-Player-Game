using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Range(0.1f, 5.0f)]
    
    public float seconds = 1.0f;

    public bool pointerDown;
    public bool pointerHold;
    public bool pointerRelease;
    public UnityEvent onPointerDown;
    public UnityEvent onPointerHold;
    public UnityEvent onPointerUp;
 
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(TrackTimePressed());
        pointerDown = true;
        pointerHold = false;
        pointerRelease = false;
        //Debug.Log("Pointer Down");
        onPointerDown.Invoke();
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        pointerRelease = true;
        pointerDown = false;
        pointerHold = false;
        //Debug.Log("pointerRelease");
        onPointerUp.Invoke();
        StopAllCoroutines();
    }
 
    private IEnumerator TrackTimePressed()
    {
        float time = 0;
 
 
        while (time < this.seconds)
        {
            time += Time.deltaTime;
            yield return null;
        }
 
        onPointerHold.Invoke();

        pointerHold = true;
        pointerRelease = false;
        pointerDown = false;
        //Debug.Log("pointerHold");
        //onPointerUp.Invoke();
    }
}
