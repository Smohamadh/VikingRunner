using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;



[RequireComponent(typeof(Image))]
public class Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    public enum  State
    {
        Idle,
        Left,
        Right,
     
    }
    
    public UnityEvent OnRight;
    public UnityEvent OnLeft;

    [SerializeField] private State _state;

    public State state
    {
        get => _state;
        private set
        {
            if(value==_state)
                return;
            
            _state = value;

        }
    }

    private bool isDrag;
    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
     //   Debug.Log("OnDrag"+eventData.delta);
     if (eventData.delta.x > 0)
     {
         OnRight.Invoke();
         state =  State.Right;
     }
     else
     {
         OnLeft.Invoke();
         state = State.Left;
     }
    }

    private void Update()
    {
        if (isDrag)
        {
            isDrag = false;
            return;
        }

        state = State.Idle;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag"+eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
     //   Debug.Log("OnEndDrag"+eventData.delta);
    }
}
