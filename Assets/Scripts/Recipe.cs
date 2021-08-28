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
    private int shot_ristretto = 0;             //P
    private int shot_lungo = 0;                 //Q
    private int mix = 0;                        //R
    #endregion

    #region--recipe declaration--
    private List<char> espresso = new List<char>(new char[] { 'D' });
    private List<char> caramel_macchiato_ice = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'R', 'G', 'D', 'D' });
    private List<char> caramel_macchiato_hot = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'R', 'D', 'D', 'F' });
    private List<char> americano_ice = new List<char>(new char[] { 'O', 'O', 'O', 'D', 'D', 'G' });
    private List<char> americano_hot = new List<char>(new char[] { 'O', 'O', 'O', 'O', 'O', 'O', 'D', 'D' });
    private List<char> caffe_mocha_ice = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'R', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> caffe_mocha_hot = new List<char>(new char[] { 'B', 'B', 'D', 'D', 'R', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K', 'B' });
    private List<char> espresso_con_panna = new List<char>(new char[] { 'D', 'K' });
    private List<char> espresso_macchiato = new List<char>(new char[] { 'D', 'F' });
    private List<char> cappuccino = new List<char>(new char[] { 'E', 'E', 'E', 'F', 'F', 'F', 'D', 'D' });
    private List<char> vanilla_latte_hot = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'R', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> vanilla_latte_ice = new List<char>(new char[] { 'A', 'A', 'D', 'D', 'R', 'E', 'E', 'E', 'G' });
    private List<char> caffe_latte_hot = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> caffe_latte_ice = new List<char>(new char[] { 'D', 'D', 'E', 'E', 'E', 'G' });
    private List<char> greentea_latte_ice = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'R', 'G' });
    private List<char> greentea_latte_hot = new List<char>(new char[] { 'H', 'H', 'E', 'E', 'E', 'E', 'E', 'E', 'R', 'F', 'H' });
    private List<char> strawberry_latte = new List<char>(new char[] { 'I', 'I', 'E', 'E', 'E', 'E', 'R', 'G' });
    private List<char> hot_chocolate = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'E', 'E', 'E', 'R', 'F', 'K' });
    private List<char> ice_chocolate = new List<char>(new char[] { 'J', 'J', 'E', 'E', 'E', 'R', 'G', 'K', 'B' });
    private List<char> yogurt_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'L', 'N' });
    private List<char> greentea_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_smoothie = new List<char>(new char[] { 'E', 'E', 'E', 'G', 'L', 'I', 'I', 'N' });
    private List<char> yogurt_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'L', 'N' });
    private List<char> greentea_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'L', 'H', 'H', 'N' });
    private List<char> strawberry_pearl = new List<char>(new char[] { 'M', 'E', 'E', 'E', 'G', 'L', 'I', 'I', 'N' });
    private List<char> espresso_frapp = new List<char>(new char[] { 'D', 'E', 'E', 'G', 'N' });
    private List<char> greentea_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'H', 'H', 'N', 'K' });
    private List<char> strawberry_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'I', 'I', 'N', 'K' });
    private List<char> chocolate_frapp = new List<char>(new char[] { 'E', 'E', 'E', 'J', 'J', 'N', 'K' });

    //----------------------------------- new from below

    private List<char> espresso_ristretto = new List<char>(new char[] { 'P' });
    private List<char> espresso_lungo = new List<char>(new char[] { 'Q' });
    private List<char> caramel_macchiato_ice_ristretto = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'R', 'G', 'P', 'P' });
    private List<char> caramel_macchiato_ice_lungo = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'R', 'G', 'Q', 'Q' });
    private List<char> caramel_macchiato_hot_ristretto = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'R', 'P', 'P', 'F' });
    private List<char> caramel_macchiato_hot_lungo = new List<char>(new char[] { 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'R', 'Q', 'Q', 'F' });
    private List<char> americano_ice_ristretto = new List<char>(new char[] { 'O', 'O', 'O', 'P', 'P', 'G' });
    private List<char> americano_ice_lungo = new List<char>(new char[] { 'O', 'O', 'O', 'Q', 'Q', 'G' });
    private List<char> americano_hot_ristretto = new List<char>(new char[] { 'O', 'O', 'O', 'O', 'O', 'O', 'P', 'P' });
    private List<char> americano_hot_lungo = new List<char>(new char[] { 'O', 'O', 'O', 'O', 'O', 'O', 'Q', 'Q' });
    private List<char> caffe_mocha_ice_ristretto = new List<char>(new char[] { 'B', 'B', 'R', 'P', 'P', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> caffe_mocha_ice_lungo = new List<char>(new char[] { 'B', 'B', 'R', 'Q', 'Q', 'E', 'E', 'E', 'G', 'K', 'B' });
    private List<char> caffe_mocha_hot_ristretto = new List<char>(new char[] { 'B', 'B', 'R', 'P', 'P', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K', 'B' });
    private List<char> caffe_mocha_hot_lungo = new List<char>(new char[] { 'B', 'B', 'R', 'Q', 'Q', 'E', 'E', 'E', 'E', 'E', 'E', 'F', 'K', 'B' });
    private List<char> espresso_con_panna_ristretto = new List<char>(new char[] { 'P', 'K' });
    private List<char> espresso_con_panna_lungo = new List<char>(new char[] { 'Q', 'K' });
    private List<char> espresso_macchiato_ristretto = new List<char>(new char[] { 'P', 'F' });
    private List<char> espresso_macchiato_lungo = new List<char>(new char[] { 'Q', 'F' });
    private List<char> cappuccino_ristretto = new List<char>(new char[] { 'E', 'E', 'E', 'F', 'F', 'F', 'P', 'P' });
    private List<char> cappuccino_lungo = new List<char>(new char[] { 'E', 'E', 'E', 'F', 'F', 'F', 'Q', 'Q' });
    private List<char> vanilla_latte_hot_ristretto = new List<char>(new char[] { 'A', 'A', 'P', 'P', 'R', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> vanilla_latte_hot_lungo = new List<char>(new char[] { 'A', 'A', 'Q', 'Q', 'R', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> vanilla_latte_ice_ristretto = new List<char>(new char[] { 'A', 'A', 'P', 'P', 'R', 'E', 'E', 'E', 'G' });
    private List<char> vanilla_latte_ice_lungo = new List<char>(new char[] { 'A', 'A', 'Q', 'Q', 'R', 'E', 'E', 'E', 'G' });
    private List<char> caffe_latte_hot_ristretto = new List<char>(new char[] { 'P', 'P', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> caffe_latte_hot_lungo = new List<char>(new char[] { 'Q', 'Q', 'E', 'E', 'E', 'E', 'E', 'E', 'F' });
    private List<char> caffe_latte_ice_ristretto = new List<char>(new char[] { 'P', 'P', 'E', 'E', 'E', 'G' });
    private List<char> caffe_latte_ice_lungo = new List<char>(new char[] { 'Q', 'Q', 'E', 'E', 'E', 'G' });
    private List<char> espresso_frapp_ristretto = new List<char>(new char[] { 'P', 'E', 'E', 'G', 'N' });
    private List<char> espresso_frapp_lungo = new List<char>(new char[] { 'Q', 'E', 'E', 'G', 'N' });
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IngredientReset();
        }
        #region--ingredient test--
        if (Input.GetKeyDown(KeyCode.Return)) //Determine recipe
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
            else if (queue.SequenceEqual(espresso_ristretto))
            {
                Cupofespresso_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_lungo))
            {
                Cupofespresso_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice_ristretto))
            {
                Cupofcaramel_macchiato_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice_lungo))
            {
                Cupofcaramel_macchiato_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot_ristretto))
            {
                Cupofcaramel_macchiato_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot_lungo))
            {
                Cupofcaramel_macchiato_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_ice_ristretto))
            {
                Cupofamericano_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_ice_lungo))
            {
                Cupofamericano_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_hot_ristretto))
            {
                Cupofamericano_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(americano_hot_lungo))
            {
                Cupofamericano_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice_ristretto))
            {
                Cupofcaramel_macchiato_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_ice_lungo))
            {
                Cupofcaramel_macchiato_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot_ristretto))
            {
                Cupofcaramel_macchiato_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caramel_macchiato_hot_lungo))
            {
                Cupofcaramel_macchiato_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_ice_ristretto))
            {
                Cupofcaffe_mocha_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_ice_lungo))
            {
                Cupofcaffe_mocha_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_hot_ristretto))
            {
                Cupofcaffe_mocha_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_mocha_hot_lungo))
            {
                Cupofcaffe_mocha_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_con_panna_ristretto))
            {
                Cupofespresso_con_panna_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_con_panna_lungo))
            {
                Cupofespresso_con_panna_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_macchiato_ristretto))
            {
                Cupofespresso_macchiato_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_macchiato_lungo))
            {
                Cupofespresso_macchiato_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(cappuccino_ristretto))
            {
                Cupofcappuccino_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(cappuccino_lungo))
            {
                Cupofcappuccino_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_hot_ristretto))
            {
                Cupofvanilla_latte_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_hot_lungo))
            {
                Cupofvanilla_latte_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_ice_ristretto))
            {
                Cupofvanilla_latte_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(vanilla_latte_ice_lungo))
            {
                Cupofvanilla_latte_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_hot_ristretto))
            {
                Cupofcaffe_latte_hot_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_hot_lungo))
            {
                Cupofcaffe_latte_hot_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_ice_ristretto))
            {
                Cupofcaffe_latte_ice_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(caffe_latte_ice_lungo))
            {
                Cupofcaffe_latte_ice_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_frapp_ristretto))
            {
                Cupofespresso_frapp_ristretto();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else if (queue.SequenceEqual(espresso_frapp_lungo))
            {
                Cupofespresso_frapp_lungo();
                Customer.GetComponent<CsvLoadCustomer>().RecipeCheck();
                IngredientReset();
            }
            else
            {
                //Debug.Log("You made a mistake...");
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
        shot_ristretto = 0;
        shot_lungo = 0;
        queue.Clear();
        Debug.Log("Ingredient Resetted");
    }

    //private void Check()
    //{
    //    Debug.Log("========================================");
    //    Debug.Log("Vanilla Syrup = " + vanilla_syrup);
    //    Debug.Log("Chocolate Syrup = " + chocolate_syrup);
    //    Debug.Log("Caramel Syrup = " + caramel_syrup);
    //    Debug.Log("Coffee Shot = " + shot);
    //    Debug.Log("Coffee Shot(ristretto) = " + shot_ristretto);
    //    Debug.Log("Coffee Shot(lungo) = " + shot_lungo);
    //    Debug.Log("Milk = " + milk);
    //    Debug.Log("Milk Bubble = " + milk_bubble);
    //    Debug.Log("Ice = " + ice);
    //    Debug.Log("Greentea Powder = " + greentea_powder);
    //    Debug.Log("Strawberry Powder = " + strawberry_powder);
    //    Debug.Log("Chocolate Powder = " + chocolate_powder);
    //    Debug.Log("Whipped Cream = " + whipped_cream);
    //    Debug.Log("Yogurt = " + yogurt);
    //    Debug.Log("Tapioca = " + tapioca);
    //    Debug.Log("Blend = " + blend);
    //    Debug.Log("Water = " + water);
    //    Debug.Log("========================================");
    //}

    #region--Add ingredients functions--
    public void Add_vanilla_syrup()
    {
        vanilla_syrup++;
        queue.Add('A');
        SoundManager.Instance.PlaySFXSound("syrup_pump");
        Debug.Log("Vanilla Syrup");
    }
    public void Add_chocolate_syrup()
    {
        chocolate_syrup++;
        queue.Add('B');
        SoundManager.Instance.PlaySFXSound("syrup_pump");
        Debug.Log("Chocolate Syrup");
    }
    public void Add_caramel_syrup()
    {
        caramel_syrup++;
        queue.Add('C');
        SoundManager.Instance.PlaySFXSound("syrup_pump");
        Debug.Log("Caramel Syrup");
    }
    public void Add_shot()
    {
        shot++;
        queue.Add('D');
        SoundManager.Instance.PlaySFXSound("shot_extraction");
        Debug.Log("Shot");
    }
    public void Add_shot_ristretto()
    {
        shot_ristretto++;
        queue.Add('P');
        SoundManager.Instance.PlaySFXSound("shot_extraction");
        Debug.Log("Shot_ristretto");
    }
    public void Add_shot_lungo()
    {
        shot_lungo++;
        queue.Add('Q');
        SoundManager.Instance.PlaySFXSound("shot_extraction");
        Debug.Log("Shot_lungo");
    }
    public void Add_milk()
    {
        milk++;
        queue.Add('E');
        SoundManager.Instance.PlaySFXSound("drink_pour");
        Debug.Log("Milk");
    }
    public void Add_milk_bubble()
    {
        milk_bubble++;
        queue.Add('F');
        SoundManager.Instance.PlaySFXSound("milk_bubble");
        Debug.Log("Milk Bubble");
    }
    public void Add_ice()
    {
        ice++;
        queue.Add('G');
        SoundManager.Instance.PlaySFXSound("ice_drop");
        Debug.Log("Ice");
    }
    public void Add_greentea_powder()
    {
        greentea_powder++;
        queue.Add('H');
        SoundManager.Instance.PlaySFXSound("powder");
        Debug.Log("Greentea powder");
    }
    public void Add_strawberry_powder()
    {
        strawberry_powder++;
        queue.Add('I');
        SoundManager.Instance.PlaySFXSound("powder");
        Debug.Log("Strawberry powder");
    }
    public void Add_chocolate_powder()
    {
        chocolate_powder++;
        queue.Add('J');
        SoundManager.Instance.PlaySFXSound("powder");
        Debug.Log("Chocolate powder");
    }
    public void Add_whipped_cream()
    {
        whipped_cream++;
        queue.Add('K');
        SoundManager.Instance.PlaySFXSound("whipped_cream");
        Debug.Log("Whipped cream");
    }
    public void Add_yogurt()
    {
        yogurt++;
        queue.Add('L');
        SoundManager.Instance.PlaySFXSound("yogurt");
        Debug.Log("Yogurt");
    }
    public void Add_tapioca()
    {
        tapioca++;
        queue.Add('M');
        SoundManager.Instance.PlaySFXSound("pearl_drop");
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
        SoundManager.Instance.PlaySFXSound("drink_pour");
        Debug.Log("Water");
    }
    #endregion


    #region --Coffee functions--
    public void Cupofespresso()
    {
        Debug.Log("You made a cup of espresso!");
        drinkImage.ShowDrink("espresso");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 1;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_ice()
    {
        Debug.Log("You made a cup of iced caramel macchiato!");
        drinkImage.ShowDrink("caramel_macchiato_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 2;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_hot()
    {
        Debug.Log("You made a cup of hot caramel macchiato!");
        drinkImage.ShowDrink("caramel_macchiato_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 3;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofamericano_hot()
    {
        Debug.Log("You made a cup of hot americano!");
        drinkImage.ShowDrink("americano_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 4;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;

    }
    public void Cupofamericano_ice()
    {
        Debug.Log("You made a cup of iced americano!");
        drinkImage.ShowDrink("americano_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 5;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_ice()
    {
        Debug.Log("You made a cup of iced caffe mocha!");
        drinkImage.ShowDrink("caffe_mocha_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 6;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_hot()
    {
        Debug.Log("You made a cup of hot caffe mocha!");
        drinkImage.ShowDrink("caffe_mocha_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 7;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_con_panna()
    {
        Debug.Log("You made a cup of espresso con panna!");
        drinkImage.ShowDrink("espresso_con_panna");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 8;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_macchiato()
    {
        Debug.Log("You made a cup of espresso macchiato!");
        drinkImage.ShowDrink("espresso_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 9;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcappuccino()
    {
        Debug.Log("You made a cup of cappuccino!");
        drinkImage.ShowDrink("cappuccino");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 10;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_hot()
    {
        Debug.Log("You made a cup of hot vanilla latte!");
        drinkImage.ShowDrink("vanilla_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 11;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_ice()
    {
        Debug.Log("You made a cup of iced vanilla latte!");
        drinkImage.ShowDrink("vanilla_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 12;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_hot()
    {
        Debug.Log("You made a cup of hot caffe latte!");
        drinkImage.ShowDrink("caffe_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 13;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_ice()
    {
        Debug.Log("You made a cup of iced caffe latte!");
        drinkImage.ShowDrink("caffe_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 14;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_latte_hot()
    {
        Debug.Log("You made a cup of hot greentea latte!");
        drinkImage.ShowDrink("greentea_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 15;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_latte_ice()
    {
        Debug.Log("You made a cup of iced greentea latte!");
        drinkImage.ShowDrink("greentea_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 16;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_latte()
    {
        Debug.Log("You made a cup of iced strawberry latte!");
        drinkImage.ShowDrink("strawberry_latte");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 17;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofhot_chocolate()
    {
        Debug.Log("You made a cup of hot chocolate!");
        drinkImage.ShowDrink("hot_chocolate");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 18;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofice_chocolate()
    {
        Debug.Log("You made a cup of iced chocolate!");
        drinkImage.ShowDrink("ice_chocolate");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 19;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofyogurt_smoothie()
    {
        Debug.Log("You made a cup of yogurt smoothie!");
        drinkImage.ShowDrink("yogurt_smoothie");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 20;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_smoothie()
    {
        Debug.Log("You made a cup of greentea smoothie!");
        drinkImage.ShowDrink("greentea_smoothie");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 21;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_smoothie()
    {
        Debug.Log("You made a cup of strawberry smoothie!");
        drinkImage.ShowDrink("strawberry_smoothie");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 22;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofyogurt_pearl()
    {
        Debug.Log("You made a cup of bubble tea (yogurt)!");
        drinkImage.ShowDrink("yogurt_pearl");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 23;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_pearl()
    {
        Debug.Log("You made a cup of bubble tea (greentea)!");
        drinkImage.ShowDrink("greentea_pearl");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 24;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_pearl()
    {
        Debug.Log("You made a cup of bubble tea (strawberry)!");
        drinkImage.ShowDrink("strawberry_pearl");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 25;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_frapp()
    {
        Debug.Log("You made a cup of espresso blended!");
        drinkImage.ShowDrink("espresso_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 26;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofgreentea_frapp()
    {
        Debug.Log("You made a cup of greentea blended!");
        drinkImage.ShowDrink("greentea_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 27;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofstrawberry_frapp()
    {
        Debug.Log("You made a cup of strawberry blended!");
        drinkImage.ShowDrink("strawberry_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 28;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofchocolate_frapp()
    {
        Debug.Log("You made a cup of chocolate blended!");
        drinkImage.ShowDrink("chocolate_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 29;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_ristretto()
    {
        Debug.Log("You made a cup of espresso (ristretto)!");
        drinkImage.ShowDrink("espresso");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 30;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_lungo()
    {
        Debug.Log("You made a cup of espresso (lungo)!");
        drinkImage.ShowDrink("espresso");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 31;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_ice_ristretto()
    {
        Debug.Log("You made a cup of caramel macchiato ice (ristretto)!");
        drinkImage.ShowDrink("caramel_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 32;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_ice_lungo()
    {
        Debug.Log("You made a cup of caramel macchiato ice (lungo)!");
        drinkImage.ShowDrink("caramel_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 33;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_hot_ristretto()
    {
        Debug.Log("You made a cup of caramel macchiato hot (ristretto)!");
        drinkImage.ShowDrink("caramel_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 34;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaramel_macchiato_hot_lungo()
    {
        Debug.Log("You made a cup of caramel macchiato hot (lungo)!");
        drinkImage.ShowDrink("caramel_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 35;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }

    public void Cupofamericano_ice_ristretto()
    {
        Debug.Log("You made a cup of iced americano (ristretto)!");
        drinkImage.ShowDrink("americano_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 36;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofamericano_ice_lungo()
    {
        Debug.Log("You made a cup of iced americano (lungo)!");
        drinkImage.ShowDrink("americano_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 37;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofamericano_hot_ristretto()
    {
        Debug.Log("You made a cup of hot americano (ristretto)!");
        drinkImage.ShowDrink("americano_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 38;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofamericano_hot_lungo()
    {
        Debug.Log("You made a cup of hot americano (lungo)!");
        drinkImage.ShowDrink("americano_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 39;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_ice_ristretto()
    {
        Debug.Log("You made a cup of iced caffe mocha (ristretto)!");
        drinkImage.ShowDrink("caffe_mocha_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 40;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_ice_lungo()
    {
        Debug.Log("You made a cup of iced caffe mocha (lungo)!");
        drinkImage.ShowDrink("caffe_mocha_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 41;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_hot_ristretto()
    {
        Debug.Log("You made a cup of hot caffe mocha (ristretto)!");
        drinkImage.ShowDrink("caffe_mocha_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 42;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_mocha_hot_lungo()
    {
        Debug.Log("You made a cup of hot caffe mocha (lungo)!");
        drinkImage.ShowDrink("caffe_mocha_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 43;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_con_panna_ristretto()
    {
        Debug.Log("You made a cup of espresso con panna (ristretto)!");
        drinkImage.ShowDrink("espresso_con_panna");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 44;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_con_panna_lungo()
    {
        Debug.Log("You made a cup of espresso con panna (lungo)!");
        drinkImage.ShowDrink("espresso_con_panna");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 45;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_macchiato_ristretto()
    {
        Debug.Log("You made a cup of espresso macchiato (ristretto)!");
        drinkImage.ShowDrink("espresso_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 46;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_macchiato_lungo()
    {
        Debug.Log("You made a cup of espresso macchiato (lungo)!");
        drinkImage.ShowDrink("espresso_macchiato");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 47;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcappuccino_ristretto()
    {
        Debug.Log("You made a cup of cappuccino (ristretto)!");
        drinkImage.ShowDrink("cappuccino");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 48;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcappuccino_lungo()
    {
        Debug.Log("You made a cup of cappuccino (lungo)!");
        drinkImage.ShowDrink("cappuccino");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 49;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_hot_ristretto()
    {
        Debug.Log("You made a cup of hot vanilla latte (ristretto)!");
        drinkImage.ShowDrink("vanilla_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 50;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_hot_lungo()
    {
        Debug.Log("You made a cup of hot vanilla latte (lungo)!");
        drinkImage.ShowDrink("vanilla_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 51;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_ice_ristretto()
    {
        Debug.Log("You made a cup of iced vanilla latte (ristretto)!");
        drinkImage.ShowDrink("vanilla_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 52;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofvanilla_latte_ice_lungo()
    {
        Debug.Log("You made a cup of iced vanilla latte (lungo)!");
        drinkImage.ShowDrink("vanilla_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 53;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_hot_ristretto()
    {
        Debug.Log("You made a cup of hot caffe latte (ristretto)!");
        drinkImage.ShowDrink("caffe_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 54;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_hot_lungo()
    {
        Debug.Log("You made a cup of hot caffe latte (lungo)!");
        drinkImage.ShowDrink("caffe_latte_hot");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 55;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_ice_ristretto()
    {
        Debug.Log("You made a cup of iced caffe latte (ristretto)!");
        drinkImage.ShowDrink("caffe_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 56;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofcaffe_latte_ice_lungo()
    {
        Debug.Log("You made a cup of iced caffe latte (lungo)!");
        drinkImage.ShowDrink("caffe_latte_ice");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 57;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_frapp_ristretto()
    {
        Debug.Log("You made a cup of espresso blended (ristretto)!");
        drinkImage.ShowDrink("espresso_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 58;
        Customer.GetComponent<CsvLoadCustomer>().recipe_number = menu;
    }
    public void Cupofespresso_frapp_lungo()
    {
        Debug.Log("You made a cup of espresso blended (lungo)!");
        drinkImage.ShowDrink("espresso_frapp");
        SoundManager.Instance.PlaySFXSound("cup", 0.75f);
        menu = 59;
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
        SoundManager.Instance.PlaySFXSound("reset");
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
                    case 'P':
                        ingredient = "리스트레토 샷";
                        break;
                    case 'Q':
                        ingredient = "룽고 샷";
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
                case "리스트레토 샷":
                    unit = "개";
                    break;
                case "룽고 샷":
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