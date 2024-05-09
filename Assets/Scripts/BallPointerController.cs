using UnityEngine;
using UnityEngine.UI;

public class BallPointerController : MonoBehaviour
{
    [SerializeField] private Slider horizontalAngleSlider;
    [SerializeField] private Slider verticalAngleSlider;

    private float horizontalAngle;
    private float verticalAngle;
    private GameObject pointerGameObject;
    private bool disabled;
    private Quaternion rotationAtDeactivate;


    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        pointerGameObject = transform.Find("DirectionalPointer").gameObject;

        horizontalAngleSlider.onValueChanged.AddListener((v) =>
        {
            horizontalAngle = v;   
        });

        verticalAngleSlider.onValueChanged.AddListener((v) =>
        {
            verticalAngle = v;
        });

        horizontalAngle = 0f;
        verticalAngle = 0f;
    }

    private void Update()
    {
        if (!disabled)
        {
            Vector3 newRotation = new Vector3(0f, horizontalAngle, verticalAngle);
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }

    public void Deactivate()
    {
        disabled = true;
        rotationAtDeactivate = transform.rotation;
        // Disable and unparent directional pointer.
        pointerGameObject.SetActive(false);
        pointerGameObject.transform.SetParent(null);
    }

    public void ResetPointer()
    {
        disabled = false;
        transform.rotation = rotationAtDeactivate;
        pointerGameObject.SetActive(true);
        pointerGameObject.transform.SetParent(this.transform);
    }
}
