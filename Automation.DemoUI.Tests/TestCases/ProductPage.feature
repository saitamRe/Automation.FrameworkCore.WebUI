Feature: ProductPage

A short summary of the feature



Scenario: Verify different products prices and titles
	Given Login with valid credentials
	Then User verifies all the products
		| Item                              | Price  |
		| Sauce Labs Backpack               | $29.99 |
		| Sauce Labs Bike Light             | $9.99  |
		| Sauce Labs Bolt T-Shirt           | $15.99 |
		| Sauce Labs Fleece Jacket          | $49.99 |
		| Sauce Labs Onesie                 | $7.99  |
		| Test.allTheThings() T-Shirt (Red) | $15.99 |