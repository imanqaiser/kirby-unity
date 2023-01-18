using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorOpener : MonoBehaviour
{
    private Animator DoorAnimator;
 private GameObject levelEndPanel, levelEndText;
 private PlayerConroller player;
   
    void Start()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
        levelEndPanel = GameObject.Find("LevelEndPanel");
        levelEndText = GameObject.Find("LevelEndText");
        levelEndPanel.SetActive(false);
        player=GameObject.Find("Player").GetComponent<PlayerConroller>();    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
        DoorAnimator.SetBool("openDoor",true);
        player.freeze=true;
        Invoke("ShowPanel",2);
        }
    }
    private void ShowPanel(){
    levelEndPanel.SetActive(true);
     player.freeze=false;
    Invoke("LoadLevel",4);
    }
    private void LoadLevel(){
         SceneManager.LoadScene("level2");
    }
}
