// The term 'bracket' is used to refer to parentheses throughout.
// This is done for readability and ease of understanding.

using System.Text.RegularExpressions;

class Evaluator
{
    public static void Main(String[] args)
    {
        // Get input from user.
        string consoleInput = GetInput();

        // Remove invalid tokens from input.
        // Valid tokens are integers, brackets, and the 4 basic operators.
        string userInput = RemoveInvalidTokens(consoleInput);

        // Check that the input has balanced brackets.
        // Also check that the first bracket isn't a closing bracket.
        bool balancedBrackets = CheckBrackets(userInput);

        if (!balancedBrackets)
        {
            //TO DO Return to user input rather than exiting.
            Console.WriteLine("Improperly formatted brackets. Please correct and try again.");
            Environment.Exit(-1);
        }

        Console.WriteLine(userInput);
    }
    public static string GetInput()
    {
        Console.Write("Please enter an expression: ");
        string input = Console.ReadLine();

        return input;
    }

    public static string RemoveInvalidTokens(String inputString)
    {
        // Regex pattern looks for only integers, brackets, and basic operators.
        // Everything else is replaced with nothing.
        // (Is it actually a zero-width character? Could this cause problems elsewhere?)
        string input = inputString;
        string pattern = @"[^\d\(\)+\-*/]";
        string replacement = "";

        string result = Regex.Replace(input, pattern, replacement);

        return result;
    }

    public static bool CheckBrackets (String inputString)
    {
        int openBrackets = 0;
        int position = 0;

        bool firstBracket = true;
        for (position = 0; position < inputString.Length; position++)
        {
            char c = inputString[position];
            if (c == '(')
            {
                openBrackets++;
                firstBracket = false;
            }
            else if ((c == ')') && firstBracket == true)
            {
                Console.WriteLine("Leading open bracket found. Please reformat and try again.");
                openBrackets--;
                break;
            }
            else if ((c == ')') && (firstBracket == false))
            {
                openBrackets--;
            }
        }

        if (openBrackets == 0)
        {
            return true;
        }
        else if ((openBrackets != 0) && (firstBracket = true))
        {
            return false;
        }
        else
        {
            Console.WriteLine("This expression has open brackets. Please reformat and try again.");
            return false;
        }
    }

    //public static string RemoveWhitespace(String inputString)
    //{
    //    string input = inputString;
    //    string pattern = "\\s+";
    //    string replacement = "";

    //    string result = Regex.Replace(input, pattern, replacement);

    //    return result;
    //}

    //public static bool ValidateInput(String inputString)
    //{

    //}

}