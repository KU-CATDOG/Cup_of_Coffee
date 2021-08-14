using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Recipe : MonoBehaviour
{
    #region--drinks declaration--
    private int vanilla_syrup = 0;              //A
    private int chocolate_syrup = 0;            //B
    private int caramel_syrup = 0;              //C
    private int shot = 0;                       //D
    private int milk = 0;                       //E
    private int milk_bubble = 0;                //F
    private int ice = 0;                        //G
    private int greentea_powder = 0;            //H
    private int strawberry_powder = 0;          //I
    private int chocolate_powder = 0;           //J
    private int whipped_cream = 0;              //K
    private int yogurt = 0;                     //L
    private int tapioca = 0;                    //M
    private int blend = 0;                      //N
    private int water = 0;                      //O
    #endregion

    #region--recipe declaration--
    private List<char> espresso                 = new List<char>(new char[] { 'D' });
    private List<char> caramel_macchiato_ice    = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'G', 'D', 'D' });
    private List<char> caramel_macchiato_hot    = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'C' });
    private List<char> americano_ice            = new List<char>(new char[] { 'O', 'O', 'O', 'D', 'D', 'G' });
    private List<char> americano_hot            = new List<char>(new char[] { 'O', 'O', 'O', 'O', 'O', 'O', 'D', 'D' });
    private List<char> caffe_mocha_ice          = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> caffe_mocha_hot          = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K', 'B' });
    private List<char> espresso_con_panna       = new List<char>(new char[] { 'D', 'K' });
    private List<char> espresso_macchiato       = new List<char>(new char[] { 'D', 'F' });
    private List<char> cappuccino               = new List<char>(new char[] { 'E', 'E', 'E', 'F', 'F', 'F', 'D', 'D' });
    private List<char> vanilla_latte_hot        = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'N', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> vanilla_latte_ice        = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'N', 'E', 'E', 'E', 'G' });
    private List<char> caffe_latte_hot          = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> caffe_latte_ice          = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'G' });
    private List<char> greentea_latte_ice       = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'G' });
    private List<char> greentea_latte_hot       = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'H' });
    private List<char> strawberry_latte         = new List<char>(new char[] { 'I', 'I', 'E', 'E', 'E', 'E', 'G' });
    private List<char> hot_chocolate            = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K' });
    private List<char> ice_chocolate            = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> yogurt_smoothie          = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'N' });
    private List<char> greentea_smoothie        = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_smoothie      = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'I', 'I', 'N' });
    private List<char> yogurt_pearl             = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'N' });
    private List<char> greentea_pearl           = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_pearl         = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'I', 'I', 'N' });
    private List<char> espresso_frapp           = new List<char>(new char[] { 'D', 'E', 'E', 'G', 'N' });
    private List<char> greentea_frapp           = new List<char>(new char[] { 'E', 'E', 'E', 'H', 'H', 'N', 'K' });
    private List<char> strawberry_frapp         = new List<char>(new char[] { 'E', 'E', 'E', 'I', 'I', 'N', 'K' });
    private List<char> chocolate_frapp          = new List<char>(new char[] { 'E', 'E', 'E', 'J', 'J', 'N', 'K' });
    #endregion

    private List<char> queue = new List<char>();

    public Drink drinkImage;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Check currently placed volume
        {
            Check();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IngredientReset();
        }
        #region--ingredient test--
        if (Input.GetKeyDown(KeyCode.Return))//Determine recipe
        {
            if (queue.SequenceEqual(espresso))
            {
                Debug.Log("You made a cup of espresso!");
                drinkImage.ShowDrink("espresso");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice))
            {
                Debug.Log("You made a cup of iced caramel macchiato!");
                drinkImage.ShowDrink("caramel_macchiato_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot))
            {
                Debug.Log("You made a cup of hot caramel macchiato!");
                drinkImage.ShowDrink("caramel_macchiato_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_hot))
            {
                Debug.Log("You made a cup of hot americano!");
                drinkImage.ShowDrink("americano_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_ice))
            {
                Debug.Log("You made a cup of iced americano!");
                drinkImage.ShowDrink("americano_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_ice))
            {
                Debug.Log("You made a cup of iced caffe mocha!");
                drinkImage.ShowDrink("caffe_mocha_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_hot))
            {
                Debug.Log("You made a cup of hot caffe mocha!");
                drinkImage.ShowDrink("caffe_mocha_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_con_panna))
            {
                Debug.Log("You made a cup of espresso con panna!");
                drinkImage.ShowDrink("espresso_con_panna");
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_macchiato))
            {
                Debug.Log("You made a cup of espresso macchiato!");
                drinkImage.ShowDrink("espresso_macchiato");
                IngredientReset();
            }
            else if (queue.SequenceEqual(cappuccino))
            {
                Debug.Log("You made a cup of cappuccino!");
                drinkImage.ShowDrink("cappuccino");
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_hot))
            {
                Debug.Log("You made a cup of hot vanilla latte!");
                drinkImage.ShowDrink("vanilla_latte_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_ice))
            {
                Debug.Log("You made a cup of iced vanilla latte!");
                drinkImage.ShowDrink("vanilla_latte_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_hot))
            {
                Debug.Log("You made a cup of hot caffe latte!");
                drinkImage.ShowDrink("caffe_latte_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_ice))
            {
                Debug.Log("You made a cup of iced caffe latte!");
                drinkImage.ShowDrink("caffe_latte_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_latte_hot))
            {
                Debug.Log("You made a cup of hot greentea latte!");
                drinkImage.ShowDrink("greentea_latte_hot");
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_latte_ice))
            {
                Debug.Log("You made a cup of iced greentea latte!");
                drinkImage.ShowDrink("greentea_latte_ice");
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_latte))
            {
                Debug.Log("You made a cup of iced strawberry latte!");
                drinkImage.ShowDrink("strawberry_latte");
                IngredientReset();
            }
            else if (queue.SequenceEqual(hot_chocolate))
            {
                Debug.Log("You made a cup of hot chocolate!");
                drinkImage.ShowDrink("hot_chocolate");
                IngredientReset();
            }
            else if (queue.SequenceEqual(ice_chocolate))
            {
                Debug.Log("You made a cup of iced chocolate!");
                drinkImage.ShowDrink("ice_chocolate");
                IngredientReset();
            }
            else if (queue.SequenceEqual(yogurt_smoothie))
            {
                Debug.Log("You made a cup of yogurt smoothie!");
                drinkImage.ShowDrink("yogurt_smoothie");
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_smoothie))
            {
                Debug.Log("You made a cup of greentea smoothie!");
                drinkImage.ShowDrink("greentea_smoothie");
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_smoothie))
            {
                Debug.Log("You made a cup of strawberry smoothie!");
                drinkImage.ShowDrink("strawberry_smoothie");
                IngredientReset();
            }
            else if (queue.SequenceEqual(yogurt_pearl))
            {
                Debug.Log("You made a cup of bubble tea (yogurt)!");
                drinkImage.ShowDrink("yogurt_pearl");
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_pearl))
            {
                Debug.Log("You made a cup of bubble tea (greentea)!");
                drinkImage.ShowDrink("greentea_pearl");
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_pearl))
            {
                Debug.Log("You made a cup of bubble tea (strawberry)!");
                drinkImage.ShowDrink("strawberry_pearl");
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_frapp))
            {
                Debug.Log("You made a cup of espresso blended!");
                drinkImage.ShowDrink("espresso_frapp");
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_frapp))
            {
                Debug.Log("You made a cup of greentea blended!");
                drinkImage.ShowDrink("greentea_frapp");
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_frapp))
            {
                Debug.Log("You made a cup of strawberry blended!");
                drinkImage.ShowDrink("strawberry_frapp");
                IngredientReset();
            }
            else if (queue.SequenceEqual(chocolate_frapp))
            {
                Debug.Log("You made a cup of chocolate blended!");
                drinkImage.ShowDrink("chocolate_frapp");
                IngredientReset();
            }
            else
            {
                Debug.Log("You made a mistake...");
                //drinkImage.ShowDrink("mistake");
                IngredientReset();
            }

        }
        #endregion
    }

    private void IngredientReset()
    {
        vanilla_syrup = 0;
        chocolate_syrup = 0;
        caramel_syrup = 0;
        shot = 0;
        milk = 0;
        milk_bubble = 0;
        ice = 0;
        greentea_powder = 0;
        strawberry_powder = 0;
        chocolate_powder = 0;
        whipped_cream = 0;
        yogurt = 0;
        tapioca = 0;
        blend = 0;
        water = 0;
        queue.Clear();
        Debug.Log("Ingredient Resetted");
    }

    private void Check()
    {
        Debug.Log("========================================");
        Debug.Log("Vanilla Syrup = " + vanilla_syrup);
        Debug.Log("Chocolate Syrup = " + chocolate_syrup);
        Debug.Log("Caramel Syrup = " + caramel_syrup);
        Debug.Log("Coffee Shot = " + shot);
        Debug.Log("Milk = " + milk);
        Debug.Log("Milk Bubble = " + milk_bubble);
        Debug.Log("Ice = " + ice);
        Debug.Log("Greentea Powder = " + greentea_powder);
        Debug.Log("Strawberry Powder = " + strawberry_powder);
        Debug.Log("Chocolate Powder = " + chocolate_powder);
        Debug.Log("Whipped Cream = " + whipped_cream);
        Debug.Log("Yogurt = " + yogurt);
        Debug.Log("Tapioca = " + tapioca);
        Debug.Log("Blend = " + blend);
        Debug.Log("Water = " + water);
        Debug.Log("========================================");
    }

    #region--Add ingredients functions--
    public void Add_vanilla_syrup()
    {
        vanilla_syrup++;
        queue.Add('A');
        Debug.Log("Vanilla Syrup");
    }
    public void Add_chocolate_syrup()
    {
        chocolate_syrup++;
        queue.Add('B');
        Debug.Log("Chocolate Syrup");
    }
    public void Add_caramel_syrup()
    {
        caramel_syrup++;
        queue.Add('C');
        Debug.Log("Caramel Syrup");
    }
    public void Add_shot()
    {
        shot++;
        queue.Add('D');
        Debug.Log("Shot");
    }
    public void Add_milk()
    {
        milk++;
        queue.Add('E');
        Debug.Log("Milk");
    }
    public void Add_milk_bubble()
    {
        milk_bubble++;
        queue.Add('F');
        Debug.Log("Milk Bubble");
    }
    public void Add_ice()
    {
        ice++;
        queue.Add('G');
        Debug.Log("Ice");
    }
    public void Add_greentea_powder()
    {
        greentea_powder++;
        queue.Add('H');
        Debug.Log("Greentea powder");
    }
    public void Add_strawberry_powder()
    {
        strawberry_powder++;
        queue.Add('I');
        Debug.Log("Strawberry powder");
    }
    public void Add_chocolate_powder()
    {
        chocolate_powder++;
        queue.Add('J');
        Debug.Log("Chocolate powder");
    }
    public void Add_whipped_cream()
    {
        whipped_cream++;
        queue.Add('K');
        Debug.Log("Whipped cream");
    }
    public void Add_yogurt()
    {
        yogurt++;
        queue.Add('L');
        Debug.Log("Yogurt");
    }
    public void Add_tapioca()
    {
        tapioca++;
        queue.Add('M');
        Debug.Log("Tapioca");
    }
    public void Add_blend()
    {
        blend++;
        queue.Add('N');
        Debug.Log("Blend");
    }
    public void Add_water()
    {
        water++;
        queue.Add('O');
        Debug.Log("Water");
    }
    #endregion
}