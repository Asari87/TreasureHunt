using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ButtonEvent { Hover, Pressed}
public class UIButtonEventNotifier : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public static Action<ButtonEvent> OnButtonEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonEvent?.Invoke(ButtonEvent.Pressed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonEvent?.Invoke(ButtonEvent.Hover);
    }
}
