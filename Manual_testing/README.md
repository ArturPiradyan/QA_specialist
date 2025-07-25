# QA_specialist

##  Manual QA Testing
It simulates a full QA cycle across 3 key functional modules.

**Scope**

The following modules of OrangeHRM were manually tested:
   Module   Features Tested 
   Login    Valid/invalid login, empty fields, logout 
    PIM      Add/edit/delete employee, search 
    Admin    Add user, assign roles, disable/delete user 

This manual QA project demonstrates:
- Complete test lifecycle (plan , execute,  report)
- Documentation for 4 business-critical modules
- Bug reporting and validation process


## Selenium UI Automation

This project automates an end-to-end purchase flow on [SauceDemo](https://www.saucedemo.com/) using:

- Selenium WebDriver with C#
- NUnit framework
- Chrome browser automation
- Data-driven testing with `[TestCase]`
- Screenshots on failure

---
**Project Overview**

This test simulates a full user actions:
1. Login as a standard user
2. Add a product to the cart
3. Proceed through checkout
4. Input user info (first name, last name, postal code)
5. Complete the purchase
6. Verify the order confirmation

Tools used

- **Language**: C#
- **Framework**: NUnit
- **Browser**: Google Chrome
- **WebDriver**: Selenium.WebDriver + ChromeDriver
- **IDE**: Visual Studio

Test Method, Description 

 Purchase_Flow()  Executes full login + cart + checkout + confirm 
 [TestCase] Db for multiple customers 
