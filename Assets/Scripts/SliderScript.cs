
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener((v) =>
        {
            sliderText.text = (Mathf.Round(v).ToString("0"));
        });   
    }
}
