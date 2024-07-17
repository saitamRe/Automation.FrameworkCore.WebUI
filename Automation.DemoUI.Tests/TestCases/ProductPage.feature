Feature: ProductPage

A short summary of the feature


@LoginToApp
Scenario: Verify different products prices and titles
	Then User verifies all the products
		| Item                              | Price  |
		| Sauce Labs Backpack               | $29.99 |
		| Sauce Labs Bike Light             | $9.99  |
		| Sauce Labs Bolt T-Shirt           | $15.99 |
		| Sauce Labs Fleece Jacket          | $49.99 |
		| Sauce Labs Onesie                 | $7.99  |
		| Test.allTheThings() T-Shirt (Red) | $15.99 |


@LoginToApp
Scenario: Verify Cart count
	When User cart items from product list to cart
		| Items                    |
		| Sauce Labs Backpack      |
		| Sauce Labs Fleece Jacket |
	Then User checks count in cart of selected items
	When User uncart items from product list
		| Items                    |
		| Sauce Labs Backpack      |
		| Sauce Labs Fleece Jacket |
	Then user verifies no item in cart
	When User cart items from product list to cart
		| Items               |
		| Sauce Labs Backpack |
	Then User checks count in cart of selected items