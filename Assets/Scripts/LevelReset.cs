using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] GameObject ball;
    [SerializeField] PowerBarHandler powerBarHandler;

    BallLaunchController ballLaunchController;
    BallPointerController ballPointerController;
    ClickBallController clickBallController;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = ball.transform.position;
        ballLaunchController = ball.GetComponent<BallLaunchController>();
        ballPointerController = ball.GetComponent<BallPointerController>();
        clickBallController = ball.GetComponent<ClickBallController>();
    }

    public void TriggerLevelReset()
    {
        ball.transform.position = startPosition;
        ballLaunchController.ResetLauncher();
        ballPointerController.ResetPointer();
        clickBallController.ResetClickController();
        powerBarHandler.ResetPowerBar();
    }
}
