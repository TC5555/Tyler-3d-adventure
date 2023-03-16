using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
 
    public UIItem(Item item)
    {
        spriteImage = GetComponent<Image>();

        this.item = item;
        GetComponent<Image>().sprite = this.item.icon;
    }
    
    private void Awake()
    {
        spriteImage = GetComponent<Image>();
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            spriteImage.color = Color.white;
            GetComponent<Image>().sprite = this.item.icon;     
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       if(this.item != null)
        {
            Tooltip.instance.GenerateTooltip(this.item);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.instance.GetComponent<Image>().color = new Color(1,1,1,0);
        Tooltip.instance.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, 0);
    }

}
