using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyManager : MonoBehaviour
{


    #region Singleton

    public static MoneyManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion


    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;
    [SerializeField] GameObject canvas;
    [SerializeField] Ease easeType;
    Vector3 targetposition;
    void Animate(Vector3 collectedCoinPosition, int amount)
    {
        GameObject coinCanvasObject = Instantiate(animatedCoinPrefab, canvas.transform);
        coinCanvasObject.transform.position = collectedCoinPosition;

        coinCanvasObject.transform.DOMove(target.position, 1f).SetEase(easeType).OnComplete(() =>
        {

            Destroy(coinCanvasObject.gameObject);
        });
    }

    public void AddCoins(Vector3 collectedCoinPosition, int amount)
    {
        Animate(collectedCoinPosition, amount);
    }
}
