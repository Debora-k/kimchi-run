using UnityEngine;

public enum GameState
{
    Intro,
    Playing,
    Dead
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State = GameState.Intro;

    [Header("References")]
    public GameObject IntroUI;
    public GameObject EnemySpawner;
    public GameObject FoodSpawner;
    public GameObject GoldenSpawner;



    void Awake()
    {
        if (Instance == null)
        {
            //for sharing GameManager
            Instance = this;
        }
    }
    void Start()
    {
        IntroUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            State = GameState.Playing;
            IntroUI.SetActive(false);
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldenSpawner.SetActive(true);

        }
    }
}
