@application
@window

Feature: Application Interaction

  Scenario: The main window should be displayed on application start
    Given I ensure that there are no instances of "PickAWinnerTDD.UI.exe" running
    And I start "D:\\Dev\\PickAWinnerTDD\\PickAWinnerTDD.UI\\bin\\Debug\\PickAWinnerTDD.UI.exe"
    Then 1 window is displayed with name "PickAWinnerTDD"
      And Terminate the app