using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGontroller : MonoBehaviour
{
    public static int countBuyers;
    public static int numberAllBuyers;

    public static int buyersOut = 0;

    public static int numberOfOrders;
    public static List<int> massOrder;

    private GUIStyle guiStyle = new GUIStyle();

    public static bool isAllPersonHasOrder;

    private void OnGUI()
    {
        guiStyle.fontSize = 50;
        GUILayout.Label($"Количество поситителей: {countBuyers}/{numberAllBuyers}", guiStyle);


        if (buyersOut == numberAllBuyers)
        {
            Debug.Log(buyersOut);
            Debug.Log(numberAllBuyers);
            isAllPersonHasOrder = true;
            CoroutineTimer.winOrLose = "Вы победили";
            buyersOut = 0;

        }

    }

    private void Start()
    {
        massOrder = new List<int>();
    }
}
