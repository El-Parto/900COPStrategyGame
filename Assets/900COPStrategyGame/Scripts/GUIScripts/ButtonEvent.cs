using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField, Tooltip("this button's tooltip")] private GameObject personalToolTip;
    [SerializeField] private GameObject[] openClose;
    [SerializeField] private float fastMove;
    private bool open;

    private void Start()
    {
        fastMove = 3 * Time.fixedDeltaTime;
    }

    #region pointerEvents
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (personalToolTip != null)
        {
            open = true;
        }
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        if (personalToolTip != null)
        {
            open = false;
        }
    }
    #endregion
    
    private void FixedUpdate()
    {
        Move(open);
    }


    private void Move(bool _open)
    {
        if (!_open)
        {
            personalToolTip.transform.position = new Vector3(openClose[1].transform.position.x, Mathf.Lerp(
                personalToolTip.transform.position.y, openClose[0].transform.position.y, fastMove));
        }
        else
        {
            personalToolTip.transform.position = new Vector3(openClose[0].transform.position.x, Mathf.Lerp(
                personalToolTip.transform.position.y, openClose[1].transform.position.y, fastMove));
        }
    }
}
