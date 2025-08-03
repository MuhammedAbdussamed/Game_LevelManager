using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Koda heryerden ulaşım sağlar. ( GameManager.Instance... şeklinde ).

    public GameState state; // Bir durum oluşturur. Oyunun şimdi ki durumunu belirlemek için.

    public static event Action<GameState> OnGameStateChanged;   // State değiştiğinde event ile bunu herkese duyurmuş olacağız. Bu sayede onlarda (diğer scriptler) kendilerine düşen görevi yapacaklar.

    void Awake()
    {
        Instance = this;    // Sahnede ki GameManager örneğini Instance değişkenine koy.
    }

    void Start()
    {
        GameStateChanger(GameState.SelectDifficulty);   // Oyun başladığında bu state çağırılsın.
    }

    public void GameStateChanger(GameState newState)
    {
        state = newState;   // 1. Öncelikle, oyunun mevcut durumunu (state) parametreyle gelen yeni duruma atar.

        switch (newState)   // 2. Sonra yeni duruma göre farklı durumları kontrol eder.
        {
            case GameState.SelectDifficulty:        // Startta ilk durum buydu o yüzden bunu kontrol edecekve altında ki fonksiyonları çalıştıracak.
                Debug.Log("Please Select Difficulty");
                break;

            case GameState.RollDice:
                int sayi = UnityEngine.Random.Range(1, 6);
                Debug.Log(sayi);
                break;

            case GameState.Attack:
                Debug.Log("Attacked");
                break;

            case GameState.EnemyTurn:
                Debug.Log("Enemy turn so wait it");
                break;

            case GameState.WinScreen:
                Debug.Log("Yeah You Win");
                break;

            case GameState.LoseScreen:
                Debug.Log("Sorry You Lose");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);    // Eğer yeni state (durum) beklenmeyen bir şey olursa hata ver.
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        SelectDifficulty,

        RollDice,

        Attack,

        EnemyTurn,

        WinScreen,

        LoseScreen
    }
}
