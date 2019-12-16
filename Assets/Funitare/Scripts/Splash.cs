using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public Transform LoadingBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }
        else
        {
           // Debug.Log("Xong");
            SceneManager.LoadScene("Main");
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
