using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Falling Speed")]
    [SerializeField] private float startSpeed = 2f;
    [SerializeField] private float speedIncrease = 0.2f;
    [SerializeField] private float maxSpeed = 8f;

    public float CurrentFallSpeed { get; private set; }

    private void Awake()
    {
        Instance = this;
        CurrentFallSpeed = startSpeed;
    }

    private void Update()
    {
        CurrentFallSpeed += speedIncrease * Time.deltaTime;
        CurrentFallSpeed = Mathf.Min(CurrentFallSpeed, maxSpeed);
        DropContainer._speed = CurrentFallSpeed;
        /* TEST */
        //Debug.Log("Hız:" + CurrentFallSpeed);
    }
}