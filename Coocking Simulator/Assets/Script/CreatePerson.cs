using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;



public class CreatePerson : MonoBehaviour
{
    public GameObject[] Buyers;

    public static GameObject Buyer;

    public GameObject[] places;

    public static GameObject place;

    public static int placeNumber;

    public static List<int> mass;

    private float posX = 4.82f;

    public static Vector3 newPersonPosition;

    public static bool isNewPlayerCreate = true;

    private int countFirstBuyrs = 4;

    public void Start()
    {
        MovePersonToPlace.deys += doStuff;

        mass = new List<int>() { 0, 1, 2, 3 };

        StartCoroutine(CreateCoroutine());
        if (GameGontroller.numberAllBuyers <= 4)
        {
            countFirstBuyrs = GameGontroller.numberAllBuyers;
        }
    }

    IEnumerator CreateCoroutine()
    {
        if (GameGontroller.countBuyers > 0)
        {
            for (int i = 0; i < countFirstBuyrs; i++)
            {
                placeNumber = TookRandomMassNumber.TookRandom();
                mass.Remove(placeNumber);
                place = places[placeNumber];

                Vector3 position = new Vector3(posX, -0.279999971f, -7.48999977f);

                Buyer = Instantiate(Buyers[Random.Range(0, 4)], position, Quaternion.Euler(0, 180, 0));
                posX = -4.82f;

                GameGontroller.countBuyers--;

                yield return new WaitForSeconds(5f);
            }
        }
    }

    IEnumerator CreateNextPerson()
    {

        if (GameGontroller.countBuyers > 0 && GameGontroller.numberAllBuyers > 4)
        {
            yield return new WaitForSeconds(0.5f);

            newPersonPosition = MovePersonToPlace.transform1;
            Vector3 position = new Vector3(posX, -0.279999971f, -7.48999977f);

            Buyer = Instantiate(Buyers[Random.Range(0, 3)], position, Quaternion.Euler(0, 180, 0));

            GameGontroller.countBuyers--;
        }
    }

    private void doStuff()
    {
        StartCoroutine(CreateNextPerson());
    }
}
