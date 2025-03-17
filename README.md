# OldPhoneKeypad 

Using an old mobile phone keypad to convert a string of numeric inputs into readable text.

## Function
- The program processes a string of key presses and it is converted into their corresponding letters. 
- Each keys can be press multiple times but the input string must be end with # to be processed. If input string didn't consist of #, it will return only input numbers. 
- Space key acts as a separator between character sequences. 
- The * key acts as backspace. 

## Class and Method 
### Parameter 
- input(string):  A sequence of keys which ending with #

## Implementation Details 
1. Validation: If the input is null, empty, or does not end with #, an empty string is returned.
2. Removing the #: The last character is removed from the input.
3. Key Mapping: A dictionary maps numeric keys to their corresponding letters.
4. Processing Key Presses: Loops through each character into the input string. If a space is encountered, the previously processed letter is appended to the result.
5. Appending Final Character: After the loop, the last character is appended to the result.
6. Returning the Final String.

## Example of Inputs & Outputs:
- Input: 33#  -- > E
- Input: 4433555 555666# -- > HELLO
