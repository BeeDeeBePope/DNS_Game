using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text taskText;
    [SerializeField] private GameObject timeIsUp;
    [SerializeField] private float mainTimer;

    private int taskCount = 0;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Start()
    {
        timer = mainTimer;
        taskText.text = taskCount.ToString() + "/1";
    }

    private void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }
        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
            timeIsUp.SetActive(true);
        }
    }

    public void CompleteTask()
    {
        taskCount++;
        taskText.text = taskCount.ToString() + "/1";
        timer += 20.0f;
    }


}
