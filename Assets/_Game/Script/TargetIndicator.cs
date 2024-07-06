using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetIndicator : MonoBehaviour
{
	Transform target;
	Vector3 viewPoint;
    Vector3 screenHalf = new Vector2(Screen.width, Screen.height) / 2;
	[SerializeField] Image iconlevel;
	[SerializeField] RectTransform rect;
	[SerializeField] TextMeshProUGUI nameText;
	[SerializeField] TextMeshProUGUI levelText;

    Camera cameraMain;
	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(target.position);
        viewPoint = Camera.main.WorldToScreenPoint(target.position) - screenHalf;
        rect.anchoredPosition = viewPoint / (Screen.width / 1080);
    }
    public void OnInit(Transform target)
    {
        this.target = target;
        Color color = new Color(Random.value, Random.value, Random.value, 1);
        iconlevel.color = color;
        nameText.color = color;
    }
    public void SetScore(int score)
    {
        levelText.text = score.ToString();
    }
    public void SetInformation(string name)
    {
        nameText.text = name;
    }
}
