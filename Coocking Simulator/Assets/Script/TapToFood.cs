using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TapToFood : MonoBehaviour
{
    public GameObject[] foodStock;

    public delegate void OnCoinTake();
    public static event OnCoinTake onCoinTake;

    public void OnMouseDown()
    {

        switch (GetComponent<Collider>().gameObject.name)
        {
            case "food1":
                var clone = Instantiate(foodStock[0], transform.position, Quaternion.identity);
                clone.transform.DOMove(GameObject.FindGameObjectWithTag("food1").transform.position, 2);
                break;
            case "food2":
                clone = Instantiate(foodStock[1], transform.position, Quaternion.identity);
                clone.transform.DOMove(GameObject.FindGameObjectWithTag("food2").transform.position, 2);
                break;
            case "food3":
                clone = Instantiate(foodStock[2], transform.position, Quaternion.identity);
                clone.transform.DOMove(GameObject.FindGameObjectWithTag("food3").transform.position, 2);
                break;
            case "food4":
                clone = Instantiate(foodStock[3], transform.position, Quaternion.identity);
                clone.transform.DOMove(GameObject.FindGameObjectWithTag("food4").transform.position, 2);
                break;
            default:
                break;
        }

    }
    public void Update()
    {
        if (DestroyFood.countClick)
        {
            gameObject.SetActive(true);
            TakeCoin();
            DestroyFood.countClick = false;
        }
    }
    public void TakeCoin()
    {
        onCoinTake?.Invoke();
    }

}
