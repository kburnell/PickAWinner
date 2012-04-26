require 'bewildr'

Given /^I ensure that there are no instances of "([^"]*)" running$/ do |app|
  Bewildr::Application.kill_all_processes_with_name(app)
end

When /^I start "([^"]*)"$/ do |app|
  @application = Bewildr::Application.start(app)
end

Then /^the app is running$/ do
  @application.should be_running
end

When /^Terminate the app$/ do
  @application.kill
end

Then /^The app should no longer be running$/ do
  @application.should_not be_running
end