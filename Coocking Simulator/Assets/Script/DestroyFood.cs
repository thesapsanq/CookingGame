using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyFood : MonoBehaviour
{

    public static bool countClick;

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "food_01":
                countClick = true;
                Destroy(gameObject);
                other.gameObject.transform.DOKill();
                Destroy(other.gameObject);
                break;
            case "food_02":
                countClick = true;
                Destroy(gameObject);
                other.gameObject.transform.DOKill();
                Destroy(other.gameObject);
                break;
            case "food_03":
                countClick = true;
                Destroy(gameObject);
                other.gameObject.transform.DOKill();
                Destroy(other.gameObject);
                break;
            case "food_04":
                countClick = true;
                Destroy(gameObject);
                other.gameObject.transform.DOKill();
                Destroy(other.gameObject);
                break;
            default:
                break;
        }

    }

}
