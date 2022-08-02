Feature: Login

  Scenario Outline: Invalid sign in with user
    Given User is using browser
            | Browser |
		    | chrome  |
    Given User has opened Oracle Profile page
    When User inputs '<email>' as email
    And User inputs '<password>' as password
    And User presses Sign In button
    Then User sees invalid credentials message

    Examples:
      | email               | password                  |
      | big@floppa.com      | caracul                   |
      | horus@herecy.com    | grandpa_nurgle            |
      | karen803@bench.com  | remembermethecomplanyname |