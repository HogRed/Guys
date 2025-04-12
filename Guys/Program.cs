internal class Guy
{
public string? Name;
public int Cash;

    /// <summary>
    /// Writes my name and the amount of cash I have to the console.
    /// </summary>
    public void WriteMyInfo()
{
    Console.WriteLine(Name + " has " + Cash + " bucks.");
}
/// <summary>
/// Gives some of my cash, removing it from my wallet (or printing
/// a message to the console if I don't have enough cash).
/// </summary>
/// <param name="amount">Amount of cash to give.</param>
/// <returns>
/// The amount of cash removed from my wallet, or 0 if I don't
/// have enough cash (or if the amount is invalid).
/// </returns>
public int GiveCash(int amount)
{
    if (amount <= 0)
    {
        Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
        return 0;
    }
    if (amount > Cash)
    {
        Console.WriteLine(Name + " says: " +
        "I don't have enough cash to give you " + amount);
        return 0;
    }
    Cash -= amount;
    return amount;
}
/// <summary>
/// Receive some cash, adding it to my wallet (or printing
/// a message to the console if the amount is invalid).
/// </summary>
/// <param name="amount">Amount of cash to receive.</param>
public void ReceiveCash(int amount)
{
    if (amount <= 0)
    {
        Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
    }
    else
    {
        Cash += amount;
    }
}
}
namespace Guys
{
    internal class Program
    {
        private static void Main()
        {
            // Create an instance of the Guy class named joe
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };

            // Create an instance of the Guy class named bob
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };

            while (true)
            {
                // Call the WriteMyInfo methods for each Guy object
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                // Ask the user for an amount of cash
                Console.Write("Enter an amount: ");
                string? howMuch = Console.ReadLine();

                // Check if the input is empty
                if (howMuch == "") return;

                // Try to parse the input as an integer
                if (int.TryParse(howMuch, out int amount) && amount > 0)
                {
                    Console.Write("Who should give the cash: ");
                    string? whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        // Call the joe object's GiveCash method and save the results
                        int cashGiven = joe.GiveCash(amount);
                        // Call the bob object's ReceiveCash method with the saved results
                        bob.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        // Call the bob object’s GiveCash method and save the results
                        int cashGiven = bob.GiveCash(amount);
                        // Call the joe object’s ReceiveCash method with the saved results
                        joe.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }
    }
}

// This program creates two instances of the Guy class, Joe and Bob, and allows the user to transfer cash between them.