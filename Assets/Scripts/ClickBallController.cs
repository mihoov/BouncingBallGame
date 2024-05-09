using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBallController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float timeAtMouseDown;
    private float timeElapsed;
    private float power;
    private const float MAX_TIME_ELAPSED = 3.0f;
    private const float TIMER_NOT_STARTED = -1.0f;
    private bool firstClick;
    private BallLaunchController ballLaunchController;

    [SerializeField]
    private PowerBarHandler powerBarHandler;

    // Start is called before the first frame update
    void Start()
    {
        ballLaunchController = GetComponent<BallLaunchController>();
        firstClick = true;
        timeAtMouseDown = TIMER_NOT_STARTED;
    }

    private void Update()
    {
        if (timeAtMouseDown > 0 && firstClick)
        {
            timeElapsed = Time.time - timeAtMouseDown;
            power = Mathf.Min(timeElapsed, MAX_TIME_ELAPSED)/MAX_TIME_ELAPSED;
            powerBarHandler.SetFillAmount(power);
        } 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (firstClick)
        {
            timeAtMouseDown = Time.time;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (firstClick)
        {
            firstClick = false;

            // Launch ball.
            ballLaunchController.LaunchBall(power);
        }
    }

    public void FakePointerUp()
    {
        firstClick = false;
    }

    public void ResetClickController()
    {
        firstClick = true;
        timeAtMouseDown = TIMER_NOT_STARTED;
    }
}
