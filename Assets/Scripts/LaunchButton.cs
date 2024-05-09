using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    private Button button;
    [SerializeField] float power;
    [SerializeField] GameObject ball;
    BallLaunchController ballLaunchController;
    ClickBallController clickBallController;

    private void Start()
    {
        ballLaunchController = ball.GetComponent<BallLaunchController>();
        clickBallController = ball.GetComponent <ClickBallController>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
            TestLaunch());
    }

    private void TestLaunch()
    {
        clickBallController.FakePointerUp();
        ballLaunchController.LaunchBall(power);
    }
}
