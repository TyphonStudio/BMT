using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UnitTypeCard : DragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

    [SerializeField]
    Image image;

    public UnitType Type { get; private set; }

    bool isSelected;

    public Action<UnitTypeCard> OnSelected;
    public Action<UnitTypeCard, Vector3> OnDragEnd;

    public void Init(UnitType type)
    {
        Type = type;
        image.sprite = type.icon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isSelected)
            OnSelected?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void GetSelected(Color color)
    {
        isSelected = true;
        ChangeColor(color);
    }

    public void GetDeselected(Color color)
    {
        isSelected = false;
        ChangeColor(color);
    }

    void ChangeColor(Color color)
    {
        image.color = color;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        OnDragEnd?.Invoke(this, transform.position);
        base.OnEndDrag(eventData);
    }
}