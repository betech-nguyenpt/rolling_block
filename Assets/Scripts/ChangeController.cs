using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeController : MonoBehaviour
{

    public GameObject[] listInstruction;
    public int numPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage() {
        if (numPage == listInstruction.Length)
        {
            SceneManager.LoadScene("level0");
        }
        foreach (var item in listInstruction)
        {
            var page = "Text" + numPage;
            if (page == item.name) {
                if (item.activeSelf == true) {
                    item.SetActive(false);
                    numPage++;
                    continue;
                } else {
                    item.SetActive(true);
                    break;
                }
            }
        }
    }
    public void PrevPage() {
        var listReverse = listInstruction.Reverse();
        foreach (var item in listReverse)
        {
            var page = "Text" + numPage;
            if (page == item.name) {
                if (item.activeSelf == true) {
                    item.SetActive(false);
                    numPage--;
                    continue;
                } else {
                    item.SetActive(true);
                    break;
                }
            }
        }
    }
}
