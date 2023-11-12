Feature: PlanAJourneyTFL




Scenario: Valid Journey
	Given I am on TFL Site
	When I click on Plan a Journey Tab
	And I enter 'Manchester' in the From Widget and 'London Bridge' in to Widget and 'click plan a journey button'
	Then I should verify that a Valid Journey can be Planned


Scenario: Unable to plan a journey
	Given I am on TFL Site
	When I click on Plan a Journey Tab
	And I enter '@@@@@@@@@@@' in the From Widget and '@@@@@@@@@@' in to Widget and 'click plan a journey button'
	Then 'Sorry, we can't find a journey matching your criteria' Error msg displayed

Scenario: No Location Entered
	Given I am on TFL Site
	When I click on Plan a Journey Tab
	And I enter '' in the From Widget and '' in to Widget and 'click plan a journey button'
	Then i should verify From and To Error msg displayed


Scenario: Plan Journey based on arriving option
	Given I am on TFL Site
	When I click on Plan a Journey Tab
	When I enter 'Manchester' in the From Widget and 'London Bridge' in to Widget and 'click change time'
	Then Arriving is displayed on the planner
	When I set arrival time to 'Tommorow' and '11:30'
	Then I should verify that a Valid Journey can be Planned

Scenario: Edit Journey
	Given I am on TFL Site
	When I click on Plan a Journey Tab
	And I enter 'Manchester' in the From Widget and 'London Bridge' in to Widget and 'click plan a journey button'
	Then I should verify that a Valid Journey can be Planned
	When I edit journeycx11
	Then I should verify that a Valid Journey can be updated

@ignore
# Recent planned journey not displayed
Scenario: List of Recent Journeys Displayed
	Given I am on TFL Site
	When I click recent
	#Then List of recently planned Journey is displayed