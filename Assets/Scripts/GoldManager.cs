using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;

    public int currentGold;

    [SerializeField]
    private int gold;
    [SerializeField]
    private TextMeshProUGUI goldText;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentGold = 0;

        goldText.text = currentGold.ToString();
    }
    private void OnEnable()
    {
        Enemy.OnTriggerEnemy += AddGold;
    }
    private void OnDisable()
    {
        Enemy.OnTriggerEnemy -= AddGold;
    }

    private void AddGold(int value)
    {
        value = gold;
        currentGold += gold;
        goldText.text = currentGold.ToString();
    }

    public void RemoveGold(int value)
    {
        currentGold -= value;
        goldText.text = currentGold.ToString();
    }
}
