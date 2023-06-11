using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*  
 *  Controller for stats ui
 *  Can set attack, defense, and speed text
 */
public class StatController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AttackText;
    [SerializeField] TextMeshProUGUI DefenseText;
    [SerializeField] TextMeshProUGUI SpeedText;

    // Start is called before the first frame update
    void Start()
    {
        AttackText.text = "1";
        DefenseText.text = "1";
        SpeedText.text = "8";
    }

    public void setAttackText(int attack)
    {
        AttackText.text = attack.ToString();
    }
    public void setDefenseText(int attack)
    {
        AttackText.text = attack.ToString();
    }
    public void setSpeedText(int attack)
    {
        AttackText.text = attack.ToString();
    }

}
