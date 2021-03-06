using System.Collections;
using System.Collections.Generic;


public class StockPile 
{

    public int GoldOre;
    public int CoalOre;
    public int IronOre;
    public int Capacity;

    public StockPile(int goldOre, int coalOre, int ironOre, int capacity)
    {
        GoldOre = goldOre;
        CoalOre = coalOre;
        IronOre = ironOre;
        Capacity = capacity;    
    }

    /// <summary>
    /// Checks if the Transaction is Doable and return the value of available Ore stored.
    /// CanTransact does not mutate the data of the class. 
    /// </summary>
    /// <param name="typeMetal"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int CanTransact(TileManager.TypeMetal typeMetal, int amount) {
        if (typeMetal == TileManager.TypeMetal.coal)
        {
            if (amount <= CoalOre)
            {
                return amount;
            }
            else
            {
                if (CoalOre > 0)
                {
                    return CoalOre;
                }
                else
                {
                    return 0;
                }

            }

        }
        if (typeMetal == TileManager.TypeMetal.gold)
        {

            if (amount <= GoldOre)
            {
                return amount;
            }
            else
            {
                if (GoldOre > 0)
                {
                    return GoldOre;
                }
                else
                {
                    return 0;
                }

            }
        }
        if (typeMetal == TileManager.TypeMetal.iron)
        {

            if (amount <= IronOre)
            {
                return amount;
            }
            else
            {
                if (IronOre > 0)
                {
                    return IronOre;
                }
                else
                {
                    return 0;
                }

            }
        }
        return 0;


    }
    /// <summary>
    /// It tries to store the given ammount. Returns a boolean that describes if the StockPile has enough capacity to Store the required metals.
    /// </summary>
    /// <param name="typeMetal"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool Deposit(TileManager.TypeMetal typeMetal, int amount ) {
        if (Capacity >= (getCurentTotal() + amount))
        {
            if (typeMetal == TileManager.TypeMetal.coal)
            {
                CoalOre += amount;
            }
            if (typeMetal == TileManager.TypeMetal.gold)
            {
                GoldOre += amount;
            }
            if (typeMetal == TileManager.TypeMetal.iron)
            {
                IronOre += amount;
            }
            return true;
        }

        return false;

    }

    /// <summary>
    /// It checks if the Stocke pile has enough Stored to return. If it hasn't then it returns 0.
    /// </summary>
    /// <param name="typeMetal"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int Withdraw(TileManager.TypeMetal typeMetal, int amount)
    {
        if (typeMetal == TileManager.TypeMetal.coal)
        {
            if (amount <= CoalOre)
            {
                
                CoalOre -= amount;
                return amount;
            }
            else
            {
                if (CoalOre>0) {
                    var OreLeft = CoalOre;
                    CoalOre = 0;
                    return OreLeft; 
                }
                else { 
                    return 0; 
                }
                   
            }

        }
        if (typeMetal == TileManager.TypeMetal.gold)
        {
   
            if (amount <= GoldOre)
            {
                GoldOre -= amount;
                return amount;
            }
            else
            {
                if (GoldOre > 0)
                {
                    var OreLeft = GoldOre;
                    GoldOre = 0;
                    return OreLeft;
                }
                else
                {
                    return 0;
                }

            }
        }
        if (typeMetal == TileManager.TypeMetal.iron)
        {

            if (amount <= IronOre)
            {
                IronOre -= amount;
                return amount;
            }
            else {
                if (IronOre > 0)
                {
                    var OreLeft = IronOre;
                    IronOre = 0;
                    return OreLeft;
                }
                else
                {
                    return 0;
                }

            }
        }
        return 0;
    }
    public int getCurentTotal() {
        return CoalOre + IronOre + GoldOre;
    }

}
