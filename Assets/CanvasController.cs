using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public Image imgSelector;
    public void ChangePickableBallColor(bool isSelect)
    {
        if (isSelect)
        {
            imgSelector.color = Color.green;
        }
        else
        {
            imgSelector.color = Color.white;
        }
    }
    public void OcuktarCursor(bool ocultar)
    {
        imgSelector.enabled = !ocultar!;


    }
}
