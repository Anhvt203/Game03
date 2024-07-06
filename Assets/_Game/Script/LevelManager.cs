using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private List<Bot> bots = new List<Bot>();
    public Player player;
	public int TotalCharacter => totalBot + 1;
    private int totalCharacterAlive;

	[SerializeField] int totalBot;
	[SerializeField] private GameObject bot;
	[SerializeField] GameObject indicatorPrefabs;
	[SerializeField] GameObject canvasIndicator;
	[SerializeField] TextMeshProUGUI textAlive;
    private static string[] randName = {"A1", "B2", "C3", "D4", "E5", "F6", "J7","G8","VTA9","TTHT10", "BTTT11","VKO12"};
    // Start is called before the first frame update
    void Start()
    {
        totalCharacterAlive = TotalCharacter;
		OnInit();
    }
    public void OnInit()
    {
        textAlive.text = "Alive: " + totalCharacterAlive.ToString();
        for (int i = 0; i < totalBot; i++)
        {
            NewBot();
        }
    }
    public void InitCharacterAlive()
    {
        totalCharacterAlive--;
		textAlive.text = "Alive: " + totalCharacterAlive.ToString();
	}
	public TargetIndicator CreateIndicatorPanel(Transform target)
    {
        TargetIndicator targetIndicator = Instantiate(indicatorPrefabs, target.position,Quaternion.identity).GetComponent<TargetIndicator>();
        targetIndicator.transform.SetParent(canvasIndicator.transform);
        targetIndicator.OnInit(target.transform);
        targetIndicator.SetInformation(randName[Random.Range(0, 12)]);
        return targetIndicator;
    }
    private void NewBot()
    {
        Bot botSpawn = Instantiate(bot, RandomPoint(),Quaternion.identity).GetComponent<Bot>();
        bots.Add(botSpawn);
    }
    private Vector3 RandomPoint()
    {
        Vector3 randPoint = new Vector3(Random.Range(-250f,250f),0f,Random.Range(-250f,250f));
        return randPoint;
    }
}
