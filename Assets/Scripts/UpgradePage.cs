using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePage : MonoBehaviour
{
    public bool canUpgrade;

    private PlayerRotation playerRotation;
    private PlayerAttack playerAttack;
    private SpawnManager spawnManager;
    [Header("Rotate Settings")]
    [SerializeField]
    private Image rotateImage;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private int startRotatePrice;
    [SerializeField]
    private TextMeshProUGUI rotatePriceText;
    [Header("Rate Settings")]
    [SerializeField]
    private Image rateImage;
    [SerializeField]
    private float rateSpeed;
    [SerializeField]
    private int startRatePrice;
    [SerializeField]
    private TextMeshProUGUI ratePriceText;
    [Space]
    [SerializeField]
    private GameObject upgradePage;

    private bool isOpen;
    private bool isRateButton;
    private bool isRotationButton;
    
    void Start()
    {
        isOpen = false;

        playerRotation = FindObjectOfType<PlayerRotation>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        spawnManager = FindObjectOfType<SpawnManager>();

        ratePriceText.text = startRatePrice.ToString();
        rotatePriceText.text = startRotatePrice.ToString();
    }

    void Update()
    {
        OpenUpgradePage();
    }

    private void OpenUpgradePage()
    {
        if (isOpen)
        {
            upgradePage.SetActive(true);
        }
        else
        {
            upgradePage.SetActive(false);
        }
    }

    public void UpgradeRotation()
    {
        isRotationButton = true;
        if (GoldManager.Instance.currentGold >= startRotatePrice)
        {
            playerRotation.ChangeRotateSpeed(rotateSpeed);

            GoldManager.Instance.RemoveGold(startRotatePrice);
            startRotatePrice *= 2;
            rotatePriceText.text = startRotatePrice.ToString();

            DecreaseSummoneRate();
        }
        else
        {
            StartCoroutine(nameof(ChangeImageColor));
        }
    }
    public void UpgradeFireRate()
    {
        isRateButton = true;
        if (GoldManager.Instance.currentGold >= startRatePrice)
        {
            playerAttack.ChangeAttackRate(rateSpeed);

            GoldManager.Instance.RemoveGold(startRatePrice);
            startRatePrice *= 2;
            ratePriceText.text = startRatePrice.ToString();

            DecreaseSummoneRate();
        }
        else
        {
            StartCoroutine(nameof(ChangeImageColor));
        }
    }

    IEnumerator ChangeImageColor()
    {
        ChangeRedColor();
        yield return new WaitForSeconds(0.2f);
        ResetClickedButton();
        ChangeNormalColor();
    }
    private void ChangeRedColor()
    {
        if (isRotationButton == true)
        {
            rotateImage.color = Color.red;
        }
        else if(isRateButton == true)
        {
            rateImage.color = Color.red;
        }
    }
    private void ChangeNormalColor()
    {
        rotateImage.color = Color.white;
        rateImage.color = Color.white;
    }
    private void ResetClickedButton()
    {
        isRotationButton = false;
        isRateButton = false;
    }

    public void SetUpgradePage()
    {
        isOpen = !isOpen;
    }

    private void DecreaseSummoneRate()
    {
        float decreaseRate = 0.3f;
        spawnManager.ChangeSpawnRate(decreaseRate);
    }

}
