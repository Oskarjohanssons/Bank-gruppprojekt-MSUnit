# Bank-gruppprojekt🏦

## Welcome to the Bank Group Project!

Welcome to the Avicii Bank Group Project! This collaborative effort brings together the coding expertise of several contributors to develop a robust banking system simulation. Whether you're a customer looking to manage your accounts or an administrator overseeing the financial operations, this project has got you covered.

### Table of Contents
- Introduction
- Features
- Usage
- Code Structure
- How to Run
- Contributing
 - License
  
### Introduction
In today's digital age, banking systems play a crucial role in facilitating financial transactions and providing users with a secure platform to manage their funds. The Avicii Bank Group Project aims to replicate key aspects of real-world banking, offering a comprehensive set of features for both customers and administrators.

### Features
**User Authentication**
Customers: Authenticate with a username and PIN.
Administrators: Access administrative functionalities with specific credentials.

**Customer Functionalities:**
- Deposit: Add funds to accounts effortlessly.
- Withdraw: Withdraw money from accounts securely.
- Transfer: Move money between accounts seamlessly.
- Account Creation: Open new accounts with varying currencies and types.
- Balance Inquiry: Check the balance of any account.
- Transaction History: View a detailed log of account transactions.
- Loan Requests: Request loans and understand associated terms.
  
**Administrator Functionalities:**
- User Management: Administrators can create new user accounts.
- Exchange Rates: Set and manage currency exchange rates.
- Interest Rates: Display interest rates for different account types.
  
**Usage**

The Avicii Bank Group Project provides an interactive command-line interface for users. Both customers and administrators can navigate through intuitive menus to perform a wide range of banking operations. The system prompts users for necessary information such as usernames, PINs, and transaction details, ensuring a user-friendly experience.

**Code Structure**

The project's codebase is structured around two primary classes: Administrator and Customer. Each class encapsulates functionalities tailored to its respective role in the banking system.

**Administrator Class:**

Manages administrative tasks, including user creation and rate setting.
Enables the creation of new customer accounts.

**Customer Class:**

Handles customer-specific operations, such as deposits, withdrawals, and transfers.
Manages account creation, loan requests, and transaction logging.

**How to Run**
- Clone the project repository to your local machine.


## Testing
- Från detta projekt så har jag valt ut att identifierat  och testa, först och främst **inloggningsdelen** utav koden. Det är ju en ganska kritisk del i och med att det är det första "kunden" möts utav så den bör fungera helt felfritt. Att inloggningsdelen i koden faktiskt autentisierar vem som loggar in, om den är admin eller an vanlig user är väldigt viktigt. Man vill inte att en vanlig user ska komma åt "adminsidan". 
- Jag har också valt att testa **uttag och insättning utav pengar**. Här är det viktigt att pengarna dras och sätts in på och ifrån rätt konto, att det verkligen är den inloggade userns konton man kommer åt. 
- Näst så vill jag också testa **överföringar av pengar** mellan konton, både mellan användarens egna konton (om den har flera) men också mellan olika användares konton. 




