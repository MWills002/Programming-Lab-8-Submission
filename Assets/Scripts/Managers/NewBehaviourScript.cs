using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string bulletType;
    // Start is called before the first frame update
    void Start()
    {
        switch (bulletType)
        {
            case "Silver":
                Debug.Log("Silver Bullets");
                break;
            case "Gold":
                Debug.Log("Gold Bullets");
                break;
            case "Diamond":
                Debug.Log("Diamond Bullets");
                break;




        }

        if(bulletType == "Silver")
        {
            Debug.Log("Silver Bullets");
        }
        
        
    }


}

public enum bulletType
{
    Silver,
    Gold,
    Diamond
}