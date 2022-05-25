using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePersonToPlace : MonoBehaviour
{
    [SerializeField] private Transform _innerShape;

    public GameObject[] Foods;

    public static GameObject Food;

    public delegate void Deys();
    public static event Deys deys;

    public static Vector3 transform1;

    private bool _isMoving = true;

    private int numberGirl = 0;


    void Start()
    {
        TapToFood.onCoinTake += doStuff;

        if (CreatePerson.isNewPlayerCreate)
        {
            _innerShape.DOMove(CreatePerson.place.transform.position, 5).SetEase(Ease.InOutSine);
        }
        else
        {
            _innerShape.DOMove(CreatePerson.newPersonPosition, 5).SetEase(Ease.InOutSine);
            CreatePerson.isNewPlayerCreate = true;
        }

        StartCoroutine(CreateCoroutine());
    }
    IEnumerator CreateCoroutine()
    {

        float plusY = 0;

        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            Food = Instantiate(Foods[Random.Range(1, 4)], gameObject.transform.position + new Vector3(0, 2 + plusY, 0), Quaternion.identity);
            plusY += 0.5f;
            Food.transform.parent = gameObject.transform;
            transform.GetChild(i).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        numberGirl++;
    }

    private void doStuff()
    {
        if (_isMoving)
        {
            if (gameObject.transform.childCount == 0)
            {
                transform1 = gameObject.transform.position;

                if (GameGontroller.numberAllBuyers > 4)
                {
                    CreatePerson.isNewPlayerCreate = false;
                    DoDeys();
                }
                _innerShape.DOMove(new Vector3(-6.69f, -0.39f, -7.26999998f), 5).SetEase(Ease.InOutSine);
                _isMoving = false;

            }
        }
    }

    public void DoDeys()
    {
        deys?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.name == "destroyBuyer")
        {
            _innerShape.DOKill();
            Destroy(gameObject);
            GameGontroller.buyersOut++;
        }
    }

}
