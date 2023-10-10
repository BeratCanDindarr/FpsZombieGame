using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FireButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Image fireButtonImage;
    private void Start()
    {
        fireButtonImage = gameObject.GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Gun.ClickFire(true);
        //fireButtonImage.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Gun.ClickFire(false);
        //fireButtonImage.enabled = true;
    }

}
