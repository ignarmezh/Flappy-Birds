using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

    public GameObject TubeTopprefab; // префабы труб
    public GameObject TubeBotprefab;
    public float speed = 3f; //скорость труб
    // public GameObject TubeTop;
    // public GameObject TubeBot;
    public List<GameObject> TopTube = new List<GameObject>(); // листы труб
    public List<GameObject> BotTube = new List<GameObject>();

    public Vector3 tubepos;
    public Vector3 tubeposbot = new Vector3(0,2f,0);

    // Use this for initialization
    void Start () {
        InvokeRepeating("AddNewTubes",0,1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i< TopTube.Count; i++) {
            TopTube[i].transform.Translate(Vector3.right * -speed * Time.deltaTime); // движение верхней трубы
            BotTube[i].transform.Translate(Vector3.right * -speed * Time.deltaTime); // движение нижней трубы
            if (TopTube[i].transform.position.x <= -8f) { // удаление труб
                Destroy(TopTube[i]);
                Destroy(BotTube[i]);
                TopTube.RemoveAt(i);
                BotTube.RemoveAt(i);
            }
        }
        
	}
    void AddNewTubes() {
        RandomPos();
        TopTube.Add(GameObject.Instantiate(TubeTopprefab,tubepos,Quaternion.identity) as GameObject);
        BotTube.Add(GameObject.Instantiate(TubeBotprefab,tubepos - tubeposbot,Quaternion.identity) as GameObject);
    }
    void RandomPos() {
        tubepos = new Vector3(10,Random.Range(15.3f,21f),0);
    }
    
}
