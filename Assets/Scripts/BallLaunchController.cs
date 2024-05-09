using UnityEngine;
using UnityEngine.UI;

public class BallLaunchController : MonoBehaviour
{
    [SerializeField] private Slider horizontalAngleSlider;
    [SerializeField] private Slider verticalAngleSlider;
    [SerializeField] private float forceMultiplier;
    private new Rigidbody rigidbody;
    private BallPointerController ballPointerController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        ballPointerController = GetComponent<BallPointerController>();
    }

    public void LaunchBall(float power) 
    {
        ballPointerController.Deactivate();

        float forceMagnitude = Mathf.Min(power, 1f) * forceMultiplier;

        // Get degree of angles from sliders in UI.
        float horizontalDegrees = Mathf.Round(horizontalAngleSlider.value * 10.0f) * 0.1f;
        float verticalDegrees = Mathf.Round(verticalAngleSlider.value * 10.0f) * 0.1f;

        // Convert degrees to radiants. 
        float horizontalRadians = horizontalDegrees * Mathf.Deg2Rad * (-1.0f);
        float verticalRadians = verticalDegrees * Mathf.Deg2Rad;

        //Calculate forces for Vector3.
        float x = forceMagnitude * Mathf.Cos(horizontalRadians) * Mathf.Cos(verticalRadians);
        float z = forceMagnitude * Mathf.Sin(horizontalRadians) * Mathf.Cos(verticalRadians);
        float y = forceMagnitude * Mathf.Sin(verticalRadians);

        Vector3 force = new Vector3(x, y, z);

        rigidbody.useGravity = true;
        rigidbody.AddForce(force);
    }

    public void ResetLauncher()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
    }

}
