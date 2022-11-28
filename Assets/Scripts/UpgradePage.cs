using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradePage : MonoBehaviour
{
    private PlayerRotation playerRotation;
    private PlayerAttack playerAttack;

    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private int rotateSpeedPrice;
    [SerializeField]
    private float rateSpeed;
    [SerializeField]
    private int rateSpeedPrice;
    [SerializeField]
    private GameObject upgradePage;
    [SerializeField]
    private TextMeshProUGUI enoughText;
    [SerializeField]
    private TextMeshProUGUI ratePriceText;
    [SerializeField]
    private TextMeshProUGUI rotatePriceText;

    private bool isOpen;
    public bool canUpgrade;
    void Start()
    {
        isOpen = false;

        playerRotation = FindObjectOfType<PlayerRotation>();
        playerAttack = FindObjectOfType<PlayerAttack>();

        ratePriceText.text = rateSpeedPrice.ToString();
        rotatePriceText.text = rotateSpeedPrice.ToString();
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
        if (GoldManager.Instance.currentGold >= rotateSpeedPrice)
        {
            playerRotation.ChangeRotateSpeed(rotateSpeed);

            GoldManager.Instance.RemoveGold(rotateSpeedPrice);
            rotateSpeedPrice *= 2;
            rotatePriceText.text = rotateSpeedPrice.ToString();
        }
        else
        {
            StartCoroutine(nameof(ShowEnoughText));
        }
    }
    public void UpgradeFireRate()
    {
        if (GoldManager.Instance.currentGold >= rateSpeedPrice)
        {
            playerAttack.ChangeAttackRate(rateSpeed);

            GoldManager.Instance.RemoveGold(rateSpeedPrice);
            rateSpeedPrice *= 2;
            ratePriceText.text = rateSpeedPrice.ToString();
        }
        else
        {
            StartCoroutine(nameof(ShowEnoughText));
        }
    }

    IEnumerator ShowEnoughText()
    {
        ShowText();
        yield return new WaitForSeconds(0.2f);
        CloseText();
    }
    private void ShowText()
    {
        //enoughText.gameObject.SetActive(true);
        Debug.Log("Text is open");
    }

    private void CloseText()
    {
        Debug.Log("Text is close");
        //enoughText.gameObject.SetActive(false);
    }

    public void SetUpgradePage()
    {
        isOpen = !isOpen;
    }

}
