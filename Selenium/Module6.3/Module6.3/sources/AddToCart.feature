Feature: AddToCart
   In order to test my cart
   As a user
   I want to be able to add some item into the cart

#Scenario: Find item and add to cart
#   Given I enter "iPhone 5" in the search feild
#   When I click on "Find" button
#   And I click on button labled "Купить сейчас"
#   Then I should see the result where "iPhone 5" item on the top
#   When I click on the first item name
#   Then I should see full description
#   When I select color
#   And I click the button with label "Add to cart"
#   Then I should see confirmation message "был добавлен в вашу корзину"
#   When I navigate to the cart
#   Then I should see "iPhone 5" item in the cart

#Scenario Outline: Find few items and add to the cart
#   Given I enter "<searchRequest>" in the search feild
#   When I click on "Find" button
#   And I click on button labled "Купить сейчас"
#   Then I should see the result where "<searchRequest>" item on the top
#   When I click on the first item name
#   Then I should see full description
#   When I select color
#   And I click the button with label "Add to cart"
#   Then I should see confirmation message "был добавлен в вашу корзину"
#   When I navigate to the cart
#   Then I should see "<searchRequest>" item in the cart
#   Examples: 
#   |searchRequest  |
#   |iPhone 4 |
#   |HTC One  |

   #Scenario: Find 2 items and add to cart
   #Given I enter "iPhone 4" in the search feild
   #When I click on "Find" button
   #And I click on button labled "Купить сейчас"
   #Then I should see the result where "iPhone 4" item on the top
   #When I click on the first item name
   #Then I should see full description
   #When I select color
   #And I click the button with label "Add to cart"
   #Then I should see confirmation message "был добавлен в вашу корзину"
   #When I navigate to the cart
   #Then I should see "iPhone 4" item in the cart
   #Given I enter "HTC One" in the search feild
   #When I click on "Find" button
   #And I click on button labled "Купить сейчас"
   #Then I should see the result where "HTC One" item on the top
   #When I click on the first item name
   #Then I should see full description
   #When I select color
   #And I click the button with label "Add to cart"
   #Then I should see confirmation message "был добавлен в вашу корзину"
   #When I navigate to the cart
   #Then I should see "HTC One" item in the cart

   #Scenario: Remove item from cart
   #Given I enter "iPhone 5" in the search feild
   #When I click on "Find" button
   #And I click on button labled "Купить сейчас"
   #Then I should see the result where "iPhone 5" item on the top
   #When I click on the first item name
   #Then I should see full description
   #When I select color
   #And I click the button with label "Add to cart"
   #Then I should see confirmation message "был добавлен в вашу корзину"
   #When I navigate to the cart
   #Then I should see "iPhone 5" item in the cart
   #When I click the link labelled "Удалить"
   #Then I should see confirmation message "был удален из вашей корзины"

   #Scenario: Go to order items from cart
   #Given I enter "iPhone 5" in the search feild
   #When I click on "Find" button
   #And I click on button labled "Купить сейчас"
   #Then I should see the result where "iPhone 5" item on the top
   #When I click on the first item name
   #Then I should see full description
   #When I select color
   #And I click the button with label "Add to cart"
   #Then I should see confirmation message "был добавлен в вашу корзину"
   #When I navigate to the cart
   #Then I should see "iPhone 5" item in the cart
   #When I want to click to order button
   #Then I should see a login page

   Scenario: Test cart after login
   Given I login to ebay
   Then I enter "iPhone 5" in the search feild
   When I click on "Find" button
   And I click on button labled "Купить сейчас"
   Then I should see the result where "iPhone 5" item on the top
   When I click on the first item name
   Then I should see full description
   When I select color
   And I click the button with label "Add to cart"
   Then I should see confirmation message "был добавлен в вашу корзину"
   When I navigate to the cart
   Then I should see "iPhone 5" item in the cart
   When I want to click to "Сохранить на будущее" button
   Then I should see confirmation message "был сохранен для покупки в будущем"
