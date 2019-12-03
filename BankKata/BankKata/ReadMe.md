# Bank Kata
​
Implement a bank account that can deposit, withdraw and print a statement to the console.
​
## Rules 
- Follow the `Tell, don't ask` principle. All methods should be void.
- You can't change the public interface of this class. We start simple with int´s for money and string for dates ( even if this is primitive obsession)
- Don´t worry about the formatting of the statement.
​
```csharp
public class Account
{
    void Deposit(int);
    void Withdraw(int);
    void PrintStatement();
}
```
## Hint 
​
An acceptance test to start:
​
```
Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When she prints her bank statement
Then she would see
​
date       || credit   || debit    || balance  
14/01/2012 ||          || 500.00   || 2500.00   
13/01/2012 || 2000.00  ||          || 3000.00  
10/01/2012 || 1000.00  ||          || 1000.00 