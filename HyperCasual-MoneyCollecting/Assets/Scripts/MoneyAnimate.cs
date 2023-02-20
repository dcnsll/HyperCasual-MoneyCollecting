using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyAnimate : MonoBehaviour
{

    Camera mainCamera;
    Transform destroyMoneyLocation;
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sell"))
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(this.transform.position);
            MoneyManager.instance.AddCoins(screenPos, 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            destroyMoneyLocation = other.gameObject.transform.GetChild(0);
            transform.DOMove(destroyMoneyLocation.position, 0.5f);
            

        }

    }
}
