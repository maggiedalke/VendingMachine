# VendingMachine

A vending machine has a set of coins to handle purchase operations, when a customer buys a product from the machine and pays, the machine will return the remaining money from the coins in its internal storage.<br>


## Development Process

The Vending Machine has the following coins:
**1$, 2$, 5$, 10$, 20$**
The machine also tracks the quantity of each coin, for example, the quantity of 5$ coins is 15, which means the machine currently has 15 pieces of 5$ coins.

I wrote a method that control the purchas operation 
- it takes as input a vending machine, price of item, and the money paid by the customer. And it returns the coins and quantities that should be returned to the user.<br>

Example:<br>
The user entered 25$ and he wants to buy a 2$ item, so the machine should return the following:<br>
~~~~
20$ : 1 piece <br>
2$ : 1 piece<br>
1$ : 1 piece<br>
If the machine is out of a certain coin, it should not return it.<br>
The machine always returns the minimum amount of possible coins.<br>
~~~~

## String Manipulation Bonus

I created a simple file compression algorithm that works with strings, those strings are uppercase letters only.<br>
To compress a string, the program counts the consecutive similar letters and replace them with a number.<br>
Example:<br>
String = “RTFFFFYYUPPPEEEUU”<br>
Result = “RTF4YYUP3E3UU”<br>

The program will replace a letter if it appeared more than 2 times continuously, the replacement is done by keeping one copy of this letter then writing down the number this letter appeared consecutively.

I wrote two methods, one to **compress** the string, and the other to **decompress** the string. 
