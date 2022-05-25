using UnityEngine;
using System.IO;


public class JsonController : MonoBehaviour
{
    public Level level;
    [ContextMenu("Load")]
    public void LoadField()
    {
        level = JsonUtility.FromJson<Level>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));

        GameGontroller.countBuyers = level.countBuyers;

        GameGontroller.numberAllBuyers = level.countBuyers;

        GameGontroller.numberOfOrders = level.countFood;

        CoroutineTimer.time = level.levelTime;
    }

    [System.Serializable]
    public class Level
    {
        public int countBuyers;
        public int countFood;
        public float levelTime;
    }

    private void Awake()
    {
        LoadField();
    }

}
