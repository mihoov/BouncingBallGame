using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
            Loader.Load(Loader.SceneEnum.MainMenu));
    }
}