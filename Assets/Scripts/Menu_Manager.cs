using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _difficultyMenu;
    void Awake()
    {
        GameManager.OnGameStateChanged += MenuChanger;
    }

    void MenuChanger(GameManager.GameState state)
    {
        if (state == GameManager.GameState.SelectDifficulty)
        {
            _difficultyMenu.SetActive(true);
        }
        else
        {
            _difficultyMenu.SetActive(false);
        }
    }

}
