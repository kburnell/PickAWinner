require 'bewildr'

Then /^(\d+) window is displayed with name "([^"]*)"$/ do |count,name|
      @window = @application.wait_for_window(name)
      @application.windows.size.should == count.to_i
      @window.name.should match(name)
end

When /^I try to get a reference to "([^"]*)"$/ do |window|
    @window =  @application.wait_for_window(window)
end

Then /^I have a reference to a window$/ do
  @window.control_type.should == :window
end

Then /^The window name is "([^"]*)"$/ do |name|
  @window.name.should match(name)
end

When /^The "([^"]*)" window is displayed$/ do |window|
  @window = @application.wait_for_window(window)
end

Then /^The "([^"]*)" window is not displayed$/ do |window|
  @application.window(window).should == nil
end

When /^The "([^"]*)" window is displayed again$/ do |window|
  @window = @application.wait_for_window(window)
end