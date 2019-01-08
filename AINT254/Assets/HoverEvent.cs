using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEvent : MonoBehaviour, IPointerEnterHandler {

    [SerializeField]
    private int lvl;

    [SerializeField]
    private TitleScreenController cont;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cont.SetImagePreview(lvl);
    }
}