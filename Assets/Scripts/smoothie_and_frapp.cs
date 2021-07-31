using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recipe : MonoBehaviour
{
    public class drink
    {
        public int milk = 0;
        public bool ice = false; //1
        public bool yogurt = false; //2
        public bool greentea = false; //3
        public bool strawberry = false; //4
        public bool chocolate = false; //5
        public bool whipcream = false; //6
        public int espressoShot = 0; //7


        public void initialize()
        { //음료 초기화
            this.milk = 0;
            this.ice = false;
            this.yogurt = false;
            this.greentea = false;
            this.strawberry = false;
            this.chocolate = false;
            this.whipcream = false;
            this.espressoShot = 0;
        }


        public void addIngredient(int i)
        {
            switch (i)
            {
                case 0:
                    this.milk += 50;
                    break;
                case 1:
                    this.ice = true;
                    break;
                case 2:
                    this.yogurt = true;
                    break;
                case 3:
                    this.greentea = true;
                    break;
                case 4:
                    this.strawberry = true;
                    break;
                case 5:
                    this.chocolate = true;
                    break;
                case 6:
                    this.whipcream = true;
                    break;
                case 7:
                    this.espressoShot += 1;
                    break;
            }
        }


        public override bool Equals(object obj)
        {
            drink test = obj as drink;
            if (obj == null)
            {
                return false;
            }
            return milk == test.milk
            && ice == test.ice
            && yogurt == test.yogurt
            && greentea == test.greentea
            && strawberry == test.strawberry
            && chocolate == test.chocolate
            && whipcream == test.whipcream
            && espressoShot == test.espressoShot;
        }
    }

    public drink newDrink = new drink();


    void Start()
    {
        newDrink.initialize();

        updateIngredient();
    }


    void Update()
    {
        switch (Input.inputString)
        { //재료 추가
            case "0":
                newDrink.addIngredient(0);
                break;
            case "1":
                newDrink.addIngredient(1);
                break;
            case "2":
                newDrink.addIngredient(2);
                break;
            case "3":
                newDrink.addIngredient(3);
                break;
            case "4":
                newDrink.addIngredient(4);
                break;
            case "5":
                newDrink.addIngredient(5);
                break;
            case "6":
                newDrink.addIngredient(6);
                break;
            case "7":
                newDrink.addIngredient(7);
                break;

        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            newDrink.initialize();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            updateIngredient();
            recipeDone();
        }

    }

    void updateIngredient()
    {
        Debug.Log("newDrink: \nmilk: " + newDrink.milk.ToString()
        + "\nice: " + newDrink.ice
        + "\nyogurt: " + newDrink.yogurt
        + "\ngreentea: " + newDrink.greentea
        + "\nstrawberry: " + newDrink.strawberry
        + "\nchocolate: " + newDrink.chocolate
        + "\nwhipcream: " + newDrink.whipcream
        + "\nespresso shot: " + newDrink.espressoShot);
    }

    public void recipeDone()
    {
        if (newDrink.Equals(smoothieYogurt))
        {
            Debug.Log("Yogurt smoothie");
        }
        else if (newDrink.Equals(smoothieGreentea))
        {
            Debug.Log("Greentea smoothie");
        }
        else if (newDrink.Equals(smoothieStrawberry))
        {
            Debug.Log("Strawberry smoothie");
        }
        else if (newDrink.Equals(frappEspresso))
        {
            Debug.Log("Espresso frappuccino");
        }
        else if (newDrink.Equals(frappGreentea))
        {
            Debug.Log("Greentea frappuccino");
        }
        else if (newDrink.Equals(frappStrawberry))
        {
            Debug.Log("Strawberry frappuccino");
        }
        else if (newDrink.Equals(frappChocolate))
        {
            Debug.Log("Chocolate frappuccino");
        }
        else
        {
            Debug.Log("failed to complete a recipe");
        }
    }



    //음료수 레시피
    drink smoothieYogurt = new drink
    {
        milk = 150,
        ice = true,
        //blending
        yogurt = true,
        greentea = false
        //blending 15sec
    };

    drink smoothieGreentea = new drink
    {
        milk = 150,
        ice = true,
        //blending
        yogurt = true,
        greentea = true
        //blending 15sec
    };

    drink smoothieStrawberry = new drink
    {
        milk = 150,
        ice = true,
        //blending
        yogurt = true,
        strawberry = true
        //blending 15sec
    };

    drink frappEspresso = new drink
    {
        espressoShot = 1,
        milk = 100,
        ice = true,
        //blending
        whipcream = true
    };

    drink frappGreentea = new drink
    {
        milk = 150,
        ice = true,
        greentea = true,
        //blending
        whipcream = true
    };

    drink frappStrawberry = new drink
    {
        milk = 150,
        ice = true,
        strawberry = true,
        //blending
        whipcream = true
    };

    drink frappChocolate = new drink
    {
        milk = 150,
        ice = true,
        chocolate = true,
        //blending
        whipcream = true
    };
}
