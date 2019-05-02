﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private int count;
  public Text countText;
  public Text winText;
  private Rigidbody rb;

  void Start (){
    rb = GetComponent<Rigidbody>();
    count = 0;
    SetCountText();
    winText.text = "";
    Screen.SetResolution(800, 600, false);
  }

  void FixedUpdate() {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");

      Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

      rb.AddForce(movement*speed);
    }

  void OnTriggerEnter(Collider other){
   if(other.gameObject.CompareTag("Pick Up")){
     other.gameObject.SetActive(false);
     count ++;
     SetCountText();
   }
  }

  void SetCountText(){
         countText.text = "Count " + count.ToString();
         if (count>=8){
           winText.text = "You win!";
         }
  }
}
