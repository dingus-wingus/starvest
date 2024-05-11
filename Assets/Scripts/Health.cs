using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author:Kozeng Yang
 * Last Updated: 5/10/24
 * The slider for the player health bar
 */
public class Health : MonoBehaviour
{
    
    
    public Slider slider;
  /// <summary>
  /// The health bar and the slider of health when the player takes damage.
  /// </summary>
  /// <param name="health"></param>
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
