# ShoppingBasket

The main approach I took was to create 3 main areas of logic: Item Management, Price Calculation, and Input Processing.

Input processing was necessary for the program to function, but is also an areas that would get changed the most if this was extended to a full UI program, so so this is a lightweight string processor to produce the variables needed for items.

For the item management it is a set up to build the items based on all the processed inputs. This is also a leightweight implementation as for next steps in this project I would imagine that an inventory of possible items would be loaded from data and this may change to add items from that inventory, rather than this functionallity that allows adding any item.

The price calculator is straightforward, looping to multiplying quanity by price to get the total. I had that logic here, rather than having the Item object have a method to return the total price to allow more flexibility in future for the price calculator to be extended that may have more complex calculations wanted.

I created the dicount as an interface so that when other types of discounts are wanted in future new discount classes could implement that interface and be used to create price calculators.

# Running The Project
When the project is launched the console app will prompt asking for a command:
Add
Remove
Total
Exit.

When selecting Add, you will be asked to enter the product name, price and qunatity seperated with commas.

When selecting Remove, you will be aksed to the product name and quntity seperated with commas.

When selecting total the summed total of items in the basket will be presented.
