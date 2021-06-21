using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UIController : MonoBehaviour
{
    
    public List<GameAssets> assetsForGame = new List<GameAssets>();

    public List<string> answers = new List<string>();

    public Transform elemtsParent;

    public GameObject prefab;

    public static UIController Instance;

    public int activItmesCount;

    public GameObject particleSystem;

    public Text question;

    public string answer;


    public GameObject restartButton;
    public GameObject lastSceneBackground;
    public GameObject lastSceneElementsParent;

    private void Awake()
    {
        Instance = this;
    }

    public void MakeRandomElemtsAndQuestions(int count)
    {
        var ranLNum = Random.Range(0, assetsForGame.Count);

        var ranENum = new System.Random();

        var elements = assetsForGame[ranLNum].Items.OrderBy(x => ranENum.Next()).Take(count).ToList();
     
        do
        {
            answer = elements[Random.Range(0, count)].name;
        }
        while (answers.Count>0 && !answer.Contains(answer));

        answers.Add(answer);

        question.GetComponent<Animator>().SetBool("show", true);
        question.text = "Find " + answer;

        for (int i = 0; i < elements.Count; i++)
        {
            MakeElement(i, elements[i], count);
        }
 
    }
    public void MakeElement(int i,Assets element,int count)
    {
        GameObject g;
        if (i >= elemtsParent.childCount)
        {
            g = Instantiate(prefab);

        }
        else
        {
            g = elemtsParent.GetChild(i).gameObject;
            g.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        g.transform.GetChild(0).GetComponent<Image>().sprite = element.item;

        g.transform.SetParent(elemtsParent);

        g.transform.localPosition = Vector3.zero;
        g.transform.localScale = Vector3.one;

        if (element.name == answer)
        {

            g.GetComponent<Button>().onClick.AddListener(() =>rightAnswer(g));
            activItmesCount = count;

        }
        else
            g.GetComponent<Button>().onClick.AddListener(() => wrongAnswer(g));
    }

    System.Action<GameObject> wrongAnswer = (GameObject item) =>
    {
        item.GetComponent<Animator>().SetBool("wrong", true);
    };
    System.Action<GameObject> rightAnswer = (GameObject item) =>
    {
        item.GetComponent<Animator>().SetBool("right", true);
        Instance.particleSystem.SetActive(true);
    };


}
