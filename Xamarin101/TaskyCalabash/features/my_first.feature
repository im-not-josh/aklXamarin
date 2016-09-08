Feature: Adding a new task
  As a user
  I want to be able to add a new task
  So that I can keep track of things to do

  Scenario: Adding a new task with a name, notes and the done switch toggled on
    Given I am on the home page
    When I press the Add Task button
    Then I should be able to save a new task