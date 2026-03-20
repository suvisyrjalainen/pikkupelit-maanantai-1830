using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSelection : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public Selector menu;
    public int index;

    public void OnPointerEnter(PointerEventData eventData)
    {
        menu.SetIndex(index);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        menu.ActivateItem(index);
    }
    


}


