using System;
using System.Text;

public class OldPhoneKeypad
{

    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            return string.Empty;

        // To remove # at the end of input
        input = input.Substring(0, input.Length - 1);

        Dictionary<char, string> keyMapping = new Dictionary<char, string>
    {
        {'1', "1"},
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"},
        {'0', "0"},
        {'*', "\b"}  // BackSpace
    };

        string result = "";
        char lastKey = '\0'; //null
        int consecutiveCount = 0;   //  to count times

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            if (currentChar == ' ')
            {

                if (lastKey != '\0' && keyMapping.ContainsKey(lastKey))
                {
                    string letters = keyMapping[lastKey];
                    int letterIndex = (consecutiveCount - 1) % letters.Length;
                    result = result + (letters[letterIndex]);
                }

                lastKey = '\0'; // Reset 
                consecutiveCount = 0;
                continue;
            }

            // If it's a new key, process the previous one
            if (currentChar != lastKey && lastKey != '\0')
            {
                if (keyMapping.ContainsKey(lastKey))
                {
                    string letters = keyMapping[lastKey];
                    int letterIndex = (consecutiveCount - 1) % letters.Length;
                    result = result + (letters[letterIndex]);
                }

                consecutiveCount = 0;
            }

            // Update the current key and increment count
            if (keyMapping.ContainsKey(currentChar))
            {
                lastKey = currentChar;
                consecutiveCount++;
            }
        }

        // Process the last key sequence
        if (lastKey != '\0' && keyMapping.ContainsKey(lastKey))
        {
            string letters = keyMapping[lastKey];
            int letterIndex = (consecutiveCount - 1) % letters.Length;
            result = result + (letters[letterIndex]);
        }

        return result;
    }
    
    static void TestCase(string input, string expected)
    {
        string result = OldPhonePad(input);
        bool passed = result.Equals(expected);

        Console.WriteLine($"Test '{input}': {(passed ? "PASSED" : "FAILED")}");
        if (!passed)
        {
            Console.WriteLine($"  Expected: '{expected}'");
            Console.WriteLine($"  Actual:   '{result}'");
        }
    }
    
    //Test
    public static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(OldPhonePad(input)); // Console input type
       //Console.WriteLine(OldPhonePad("227*#")); // Output: B
        Console.WriteLine("Running tests...");
        TestCase("", "");  // Empty input.
        TestCase("222", "");
        TestCase("227#", "BP");  // Simple case
        TestCase("4433555 555666#", "HELLO");  // Word
        TestCase("227*#", "B");  // Backspace
        TestCase("8 88777444666*664#", "TURING");  // Complex case
        Console.WriteLine("Tests complete!");


    }
}
