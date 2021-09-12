﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiologSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;
    
    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public bool textFinished;
    public bool cancelTyping;
    [Header("头像")]
    public Sprite face01,face02;

    List<string> textList = new List<string>();
    void Start()
    {
        GetTxtFromFile(textFile);
        index = 0;
       
    }

    // Update is called once per frame
  
        
    
    void Update()
    { 
        
        if(Input.GetMouseButtonDown(0) && index == textList.Count){
            gameObject.SetActive(false);//结束Diolog画面
        }
        /*if(Input.GetKeyDown(KeyCode.R) && textFinished){//刘帅帅专属反义代码……
            textLabel.text = textList[index];
            index++;
            StartCoroutine(SetTextUI());}/*/
        
        if (Input.GetMouseButtonDown(0)){
            if(textFinished && !cancelTyping){
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping){
                cancelTyping = true;
            }
        }
    }
    void GetTxtFromFile(TextAsset file){
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
        
    }

    IEnumerator SetTextUI(){
        textFinished = false;
        textLabel.text = "";
        
        /*
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(0.05f);//字弹出速度
            
        }
        textFinished = false;
        index++;*/
        switch (textList[index])
        {
            case "A\r":
                 faceImage.sprite = face01;
                 index++;
                 break;
        }

         int letter = 0;
         while (!cancelTyping && letter < textList[index].Length - 1)
         {
             textLabel.text += textList[index][letter];
             letter++;
             yield return new WaitForSeconds(0.1f);
         }
         textLabel.text = textList[index];
         cancelTyping = false;
         textFinished = true;
         index++;
    }
} 
