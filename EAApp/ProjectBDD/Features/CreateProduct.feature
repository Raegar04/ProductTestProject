Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](ProjectBDD/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Create product
	Given I go to the product page
	And I go to create product page
	And I create product with details:
		| Name | Description | Price | ProductType |
		| Test | Test        | 12    | CPU         |
	When I go to details of the newly created entity
	Then I check if actual product details are the same with created one
	Then I cleanup flow