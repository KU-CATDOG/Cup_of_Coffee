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
    private List<char> espresso = new List<char>(new char[] { 'D' });
    private List<char> caramel_macchiato_ice = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'G', 'D', 'D' });
    private List<char> caramel_macchiato_hot = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'C' });
    private List<char> americano_ice = new List<char>(new char[] { 'O', 'O', 'O', 'D', 'D', 'G' });
    private List<char> americano_hot = new List<char>(new char[] { 'O', 'O', 'O', 'O', 'O', 'O', 'D', 'D' });
    private List<char> caffe_mocha_ice = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> caffe_mocha_hot = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K', 'B' });
    private List<char> espresso_con_panna = new List<char>(new char[] { 'D', 'K' });
    private List<char> espresso_macchiato = new List<char>(new char[] { 'D', 'F' });
    private List<char> cappuccino = new List<char>(new char[] { 'E', 'E', 'E', 'F', 'F', 'F', 'D', 'D' });
    private List<char> vanilla_latte_hot = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'N', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> vanilla_latte_ice = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'N', 'E', 'E', 'E', 'G' });
    private List<char> caffe_latte_hot = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> caffe_latte_ice = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'G' });
    private List<char> greentea_latte_ice = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'G' });
    private List<char> greentea_latte_hot = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'H' });
    private List<char> strawberry_latte = new List<char>(new char[] { 'I', 'I', 'E', 'E', 'E', 'E', 'G' });
    private List<char> hot_chocolate = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K' });
    private List<char> ice_chocolate = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> yogurt_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'N' });
    private List<char> greentea_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'N', 'L', 'I', 'I', 'N' });
    private List<char> yogurt_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'N' });
    private List<char> greentea_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'N', 'L', 'I', 'I', 'N' });
    private List<char> espresso_frapp = new List<char>(new char[] { 'D', 'E', 'E', 'G', 'N' });
    private List<char> greentea_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'H', 'H', 'N', 'K' });
    private List<char> strawberry_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'I', 'I', 'N', 'K' });
    private List<char> chocolate_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'J', 'J', 'N', 'K' });
    #endregion

    private List<char> queue = new List<char>();

    public Drink drinkImage;
    public int menu; // 음료 순서대로 1~29, 잘못 만들었으면 0

    public GameObject Customer;
    private void Start()
    {
        Customer.GetComponent<CsvLoadCustomer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //Check currently placed volume
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
                Cupofespresso();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice))
            {

                Cupofcaramel_macchiato_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot))
            {
                Cupofcaramel_macchiato_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_hot))
            {
                Cupofamericano_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_ice))
            {
                Cupofamericano_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_ice))
            {
                Cupofcaffe_mocha_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_hot))
            {
                Cupofcaffe_mocha_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_con_panna))
            {
                Cupofespresso_con_panna();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_macchiato))
            {
                Cupofespresso_macchiato();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(cappuccino))
            {
                Cupofcappuccino();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_hot))
            {
                Cupofvanilla_latte_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_ice))
            {
                Cupofvanilla_latte_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_hot))
            {
                Cupofcaffe_latte_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_ice))
            {
                Cupofcaffe_latte_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_latte_hot))
            {
                Cupofgreentea_latte_hot();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_latte_ice))
            {
                Cupofgreentea_latte_ice();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_latte))
            {
                Cupofstrawberry_latte();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(hot_chocolate))
            {
                Cupofhot_chocolate();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(ice_chocolate))
            {
                Cupofice_chocolate();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(yogurt_smoothie))
            {
                Cupofyogurt_smoothie();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_smoothie))
            {
                Cupofgreentea_smoothie();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_smoothie))
            {
                Cupofstrawberry_smoothie();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(yogurt_pearl))
            {
                Cupofyogurt_pearl();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_pearl))
            {
                Cupofgreentea_pearl();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_pearl))
            {
                Cupofstrawberry_pearl();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_frapp))
            {
                Cupofespresso_frapp();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(greentea_frapp))
            {
                Cupofgreentea_frapp();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(strawberry_frapp))
            {
                Cupofstrawberry_frapp();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(chocolate_frapp))
            {
                Cupofchocolate_frapp();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else
            {
                Debug.Log("You made a mistake...");
                //drinkImage.ShowDrink("mistake");
                Cupofmistake();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
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


    #region --Coffee functions--
    public void Cupofespresso()
    {
        Debug.Log("You made a cup of espresso!");
        drinkImage.ShowDrink("espresso");
        menu = 1;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_ice()
    {
        Debug.Log("You made a cup of iced caramel macchiato!");
        drinkImage.ShowDrink("caramel_macchiato_ice");
        menu = 2;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_hot()
    {
        Debug.Log("You made a cup of hot caramel macchiato!");
        drinkImage.ShowDrink("caramel_macchiato_hot");
        menu = 3;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofamericano_hot()
    {
        Debug.Log("You made a cup of hot americano!");
        drinkImage.ShowDrink("americano_hot");
        menu = 4;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;

    }
    public void Cupofamericano_ice()
    {
        Debug.Log("You made a cup of iced americano!");
        drinkImage.ShowDrink("americano_ice");
        menu = 5;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_ice()
    {
        Debug.Log("You made a cup of iced caffe mocha!");
        drinkImage.ShowDrink("caffe_mocha_ice");
        menu = 6;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_hot()
    {
        Debug.Log("You made a cup of hot caffe mocha!");
        drinkImage.ShowDrink("caffe_mocha_hot");
        menu = 7;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_con_panna()
    {
        Debug.Log("You made a cup of espresso con panna!");
        drinkImage.ShowDrink("espresso_con_panna");
        menu = 8;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_macchiato()
    {
        Debug.Log("You made a cup of espresso macchiato!");
        drinkImage.ShowDrink("espresso_macchiato");
        menu = 9;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcappuccino()
    {
        Debug.Log("You made a cup of cappuccino!");
        drinkImage.ShowDrink("cappuccino");
        menu = 10;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_hot()
    {
        Debug.Log("You made a cup of hot vanilla latte!");
        drinkImage.ShowDrink("vanilla_latte_hot");
        menu = 11;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_ice()
    {
        Debug.Log("You made a cup of iced vanilla latte!");
        drinkImage.ShowDrink("vanilla_latte_ice");
        menu = 12;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_hot()
    {
        Debug.Log("You made a cup of hot caffe latte!");
        drinkImage.ShowDrink("caffe_latte_hot");
        menu = 13;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_ice()
    {
        Debug.Log("You made a cup of iced caffe latte!");
        drinkImage.ShowDrink("caffe_latte_ice");
        menu = 14;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_latte_hot()
    {
        Debug.Log("You made a cup of hot greentea latte!");
        drinkImage.ShowDrink("greentea_latte_hot");
        menu = 15;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_latte_ice()
    {
        Debug.Log("You made a cup of iced greentea latte!");
        drinkImage.ShowDrink("greentea_latte_ice");
        menu = 16;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_latte()
    {
        Debug.Log("You made a cup of iced strawberry latte!");
        drinkImage.ShowDrink("strawberry_latte");
        menu = 17;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofhot_chocolate()
    {
        Debug.Log("You made a cup of hot chocolate!");
        drinkImage.ShowDrink("hot_chocolate");
        menu = 18;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofice_chocolate()
    {
        Debug.Log("You made a cup of iced chocolate!");
        drinkImage.ShowDrink("ice_chocolate");
        menu = 19;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofyogurt_smoothie()
    {
        Debug.Log("You made a cup of yogurt smoothie!");
        drinkImage.ShowDrink("yogurt_smoothie");
        menu = 20;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_smoothie()
    {
        Debug.Log("You made a cup of greentea smoothie!");
        drinkImage.ShowDrink("greentea_smoothie");
        menu = 21;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_smoothie()
    {
        Debug.Log("You made a cup of strawberry smoothie!");
        drinkImage.ShowDrink("strawberry_smoothie");
        menu = 22;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofyogurt_pearl()
    {
        Debug.Log("You made a cup of bubble tea (yogurt)!");
        drinkImage.ShowDrink("yogurt_pearl");
        menu = 23;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_pearl()
    {
        Debug.Log("You made a cup of bubble tea (greentea)!");
        drinkImage.ShowDrink("greentea_pearl");
        menu = 24;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_pearl()
    {
        Debug.Log("You made a cup of bubble tea (strawberry)!");
        drinkImage.ShowDrink("strawberry_pearl");
        menu = 25;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_frapp()
    {
        Debug.Log("You made a cup of espresso blended!");
        drinkImage.ShowDrink("espresso_frapp");
        menu = 26;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_frapp()
    {
        Debug.Log("You made a cup of greentea blended!");
        drinkImage.ShowDrink("greentea_frapp");
        menu = 27;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_frapp()
    {
        Debug.Log("You made a cup of strawberry blended!");
        drinkImage.ShowDrink("strawberry_frapp");
        menu = 28;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofchocolate_frapp()
    {
        Debug.Log("You made a cup of chocolate blended!");
        drinkImage.ShowDrink("chocolate_frapp");
        menu = 29;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofmistake()
    {
        Debug.Log("You made a mistake...");
        //drinkImage.ShowDrink("mistake");
        menu = 0;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    #endregion

    public void Reset_Ingredient()
    {
        IngredientReset();
    }

    public List<string> GetAddedIngredientLog()
    {
        List<string> logIngredient = new List<string>();
        List<int> logCount = new List<int>();
        char temp = ' ';
        for (int i = 0; i < queue.Count; i++)
        {
            if (queue[i] != temp)
            {
                string ingredient = "";
                switch (queue[i])
                {
                    case 'A':
                        ingredient = "바닐라 시럽";
                        break;
                    case 'B':
                        ingredient = "초코 시럽";
                        break;
                    case 'C':
                        ingredient = "카라멜 시럽";
                        break;
                    case 'D':
                        ingredient = "샷";
                        break;
                    case 'E':
                        ingredient = "우유";
                        break;
                    case 'F':
                        ingredient = "우유 거품";
                        break;
                    case 'G':
                        ingredient = "얼음";
                        break;
                    case 'H':
                        ingredient = "녹차 파우더";
                        break;
                    case 'I':
                        ingredient = "딸기 파우더";
                        break;
                    case 'J':
                        ingredient = "초코 파우더";
                        break;
                    case 'K':
                        ingredient = "휘핑크림";
                        break;
                    case 'L':
                        ingredient = "요거트";
                        break;
                    case 'M':
                        ingredient = "타피오카";
                        break;
                    case 'N':
                        ingredient = "섞어주기";
                        break;
                    case 'O':
                        ingredient = "물";
                        break;
                }

                logIngredient.Add(ingredient);
                logCount.Add(1);
                temp = queue[i];
            }
            else
            {
                logCount[logCount.Count - 1]++;
            }
        }

        List<string> log = new List<string>();
        for (int i = 0; i < logIngredient.Count; i++)
        {
            string logString = logIngredient[i];

            string unit = "";
            switch (logString)
            {
                case "바닐라 시럽":
                case "초코 시럽":
                case "카라멜 시럽":
                case "녹차 파우더":
                case "딸기 파우더":
                case "초코 파우더":
                    unit = "스푼";
                    break;
                case "샷":
                    unit = "개";
                    break;
                case "우유":
                case "물":
                    unit = "mL";
                    break;
            }

            if (unit == "")
            {
                logString += "";
            }
            else if (unit == "mL")
            {
                logString += " × " + (logCount[i] * 50) + unit;
            }
            else
            {
                logString += " × " + logCount[i] + unit;
            }
            log.Add(logString);
        }

        return log;
    }
}