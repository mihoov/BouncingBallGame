using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    LevelReset levelReset;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => levelReset.TriggerLevelReset());
    }
}
