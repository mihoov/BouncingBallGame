using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarHandler : MonoBehaviour
{
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("BarFill").GetComponent<Image>();

        barImage.fillAmount = 0f;
    }

    public void SetFillAmount(float fillPercentage)
    {
        barImage.fillAmount = fillPercentage;
    }

    public void ResetPowerBar()
    {
        barImage.fillAmount = 0f;
    }

}
